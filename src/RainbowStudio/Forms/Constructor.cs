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

namespace RainbowStudio.Forms
{
    public partial class Constructor : Form
    {
        private readonly Model model;
        private readonly Dictionary<string, Signal> inputSignals;
        private readonly Signal outputSignal;

        private int CurrentK = 0;
        public Constructor(Model model, Dictionary<string, Signal> inputSignals, Signal outputSinal, int Length)
        {
            InitializeComponent();

            this.model = model;
            this.inputSignals = inputSignals;
            this.outputSignal = outputSinal;

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

        private void StructureDg_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CurrentK = (int)StructureDg.Rows[e.RowIndex].Cells["k"].Value;
            SourceList.Items.Clear();
            SourceList.Items.AddRange(
                StructureDg.
                    Rows[e.RowIndex].
                    Cells.
                    OfType<DataGridViewTextBoxCell>().
                    Skip(1).
                    Select(c => c.Value).
                    ToArray()
            );

            DrainLb.Items.Clear();
            DrainLb.Items.Add(outputSignal.TryGetWave(CurrentK).Value.C);
            DrainLb.Items.AddRange(
                StructureDg.
                    Rows[e.RowIndex].
                    Cells.
                    OfType<DataGridViewTextBoxCell>().
                    Skip(1).
                    Select(c => c.Value).
                    ToArray()
            );
        }

        private void SourceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrainConstantCb.Checked) {
                var A = Matrix<double>.Build.DenseOfArray(new double[,] {
                    {
                        ((Complex)SourceList.SelectedItems[0]).Real,
                        ((Complex)SourceList.SelectedItems[1]).Real,
                        ((Complex)SourceList.SelectedItems[2]).Real
                    },
                    {
                        ((Complex)SourceList.SelectedItems[0]).Imaginary,
                        ((Complex)SourceList.SelectedItems[1]).Imaginary,
                        ((Complex)SourceList.SelectedItems[2]).Imaginary
                    },
                    {
                        ((Complex)StructureDg.Rows[0].Cells[1].Value).Real,
                        ((Complex)StructureDg.Rows[0].Cells[2].Value).Real,
                        ((Complex)StructureDg.Rows[0].Cells[3].Value).Real
                    }
                });
                var wave = outputSignal.TryGetWave(CurrentK);
                var dc = outputSignal.TryGetWave(0);
                var b = 
                    MathNet.Numerics.LinearAlgebra.
                        Vector<double>.Build.Dense(new double[] 
                            { wave.Value.C.Real, wave.Value.C.Imaginary, dc.Value.C.Real }
                        );
                var X = A.Solve(b);
            }
        }
    }
}
