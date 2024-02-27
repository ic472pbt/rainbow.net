namespace RainbowStudio.Forms
{
    partial class Constructor
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
            splitContainer1 = new SplitContainer();
            StructureDg = new DataGridView();
            groupBox2 = new GroupBox();
            DrainLb = new ListBox();
            groupBox1 = new GroupBox();
            SourceList = new ListBox();
            DrainConstantCb = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StructureDg).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(StructureDg);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DrainConstantCb);
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1000, 450);
            splitContainer1.SplitterDistance = 249;
            splitContainer1.TabIndex = 0;
            // 
            // StructureDg
            // 
            StructureDg.AllowUserToAddRows = false;
            StructureDg.AllowUserToDeleteRows = false;
            StructureDg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StructureDg.Dock = DockStyle.Fill;
            StructureDg.Location = new Point(0, 0);
            StructureDg.Name = "StructureDg";
            StructureDg.ReadOnly = true;
            StructureDg.RowHeadersWidth = 51;
            StructureDg.RowTemplate.Height = 29;
            StructureDg.Size = new Size(1000, 249);
            StructureDg.TabIndex = 0;
            StructureDg.RowEnter += StructureDg_RowEnter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DrainLb);
            groupBox2.Location = new Point(332, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(321, 191);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Energy drain";
            // 
            // DrainLb
            // 
            DrainLb.Dock = DockStyle.Fill;
            DrainLb.FormattingEnabled = true;
            DrainLb.ItemHeight = 20;
            DrainLb.Location = new Point(3, 23);
            DrainLb.Name = "DrainLb";
            DrainLb.Size = new Size(315, 165);
            DrainLb.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(SourceList);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(314, 191);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Energy sources";
            // 
            // SourceList
            // 
            SourceList.Dock = DockStyle.Fill;
            SourceList.FormattingEnabled = true;
            SourceList.ItemHeight = 20;
            SourceList.Location = new Point(3, 23);
            SourceList.Name = "SourceList";
            SourceList.SelectionMode = SelectionMode.MultiSimple;
            SourceList.Size = new Size(308, 165);
            SourceList.TabIndex = 0;
            SourceList.SelectedIndexChanged += SourceList_SelectedIndexChanged;
            // 
            // DrainConstantCb
            // 
            DrainConstantCb.AutoSize = true;
            DrainConstantCb.Location = new Point(671, 26);
            DrainConstantCb.Name = "DrainConstantCb";
            DrainConstantCb.Size = new Size(189, 24);
            DrainConstantCb.TabIndex = 1;
            DrainConstantCb.Text = "Drain constant to target";
            DrainConstantCb.UseVisualStyleBackColor = true;
            // 
            // Constructor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(splitContainer1);
            Name = "Constructor";
            Text = "Constructor";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StructureDg).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView StructureDg;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox DrainLb;
        private ListBox SourceList;
        private CheckBox DrainConstantCb;
    }
}