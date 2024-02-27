using Rainbow.NET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using MathNet.Numerics.LinearAlgebra;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Microsoft.FSharp.Core;

namespace RainbowStudio.Forms
{
    public partial class Constructor : Form
    {
        private readonly Model model;
        private readonly Dictionary<string, Signal> inputSignals;
        private readonly Signal outputSignal;
        private readonly string OutputName;

        private int CurrentK = 0;
        public Constructor(Model model, Dictionary<string, Signal> inputSignals, Signal outputSignal, string OutputName, int Length)
        {
            InitializeComponent();

            this.model = model;
            this.inputSignals = inputSignals;
            this.outputSignal = outputSignal;
            this.OutputName = OutputName;

            int N = Length / 2 + 1;
            StructureDg.Columns.Add(new DataGridViewTextBoxColumn() { Name = "k", HeaderText = "k", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            StructureDg.Rows.Add(N);
            for (int i = 0; i < N; i++) { StructureDg.Rows[i].Cells["k"].Value = i; }
            foreach (var item in inputSignals)
            {
                StructureDg.Columns.Add(new DataGridViewTextBoxColumn() { Name = item.Key, HeaderText = item.Key, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
                for (int i = 0; i < N; i++)
                {
                    var wave = item.Value.TryGetWave(i);
                    StructureDg.Rows[i].Cells[item.Key].Value = wave.Value.C;
                }
            }
        }

        //private void SourceList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DrainConstantCb.Checked)
        //    {

        //}

        // Construct the X matrix as a DataGridView table
        private void StructureDg_SelectionChanged(object sender, EventArgs e)
        {
            MatrixDg.Rows.Clear();
            MatrixDg.Columns.Clear();

            if (StructureDg.SelectedCells.Count == 0) return;
            var ColumnIndexes =
                StructureDg.
                    SelectedCells.
                    OfType<DataGridViewTextBoxCell>().
                    Select(c => c.ColumnIndex).
                    Where(c => c > 0).
                    Distinct();
            foreach (int idx in ColumnIndexes) MatrixDg.Columns.Add(StructureDg.Columns[idx].Name, StructureDg.Columns[idx].Name);
            if (!ColumnIndexes.Any()) return;

            var SelectedDC =
                StructureDg.
                    SelectedCells.
                    OfType<DataGridViewTextBoxCell>().
                    Where(c => c.ColumnIndex > 0).
                    Any(c => c.RowIndex == 0);

            // Load Matrix data
            int InnerIndexStart = 0;
            if (SelectedDC)
            {
                InnerIndexStart = 1;
                int dcRowIndex = MatrixDg.Rows.Add(1);
                foreach (int j in ColumnIndexes)
                {
                    MatrixDg.Rows[dcRowIndex].Cells[StructureDg.Columns[j].Name].Value = ((Complex)StructureDg.Rows[0].Cells[j].Value).Real;
                    // k reference
                    MatrixDg.Rows[dcRowIndex].Tag = 0;
                }
            }

            var RowIndexes =
                StructureDg.
                    SelectedCells.
                    OfType<DataGridViewTextBoxCell>().
                    Where(c => c.RowIndex > 0 && c.ColumnIndex > 0). // 
                    Select(c => c.RowIndex).
                    Distinct();
            if (RowIndexes.Any()) MatrixDg.Rows.Add(2 * RowIndexes.Count());

            foreach (int j in ColumnIndexes)
            {
                foreach (int i in RowIndexes)
                {
                    int innerI = InnerIndexStart;
                    MatrixDg.Rows[2 * innerI - InnerIndexStart].Cells[StructureDg.Columns[j].Name].Value = ((Complex)StructureDg.Rows[i].Cells[j].Value).Real;
                    MatrixDg.Rows[2 * innerI + 1 - InnerIndexStart].Cells[StructureDg.Columns[j].Name].Value = ((Complex)StructureDg.Rows[i].Cells[j].Value).Imaginary;
                    // k reference
                    MatrixDg.Rows[2 * innerI - InnerIndexStart].Tag = i;
                    MatrixDg.Rows[2 * innerI + 1 - InnerIndexStart].Tag = i;
                    innerI++;
                }
            }

            // Load drainage
            DrainLb.Items.Clear();
            DrainLb.Items.Add(OutputName);
            var AvailableTargetImputs =
                StructureDg.
                    Columns.
                    OfType<DataGridViewTextBoxColumn>().
                    Where(c => c.Index > 0).
                    Select(c => c.Index).
                    Except(ColumnIndexes);
            foreach (int i in AvailableTargetImputs) DrainLb.Items.Add(StructureDg.Columns[i].Name);

            ToggleSolveBtEnabled();
        }

        void ToggleSolveBtEnabled()
        {
            SolveBt.Enabled =
                DrainLb.SelectedItems.Count > 0 &&
                MatrixDg.Rows.Count == MatrixDg.Columns.Count;
        }

        private void DrainLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleSolveBtEnabled();
        }

        private void SolveBt_Click(object sender, EventArgs e)
        {
            double[,] A = new double[MatrixDg.Rows.Count, MatrixDg.Columns.Count];
            for (int i = 0; i <= A.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= A.GetUpperBound(1); j++)
                {
                    A[i, j] = (double)MatrixDg.Rows[i].Cells[j].Value;
                }
            }
            var X = Matrix<double>.Build.DenseOfArray(A);
            List<double> bList = new();
            List<int> Blocks = new();
            FSharpOption<Wave> wave;
            Complex C = new();
            foreach (DataGridViewRow row in MatrixDg.Rows)
            {
                if (row.Tag is not null && !Blocks.Contains((int)row.Tag))
                {
                    if (inputSignals.ContainsKey((string)DrainLb.SelectedItem))
                    {
                        wave = inputSignals[(string)DrainLb.SelectedItem].TryGetWave((int)row.Tag);
                        if (wave.Value is not null) C = wave.Value.C; else C = 0.0;
                    }
                    else
                    {
                        wave = outputSignal.TryGetWave((int)row.Tag);
                        if (wave.Value is not null) C = wave.Value.C; else C = 0.0;
                    }
                    if ((int)row.Tag == 0)
                    {
                        bList.Add(C.Real);
                        Blocks.Add(0);
                    }
                    else
                    {
                        bList.Add(C.Real);
                        bList.Add(C.Imaginary);
                        Blocks.Add((int)row.Tag);
                    }

                }
            }
            var b =
                MathNet.Numerics.LinearAlgebra.
                    Vector<double>.Build.Dense(bList.ToArray());
            try
            {
                var Y = X.Solve(b);
                listBox1.Items.Clear();
                foreach (double item in Y) listBox1.Items.Add(item);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
