namespace RainbowStudio
{
    partial class OneD_conv
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
            tabControl1 = new TabControl();
            RawPlotTP = new TabPage();
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            LowFreqBt = new Button();
            HifhFreqBt = new Button();
            OutputsLV = new ListView();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            GenerateConvBt = new Button();
            WindowNud = new NumericUpDown();
            label1 = new Label();
            InputsLV = new ListView();
            tabPage2 = new TabPage();
            splitContainer2 = new SplitContainer();
            OutputsListCb = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            BuildSetBt = new Button();
            SampleSizeNud = new NumericUpDown();
            SamplesDg = new DataGridView();
            tabPage1 = new TabPage();
            splitContainer3 = new SplitContainer();
            groupBox5 = new GroupBox();
            TargetRainbowDg = new DataGridView();
            k = new DataGridViewTextBoxColumn();
            Fourier = new DataGridViewTextBoxColumn();
            Magnitude = new DataGridViewTextBoxColumn();
            Phase = new DataGridViewTextBoxColumn();
            Energy = new DataGridViewTextBoxColumn();
            groupBox6 = new GroupBox();
            splitContainer4 = new SplitContainer();
            OpenConstructorBt = new Button();
            SubnetsDg = new DataGridView();
            tabControl1.SuspendLayout();
            RawPlotTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WindowNud).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SampleSizeNud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SamplesDg).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TargetRainbowDg).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SubnetsDg).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(RawPlotTP);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // RawPlotTP
            // 
            RawPlotTP.Controls.Add(splitContainer1);
            RawPlotTP.Location = new Point(4, 29);
            RawPlotTP.Name = "RawPlotTP";
            RawPlotTP.Padding = new Padding(3);
            RawPlotTP.Size = new Size(792, 417);
            RawPlotTP.TabIndex = 0;
            RawPlotTP.Text = "Raw/Plot";
            RawPlotTP.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(786, 411);
            splitContainer1.SplitterDistance = 233;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(OutputsLV);
            groupBox2.Location = new Point(390, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(370, 227);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Outputs";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(LowFreqBt);
            groupBox4.Controls.Add(HifhFreqBt);
            groupBox4.Location = new Point(160, 23);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(204, 104);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Group encoding transform";
            // 
            // LowFreqBt
            // 
            LowFreqBt.Enabled = false;
            LowFreqBt.Location = new Point(6, 67);
            LowFreqBt.Name = "LowFreqBt";
            LowFreqBt.Size = new Size(192, 29);
            LowFreqBt.TabIndex = 0;
            LowFreqBt.Text = "LOW freq encoding";
            LowFreqBt.UseVisualStyleBackColor = true;
            LowFreqBt.Click += LowFreqBt_Click;
            // 
            // HifhFreqBt
            // 
            HifhFreqBt.Enabled = false;
            HifhFreqBt.Location = new Point(6, 32);
            HifhFreqBt.Name = "HifhFreqBt";
            HifhFreqBt.Size = new Size(192, 29);
            HifhFreqBt.TabIndex = 0;
            HifhFreqBt.Text = "HIGH freq encoding";
            HifhFreqBt.UseVisualStyleBackColor = true;
            // 
            // OutputsLV
            // 
            OutputsLV.Location = new Point(3, 23);
            OutputsLV.Name = "OutputsLV";
            OutputsLV.Size = new Size(151, 201);
            OutputsLV.TabIndex = 1;
            OutputsLV.UseCompatibleStateImageBehavior = false;
            OutputsLV.View = View.List;
            OutputsLV.ItemSelectionChanged += OutputsLV_ItemSelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(InputsLV);
            groupBox1.Location = new Point(5, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 227);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Inputs";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(GenerateConvBt);
            groupBox3.Controls.Add(WindowNud);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(196, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(177, 104);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Trajectory/Convolution";
            // 
            // GenerateConvBt
            // 
            GenerateConvBt.Enabled = false;
            GenerateConvBt.Location = new Point(6, 65);
            GenerateConvBt.Name = "GenerateConvBt";
            GenerateConvBt.Size = new Size(165, 29);
            GenerateConvBt.TabIndex = 2;
            GenerateConvBt.Text = "Generate";
            GenerateConvBt.UseVisualStyleBackColor = true;
            GenerateConvBt.Click += GenerateConvBt_Click;
            // 
            // WindowNud
            // 
            WindowNud.Location = new Point(76, 32);
            WindowNud.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            WindowNud.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            WindowNud.Name = "WindowNud";
            WindowNud.Size = new Size(71, 27);
            WindowNud.TabIndex = 1;
            WindowNud.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Window";
            // 
            // InputsLV
            // 
            InputsLV.Location = new Point(3, 23);
            InputsLV.Name = "InputsLV";
            InputsLV.Size = new Size(187, 201);
            InputsLV.TabIndex = 0;
            InputsLV.UseCompatibleStateImageBehavior = false;
            InputsLV.View = View.List;
            InputsLV.ItemSelectionChanged += InputsLV_ItemSelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Training set";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(OutputsListCb);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(BuildSetBt);
            splitContainer2.Panel1.Controls.Add(SampleSizeNud);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(SamplesDg);
            splitContainer2.Size = new Size(786, 411);
            splitContainer2.SplitterDistance = 62;
            splitContainer2.TabIndex = 3;
            // 
            // OutputsListCb
            // 
            OutputsListCb.DropDownStyle = ComboBoxStyle.DropDownList;
            OutputsListCb.FormattingEnabled = true;
            OutputsListCb.Location = new Point(281, 12);
            OutputsListCb.Name = "OutputsListCb";
            OutputsListCb.Size = new Size(151, 28);
            OutputsListCb.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 15);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 3;
            label3.Text = "In respect of";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 15);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 0;
            label2.Text = "Sample size";
            // 
            // BuildSetBt
            // 
            BuildSetBt.Location = new Point(441, 11);
            BuildSetBt.Name = "BuildSetBt";
            BuildSetBt.Size = new Size(94, 29);
            BuildSetBt.TabIndex = 2;
            BuildSetBt.Text = "Build set";
            BuildSetBt.UseVisualStyleBackColor = true;
            BuildSetBt.Click += BuildSetBt_Click;
            // 
            // SampleSizeNud
            // 
            SampleSizeNud.Location = new Point(97, 13);
            SampleSizeNud.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            SampleSizeNud.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            SampleSizeNud.Name = "SampleSizeNud";
            SampleSizeNud.Size = new Size(81, 27);
            SampleSizeNud.TabIndex = 1;
            SampleSizeNud.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // SamplesDg
            // 
            SamplesDg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SamplesDg.Dock = DockStyle.Fill;
            SamplesDg.Location = new Point(0, 0);
            SamplesDg.Name = "SamplesDg";
            SamplesDg.RowHeadersWidth = 51;
            SamplesDg.RowTemplate.Height = 29;
            SamplesDg.Size = new Size(786, 345);
            SamplesDg.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer3);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 417);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Modeling";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 3);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(groupBox5);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(groupBox6);
            splitContainer3.Size = new Size(786, 411);
            splitContainer3.SplitterDistance = 262;
            splitContainer3.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(TargetRainbowDg);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(0, 0);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(262, 411);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Target rainbow";
            // 
            // TargetRainbowDg
            // 
            TargetRainbowDg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TargetRainbowDg.Columns.AddRange(new DataGridViewColumn[] { k, Fourier, Magnitude, Phase, Energy });
            TargetRainbowDg.Dock = DockStyle.Fill;
            TargetRainbowDg.Location = new Point(3, 23);
            TargetRainbowDg.Name = "TargetRainbowDg";
            TargetRainbowDg.RowHeadersWidth = 51;
            TargetRainbowDg.RowTemplate.Height = 29;
            TargetRainbowDg.Size = new Size(256, 385);
            TargetRainbowDg.TabIndex = 0;
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
            // Fourier
            // 
            Fourier.HeaderText = "Fourier";
            Fourier.MinimumWidth = 6;
            Fourier.Name = "Fourier";
            Fourier.ReadOnly = true;
            Fourier.Width = 125;
            // 
            // Magnitude
            // 
            Magnitude.HeaderText = "Magnitude";
            Magnitude.MinimumWidth = 6;
            Magnitude.Name = "Magnitude";
            Magnitude.ReadOnly = true;
            Magnitude.Width = 125;
            // 
            // Phase
            // 
            Phase.HeaderText = "Phase";
            Phase.MinimumWidth = 6;
            Phase.Name = "Phase";
            Phase.ReadOnly = true;
            Phase.Width = 125;
            // 
            // Energy
            // 
            Energy.HeaderText = "% Energy";
            Energy.MinimumWidth = 6;
            Energy.Name = "Energy";
            Energy.ReadOnly = true;
            Energy.Width = 125;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(splitContainer4);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(0, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(520, 411);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Subnets/Colors";
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.FixedPanel = FixedPanel.Panel1;
            splitContainer4.Location = new Point(3, 23);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(OpenConstructorBt);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(SubnetsDg);
            splitContainer4.Size = new Size(514, 385);
            splitContainer4.SplitterDistance = 55;
            splitContainer4.TabIndex = 0;
            // 
            // OpenConstructorBt
            // 
            OpenConstructorBt.Location = new Point(12, 13);
            OpenConstructorBt.Name = "OpenConstructorBt";
            OpenConstructorBt.Size = new Size(201, 29);
            OpenConstructorBt.TabIndex = 0;
            OpenConstructorBt.Text = "Open constructor";
            OpenConstructorBt.UseVisualStyleBackColor = true;
            OpenConstructorBt.Click += OpenConstructorBt_Click;
            // 
            // SubnetsDg
            // 
            SubnetsDg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SubnetsDg.Dock = DockStyle.Fill;
            SubnetsDg.Location = new Point(0, 0);
            SubnetsDg.Name = "SubnetsDg";
            SubnetsDg.RowHeadersWidth = 51;
            SubnetsDg.RowTemplate.Height = 29;
            SubnetsDg.Size = new Size(514, 326);
            SubnetsDg.TabIndex = 0;
            // 
            // OneD_conv
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "OneD_conv";
            Text = "1D convolution";
            tabControl1.ResumeLayout(false);
            RawPlotTP.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WindowNud).EndInit();
            tabPage2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SampleSizeNud).EndInit();
            ((System.ComponentModel.ISupportInitialize)SamplesDg).EndInit();
            tabPage1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TargetRainbowDg).EndInit();
            groupBox6.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SubnetsDg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage RawPlotTP;
        private TabPage tabPage2;
        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private ListView OutputsLV;
        private GroupBox groupBox1;
        private ListView InputsLV;
        private GroupBox groupBox3;
        private Button GenerateConvBt;
        private NumericUpDown WindowNud;
        private Label label1;
        private GroupBox groupBox4;
        private Button LowFreqBt;
        private Button HifhFreqBt;
        private NumericUpDown SampleSizeNud;
        private Label label2;
        private SplitContainer splitContainer2;
        private Button BuildSetBt;
        private DataGridView SamplesDg;
        private ComboBox OutputsListCb;
        private Label label3;
        private TabPage tabPage1;
        private SplitContainer splitContainer3;
        private GroupBox groupBox5;
        private DataGridView TargetRainbowDg;
        private DataGridViewTextBoxColumn k;
        private DataGridViewTextBoxColumn Fourier;
        private DataGridViewTextBoxColumn Magnitude;
        private DataGridViewTextBoxColumn Phase;
        private DataGridViewTextBoxColumn Energy;
        private GroupBox groupBox6;
        private SplitContainer splitContainer4;
        private Button OpenConstructorBt;
        private DataGridView SubnetsDg;
    }
}