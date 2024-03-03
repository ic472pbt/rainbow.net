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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            StructureDg = new DataGridView();
            groupBox3 = new GroupBox();
            x2Bt = new Button();
            AddToInputsBt = new Button();
            NodeNameTb = new TextBox();
            label1 = new Label();
            listBox1 = new ListBox();
            SolveBt = new Button();
            groupBox2 = new GroupBox();
            DrainLb = new ListBox();
            groupBox1 = new GroupBox();
            MatrixDg = new DataGridView();
            toolTip1 = new ToolTip(components);
            AddStarBt = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StructureDg).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MatrixDg).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(groupBox3);
            splitContainer1.Panel2.Controls.Add(listBox1);
            splitContainer1.Panel2.Controls.Add(SolveBt);
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1000, 450);
            splitContainer1.SplitterDistance = 190;
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
            StructureDg.Size = new Size(1000, 190);
            StructureDg.TabIndex = 0;
            StructureDg.SelectionChanged += StructureDg_SelectionChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(AddStarBt);
            groupBox3.Controls.Add(x2Bt);
            groupBox3.Controls.Add(AddToInputsBt);
            groupBox3.Controls.Add(NodeNameTb);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(535, 58);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(143, 186);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Create node";
            // 
            // x2Bt
            // 
            x2Bt.Enabled = false;
            x2Bt.Location = new Point(6, 114);
            x2Bt.Name = "x2Bt";
            x2Bt.Size = new Size(131, 29);
            x2Bt.TabIndex = 4;
            x2Bt.Text = "Mixing";
            toolTip1.SetToolTip(x2Bt, "Move frequencies");
            x2Bt.UseVisualStyleBackColor = true;
            x2Bt.Click += x2Bt_Click;
            // 
            // AddToInputsBt
            // 
            AddToInputsBt.Enabled = false;
            AddToInputsBt.Location = new Point(6, 79);
            AddToInputsBt.Name = "AddToInputsBt";
            AddToInputsBt.Size = new Size(131, 29);
            AddToInputsBt.TabIndex = 2;
            AddToInputsBt.Text = "Annihilating";
            AddToInputsBt.UseVisualStyleBackColor = true;
            AddToInputsBt.Click += AddToInputsBt_Click;
            // 
            // NodeNameTb
            // 
            NodeNameTb.Location = new Point(6, 46);
            NodeNameTb.Name = "NodeNameTb";
            NodeNameTb.Size = new Size(131, 27);
            NodeNameTb.TabIndex = 1;
            NodeNameTb.TextChanged += NodeNameTb_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(684, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(173, 244);
            listBox1.TabIndex = 2;
            // 
            // SolveBt
            // 
            SolveBt.Enabled = false;
            SolveBt.Location = new Point(535, 23);
            SolveBt.Name = "SolveBt";
            SolveBt.Size = new Size(143, 29);
            SolveBt.TabIndex = 1;
            SolveBt.Text = "Solve SLE";
            SolveBt.UseVisualStyleBackColor = true;
            SolveBt.Click += SolveBt_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DrainLb);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(347, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(182, 256);
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
            DrainLb.Size = new Size(176, 230);
            DrainLb.TabIndex = 0;
            DrainLb.SelectedIndexChanged += DrainLb_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(MatrixDg);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 256);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Energy sources";
            // 
            // MatrixDg
            // 
            MatrixDg.AllowUserToAddRows = false;
            MatrixDg.AllowUserToDeleteRows = false;
            MatrixDg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MatrixDg.Dock = DockStyle.Fill;
            MatrixDg.Location = new Point(3, 23);
            MatrixDg.Name = "MatrixDg";
            MatrixDg.ReadOnly = true;
            MatrixDg.RowHeadersWidth = 51;
            MatrixDg.RowTemplate.Height = 29;
            MatrixDg.Size = new Size(341, 230);
            MatrixDg.TabIndex = 1;
            // 
            // AddStarBt
            // 
            AddStarBt.Enabled = false;
            AddStarBt.Location = new Point(6, 151);
            AddStarBt.Name = "AddStarBt";
            AddStarBt.Size = new Size(131, 29);
            AddStarBt.TabIndex = 5;
            AddStarBt.Text = "Star";
            AddStarBt.UseVisualStyleBackColor = true;
            AddStarBt.Click += AddStarBt_Click;
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StructureDg).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MatrixDg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView StructureDg;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox DrainLb;
        private DataGridView MatrixDg;
        private Button SolveBt;
        private ListBox listBox1;
        private GroupBox groupBox3;
        private Button AddToInputsBt;
        private TextBox NodeNameTb;
        private Label label1;
        private Button x2Bt;
        private ToolTip toolTip1;
        private Button AddStarBt;
    }
}