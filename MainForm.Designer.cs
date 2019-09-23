namespace DupeFinder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.src1 = new System.Windows.Forms.TextBox();
            this.src2 = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.resultsView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hash1MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.Button();
            this.candidateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultsView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // src1
            // 
            this.src1.Location = new System.Drawing.Point(145, 12);
            this.src1.Name = "src1";
            this.src1.Size = new System.Drawing.Size(340, 26);
            this.src1.TabIndex = 0;
            this.src1.Text = "f:\\recover";
            // 
            // src2
            // 
            this.src2.Location = new System.Drawing.Point(145, 54);
            this.src2.Name = "src2";
            this.src2.Size = new System.Drawing.Size(340, 26);
            this.src2.TabIndex = 1;
            this.src2.Text = "g:\\root\\video";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(520, 13);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(210, 67);
            this.start.TabIndex = 2;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // resultsView
            // 
            this.resultsView.AllowUserToAddRows = false;
            this.resultsView.AllowUserToDeleteRows = false;
            this.resultsView.AllowUserToResizeRows = false;
            this.resultsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.resultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsView.ContextMenuStrip = this.contextMenuStrip1;
            this.resultsView.Location = new System.Drawing.Point(12, 120);
            this.resultsView.Name = "resultsView";
            this.resultsView.ReadOnly = true;
            this.resultsView.RowTemplate.Height = 28;
            this.resultsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsView.Size = new System.Drawing.Size(1208, 1099);
            this.resultsView.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hash1MToolStripMenuItem,
            this.hashToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 130);
            // 
            // hash1MToolStripMenuItem
            // 
            this.hash1MToolStripMenuItem.Name = "hash1MToolStripMenuItem";
            this.hash1MToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.hash1MToolStripMenuItem.Text = "Hash 1M";
            this.hash1MToolStripMenuItem.Click += new System.EventHandler(this.hash1MToolStripMenuItem_Click);
            // 
            // hashToolStripMenuItem
            // 
            this.hashToolStripMenuItem.Name = "hashToolStripMenuItem";
            this.hashToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.hashToolStripMenuItem.Text = "Hash";
            this.hashToolStripMenuItem.Click += new System.EventHandler(this.hashToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(13, 1225);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1207, 26);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            this.progressBar.Value = 50;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 30);
            this.toolStripMenuItem1.Text = "Launch";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(753, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(201, 67);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // candidateButton
            // 
            this.candidateButton.Location = new System.Drawing.Point(973, 13);
            this.candidateButton.Name = "candidateButton";
            this.candidateButton.Size = new System.Drawing.Size(195, 67);
            this.candidateButton.TabIndex = 6;
            this.candidateButton.Text = "Candidates";
            this.candidateButton.UseVisualStyleBackColor = true;
            this.candidateButton.Click += new System.EventHandler(this.candidateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 1263);
            this.Controls.Add(this.candidateButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resultsView);
            this.Controls.Add(this.start);
            this.Controls.Add(this.src2);
            this.Controls.Add(this.src1);
            this.Name = "MainForm";
            this.Text = "Dupe Finder";
            ((System.ComponentModel.ISupportInitialize)(this.resultsView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox src1;
        private System.Windows.Forms.TextBox src2;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.DataGridView resultsView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hash1MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button candidateButton;
    }
}

