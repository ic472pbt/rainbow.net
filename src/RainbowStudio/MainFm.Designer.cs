namespace RainbowStudio
{
    partial class MainFm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newTimeSeriesToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            ImportCSVmi = new ToolStripMenuItem();
            OpenCSVfd = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newTimeSeriesToolStripMenuItem, ImportCSVmi });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newTimeSeriesToolStripMenuItem
            // 
            newTimeSeriesToolStripMenuItem.Name = "newTimeSeriesToolStripMenuItem";
            newTimeSeriesToolStripMenuItem.Size = new Size(200, 26);
            newTimeSeriesToolStripMenuItem.Text = "New &Time series";
            newTimeSeriesToolStripMenuItem.Click += newTimeSeriesToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // ImportCSVmi
            // 
            ImportCSVmi.Name = "ImportCSVmi";
            ImportCSVmi.Size = new Size(200, 26);
            ImportCSVmi.Text = "&Import CSV";
            ImportCSVmi.Click += ImportCSVmi_Click;
            // 
            // OpenCSVfd
            // 
            OpenCSVfd.Filter = "csv|*.csv|All files|*.*";
            // 
            // MainFm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainFm";
            Text = "Rainbow Studio";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newTimeSeriesToolStripMenuItem;
        private ToolStripMenuItem ImportCSVmi;
        private OpenFileDialog OpenCSVfd;
    }
}