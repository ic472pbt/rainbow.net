namespace RainbowStudio.Forms
{
    partial class NewTS
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
            timeSeriesGv = new DataGridView();
            X = new DataGridViewTextBoxColumn();
            toTrajectoryBt = new Button();
            label1 = new Label();
            convolutionWindowNud = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)timeSeriesGv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)convolutionWindowNud).BeginInit();
            SuspendLayout();
            // 
            // timeSeriesGv
            // 
            timeSeriesGv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            timeSeriesGv.Columns.AddRange(new DataGridViewColumn[] { X });
            timeSeriesGv.Dock = DockStyle.Left;
            timeSeriesGv.Location = new Point(0, 0);
            timeSeriesGv.Name = "timeSeriesGv";
            timeSeriesGv.RowHeadersWidth = 51;
            timeSeriesGv.RowTemplate.Height = 29;
            timeSeriesGv.Size = new Size(201, 384);
            timeSeriesGv.TabIndex = 0;
            timeSeriesGv.CellValidating += timeSeriesGv_CellValidating;
            // 
            // X
            // 
            X.HeaderText = "X";
            X.MinimumWidth = 6;
            X.Name = "X";
            X.Width = 125;
            // 
            // toTrajectoryBt
            // 
            toTrajectoryBt.Location = new Point(458, 26);
            toTrajectoryBt.Name = "toTrajectoryBt";
            toTrajectoryBt.Size = new Size(110, 29);
            toTrajectoryBt.TabIndex = 1;
            toTrajectoryBt.Text = "To trajectory";
            toTrajectoryBt.UseVisualStyleBackColor = true;
            toTrajectoryBt.Click += toTrajectoryBt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 30);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 2;
            label1.Text = "Convolution window size";
            // 
            // convolutionWindowNud
            // 
            convolutionWindowNud.Location = new Point(387, 28);
            convolutionWindowNud.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            convolutionWindowNud.Name = "convolutionWindowNud";
            convolutionWindowNud.Size = new Size(65, 27);
            convolutionWindowNud.TabIndex = 3;
            convolutionWindowNud.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // NewTS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 384);
            Controls.Add(convolutionWindowNud);
            Controls.Add(label1);
            Controls.Add(toTrajectoryBt);
            Controls.Add(timeSeriesGv);
            Name = "NewTS";
            Text = "Time series";
            ((System.ComponentModel.ISupportInitialize)timeSeriesGv).EndInit();
            ((System.ComponentModel.ISupportInitialize)convolutionWindowNud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView timeSeriesGv;
        private DataGridViewTextBoxColumn X;
        private Button toTrajectoryBt;
        private Label label1;
        private NumericUpDown convolutionWindowNud;
    }
}