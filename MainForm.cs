using Microsoft.Collections.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DupeFinder
{
    public partial class MainForm : Form
    {
        DataTable dataTable = new DataTable("Dupe Data");
        int count;
        int num_done;
        string saveFile;

        public MainForm()
        {
            InitializeComponent();
            var nameCol = dataTable.Columns.Add("Name", typeof(string));
            var sizeCol = dataTable.Columns.Add("Size", typeof(long));
            var h1kCol = dataTable.Columns.Add("Hash1k", typeof(string));
            var h1mCol = dataTable.Columns.Add("Hash1M", typeof(string));
            var hCol = dataTable.Columns.Add("Hash", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { nameCol };

            saveFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DupeFinder.xml");
            if (File.Exists(saveFile) && MessageBox.Show("Load saved session?", "Dupe Finder", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var str = File.OpenRead(saveFile))
                {
                    dataTable.ReadXml(str);
                }
            }

            resultsView.DataSource = dataTable;
            resultsView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resultsView.Columns[1].DefaultCellStyle.Format = "N0";
        }

        private void start_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            foreach (var f in Directory.EnumerateFiles(src1.Text, "*", SearchOption.AllDirectories))
            {
                var fi = new FileInfo(f);
                dataTable.Rows.Add(new object[] { f, fi.Length });
            }
            foreach (var f in Directory.EnumerateFiles(src2.Text, "*", SearchOption.AllDirectories))
            {
                var fi = new FileInfo(f);
                dataTable.Rows.Add(new object[] { f, fi.Length });
            }

            num_done = 0;

            timer1.Tick += SizeDups;
            timer1.Start();
        }

        private void SizeDups(object sender, EventArgs e)
        {
            timer1.Tick -= SizeDups;
            timer1.Stop();

            var sizes = new Dictionary<long, List<string>>();
            foreach (var row in dataTable.AsEnumerable())
            {
                string f = row.Field<string>(0);
                long s = row.Field<long>(1);

                if (sizes.TryGetValue(s, out List<string> fl))
                {
                    fl.Add(f);
                }
                else
                {
                    sizes.Add(s, new List<string>() { f });
                }
            }
            foreach (var item in sizes)
            {
                if (item.Value.Count == 1)
                {
                    dataTable.Rows.Find(item.Value.First()).Delete();
                }
            }

            count = dataTable.Rows.Count;

            timer1.Tick += DoHash1k;
            timer1.Start();
        }

        private void DoHash1k(object sender, EventArgs e)
        {
            timer1.Tick -= DoHash1k;
            timer1.Stop();
            DateTime t = DateTime.Now;

            progressBar.Value = 100 * num_done / count;

            foreach (var row in dataTable.AsEnumerable().
                Where(val => val.Field<string>("Hash1k") == null))
            {
                using (var br = new BinaryReader(File.OpenRead(row.Field<string>("Name"))))
                {
                    var bytes = br.ReadBytes(10240);
                    using (SHA256 sha = SHA256.Create())
                    {
                        var hash = sha.ComputeHash(bytes);
                        row.SetField<string>("Hash1k", BitConverter.ToString(hash));
                        num_done++;
                    }
                }

                if ((DateTime.Now -t).TotalMilliseconds > 500)
                {
                    timer1.Tick += DoHash1k;
                    timer1.Start();
                    return;
                }
            }

            progressBar.Value = 0;
            timer1.Tick += HashDups;
            timer1.Start();
        }

        private Dictionary<string, List<string>> GetDupeList()
        {
            var hashes = new Dictionary<string, List<string>>();
            foreach (var row in dataTable.AsEnumerable())
            {
                string f = row.Field<string>(0);
                string h = row.Field<long?>(1).ToString() + row.Field<string>(2);
                if (row.Field<string>(3) != null)
                {
                    h += row.Field<string>(3);
                    num_done++;
                }
                if (row.Field<string>(4) != null)
                {
                    h += row.Field<string>(4);
                    num_done++;
                }

                if (hashes.TryGetValue(h, out List<string> fl))
                {
                    fl.Add(f);
                }
                else
                {
                    hashes.Add(h, new List<string>() { f });
                }
            }

            var files = new Dictionary<string, List<string>>();
            foreach (var item in hashes)
            {
                foreach (var f in item.Value)
                {
                    files.Add(f, item.Value.Where(x => x != f).ToList());
                }
            }
            return files;
        }

        private void HashDups()
        {
            var hashes = new Dictionary<string, List<string>>();
            foreach (var row in dataTable.AsEnumerable())
            {
                string f = row.Field<string>(0);
                string h = row.Field<long?>(1).ToString() + row.Field<string>(2);
                if (row.Field<string>(3) != null)
                {
                    h += row.Field<string>(3);
                    num_done++;
                }
                if (row.Field<string>(4) != null)
                {
                    h += row.Field<string>(4);
                    num_done++;
                }

                if (hashes.TryGetValue(h, out List<string> fl))
                {
                    fl.Add(f);
                }
                else
                {
                    hashes.Add(h, new List<string>() { f });
                }
            }
            foreach (var item in hashes)
            {
                if (item.Value.Count == 1)
                {
                    dataTable.Rows.Find(item.Value.First()).Delete();
                }
            }
        }

        private void HashDups(object sender, EventArgs e)
        {
            timer1.Tick -= HashDups;
            timer1.Stop();

            HashDups();
        }

        private void DoHash1m(string path)
        {
            using (var br = new BinaryReader(File.OpenRead(path)))
            {
                var bytes = br.ReadBytes(1024 * 1024);
                using (SHA256 sha = SHA256.Create())
                {
                    var hash = sha.ComputeHash(bytes);
                    var row = dataTable.Rows.Find(path);
                    row.SetField<string>("Hash1m", BitConverter.ToString(hash));
                }
            }
        }

        private void DoHash(string path)
        {
            //using (SHA256 sha = SHA256.Create())
            //{
            //    var hash = sha.ComputeHash(File.OpenRead(path));
            //    var row = dataTable.Rows.Find(path);
            //    row.SetField<string>("Hash", BitConverter.ToString(hash));
            //}
            var len = (new FileInfo(path)).Length;
            using (var fs = File.OpenRead(path))
            {
                byte[] buffer = new byte[16 * 1024];
                using (SHA256 sha = SHA256.Create())
                {
                    for (int segment = 0; segment < 16; segment++)
                    {
                        long pos = len * segment / 16L;
                        fs.Seek(pos, SeekOrigin.Begin);
                        fs.Read(buffer, segment * 1024, 1024);
                    }
                    var hash = sha.ComputeHash(buffer);
                    var row = dataTable.Rows.Find(path);
                    row.SetField<string>("Hash", BitConverter.ToString(hash));
                }
            }
        }

        private void hash1MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hashes = GetDupeList();

            foreach (var s in resultsView.SelectedRows)
            {
                var row = ((s as DataGridViewRow).DataBoundItem as DataRowView).Row;
                string f = row.Field<string>(0);
                DoHash1m(f);
                
                if (hashes.TryGetValue(f, out var others))
                {
                    foreach (var x in others)
                    {
                        DoHash1m(x);
                    }
                }
            }
            HashDups();
        }

        private void hashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hashes = GetDupeList();

            progressBar.Value = 0;
            int c = resultsView.SelectedRows.Count;
            int n = 0;

            var toHash = new HashSet<string>();

            foreach (var s in resultsView.SelectedRows)
            {
                var row = ((s as DataGridViewRow).DataBoundItem as DataRowView).Row;
                string f = row.Field<string>(0);
                toHash.Add(f);
            }

            foreach (var f in toHash)
            {
                DoHash(f);

                if (hashes.TryGetValue(f, out var others))
                {
                    foreach (var x in others)
                    {
                        if (!toHash.Contains(x))
                        DoHash(x);
                    }
                }

                n++;
                progressBar.Value = 100 * n / c;
            }
            progressBar.Value = 0;
            timer1.Tick += HashDups;
            timer1.Start();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            int c = resultsView.SelectedRows.Count;
            int n = 0;

            foreach (var s in resultsView.SelectedRows)
            {
                var row = ((s as DataGridViewRow).DataBoundItem as DataRowView).Row;
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(row.Field<string>(0),
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                row.Delete();
                n++;
                progressBar.Value = 100 * n / c;
            }
            progressBar.Value = 0;
            timer1.Tick += HashDups;
            timer1.Start();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var row = (resultsView.CurrentRow.DataBoundItem as DataRowView).Row;
            using (Process proc = new Process())
            {
                proc.StartInfo.FileName = row.Field<string>(0);
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var str = File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DupeFinder.xml")))
            {
                dataTable.WriteXml(str);
            }
        }

        private void candidateButton_Click(object sender, EventArgs e)
        {
            resultsView.ClearSelection();

            var files = GetDupeList();

            foreach (var s in resultsView.Rows)
            {
                var dgvr = s as DataGridViewRow;
                var row = (dgvr.DataBoundItem as DataRowView).Row;
                var f = row.Field<string>(0);
                if (f.StartsWith(src1.Text))
                {
                    if (files.TryGetValue(f, out var others))
                    {
                        if (others.Count == 1 &&
                            others.First().StartsWith(src2.Text))
                        {
                            dgvr.Selected = true;
                        }
                    }
                }
            }
        }
    }
}
