namespace RainbowStudio.Forms
{
    partial class Trajectory
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
            trajectoryGv = new DataGridView();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            spectrumGv = new DataGridView();
            k = new DataGridViewTextBoxColumn();
            Real = new DataGridViewTextBoxColumn();
            Imaginary = new DataGridViewTextBoxColumn();
            A = new DataGridViewTextBoxColumn();
            φ = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)trajectoryGv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spectrumGv).BeginInit();
            SuspendLayout();
            // 
            // trajectoryGv
            // 
            trajectoryGv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            trajectoryGv.Dock = DockStyle.Fill;
            trajectoryGv.Location = new Point(0, 0);
            trajectoryGv.Name = "trajectoryGv";
            trajectoryGv.RowHeadersWidth = 51;
            trajectoryGv.RowTemplate.Height = 29;
            trajectoryGv.Size = new Size(504, 426);
            trajectoryGv.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(trajectoryGv);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(989, 426);
            splitContainer1.SplitterDistance = 504;
            splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox1);
            splitContainer2.Size = new Size(481, 426);
            splitContainer2.SplitterDistance = 232;
            splitContainer2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(spectrumGv);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(481, 232);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Spectrum";
            // 
            // spectrumGv
            // 
            spectrumGv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            spectrumGv.Columns.AddRange(new DataGridViewColumn[] { k, Real, Imaginary, A, φ });
            spectrumGv.Dock = DockStyle.Top;
            spectrumGv.Location = new Point(3, 23);
            spectrumGv.Name = "spectrumGv";
            spectrumGv.RowHeadersWidth = 51;
            spectrumGv.RowTemplate.Height = 29;
            spectrumGv.Size = new Size(475, 206);
            spectrumGv.TabIndex = 0;
            spectrumGv.RowEnter += spectrumGv_RowEnter;
            // 
            // k
            // 
            k.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            k.HeaderText = "k";
            k.MinimumWidth = 6;
            k.Name = "k";
            k.ReadOnly = true;
            k.Width = 45;
            // 
            // Real
            // 
            Real.HeaderText = "Real";
            Real.MinimumWidth = 6;
            Real.Name = "Real";
            Real.ReadOnly = true;
            Real.SortMode = DataGridViewColumnSortMode.NotSortable;
            Real.Width = 44;
            // 
            // Imaginary
            // 
            Imaginary.HeaderText = "Imaginary";
            Imaginary.MinimumWidth = 6;
            Imaginary.Name = "Imaginary";
            Imaginary.ReadOnly = true;
            Imaginary.SortMode = DataGridViewColumnSortMode.NotSortable;
            Imaginary.Width = 81;
            // 
            // A
            // 
            A.HeaderText = "A";
            A.MinimumWidth = 6;
            A.Name = "A";
            A.ReadOnly = true;
            A.SortMode = DataGridViewColumnSortMode.NotSortable;
            A.Width = 125;
            // 
            // φ
            // 
            φ.HeaderText = "φ";
            φ.MinimumWidth = 6;
            φ.Name = "φ";
            φ.ReadOnly = true;
            φ.SortMode = DataGridViewColumnSortMode.NotSortable;
            φ.Width = 125;
            // 
            // Trajectory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 426);
            Controls.Add(splitContainer1);
            Name = "Trajectory";
            Text = "Trajectory";
            ((System.ComponentModel.ISupportInitialize)trajectoryGv).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spectrumGv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView trajectoryGv;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private DataGridView spectrumGv;
        private SplitContainer splitContainer2;
        private DataGridViewTextBoxColumn k;
        private DataGridViewTextBoxColumn Real;
        private DataGridViewTextBoxColumn Imaginary;
        private DataGridViewTextBoxColumn A;
        private DataGridViewTextBoxColumn φ;
    }
}