namespace VFSRoseOnline
{
    partial class Form1
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
            this.treeViewVFS = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.treeViewLoadingProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.treeViewLoadedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TreeViewPanel = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.TreeViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewVFS
            // 
            this.treeViewVFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewVFS.Location = new System.Drawing.Point(0, 0);
            this.treeViewVFS.Name = "treeViewVFS";
            this.treeViewVFS.PathSeparator = "\\\\";
            this.treeViewVFS.Size = new System.Drawing.Size(362, 488);
            this.treeViewVFS.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeViewLoadingProgressBar,
            this.treeViewLoadedStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(928, 28);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // treeViewLoadingProgressBar
            // 
            this.treeViewLoadingProgressBar.Name = "treeViewLoadingProgressBar";
            this.treeViewLoadingProgressBar.Size = new System.Drawing.Size(200, 20);
            // 
            // treeViewLoadedStatusLabel
            // 
            this.treeViewLoadedStatusLabel.Name = "treeViewLoadedStatusLabel";
            this.treeViewLoadedStatusLabel.Size = new System.Drawing.Size(151, 22);
            this.treeViewLoadedStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // TreeViewPanel
            // 
            this.TreeViewPanel.Controls.Add(this.treeViewVFS);
            this.TreeViewPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeViewPanel.Location = new System.Drawing.Point(0, 0);
            this.TreeViewPanel.Name = "TreeViewPanel";
            this.TreeViewPanel.Size = new System.Drawing.Size(362, 488);
            this.TreeViewPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 516);
            this.Controls.Add(this.TreeViewPanel);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VFS File Reader/Writer (From: Van Steenwegen Jim)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.TreeViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewVFS;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar treeViewLoadingProgressBar;
        private System.Windows.Forms.Panel TreeViewPanel;
        internal System.Windows.Forms.ToolStripStatusLabel treeViewLoadedStatusLabel;
    }
}

