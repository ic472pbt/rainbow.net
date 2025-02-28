using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rainbow.NET;
using System.Windows.Forms.DataVisualization.Charting;

namespace RainbowStudio.Forms
{
    public partial class Trajectory : Form
    {
        private int convolutionWindow;
        private double[] X = new double[1];
        private Series series;
        public double[] x
        {
            set
            {
                X = value;

                for (int c = 0; c < convolutionWindow; c++)
                {
                    string columnName = $"X{c}";
                    trajectoryGv.Columns.Add(columnName, columnName);
                }
                trajectoryGv.Rows.Add(value.Length);

                for (int c = 0; c < convolutionWindow; c++)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        trajectoryGv.Rows[i].Cells[c].Value = value[(i + c) % value.Length];
                    }
                }
                CalculateFourier();
            }
        }
        public Trajectory(int window)
        {
            InitializeComponent();
            convolutionWindow = window;
        }

        private void CalculateFourier()
        {
            var signal = new Harmonics(X);
            // add phase shifts for future columns
            for (int c = 2; c <= convolutionWindow; c++)
            {
                string columnName = $"X{c} +φ";
                int idx = spectrumGv.Columns.Add(columnName, columnName);
                spectrumGv.Columns[idx].ToolTipText = "Phase shift relative to X1";
            }

            Chart chart = new() { Dock = DockStyle.Fill };
            chart.ChartAreas.Add("chart1");
            series = chart.Series.Add("plot 1");
            series.MarkerStyle = MarkerStyle.Circle;
            series.ChartType = SeriesChartType.Polar;
            series.BorderWidth = 3;
            splitContainer2.Panel2.Controls.Add(chart);

            spectrumGv.Rows.Add(X.Length / 2);
            for (int k = 0; k <= X.Length / 2; k++)
            {
                // DFT calculated here
                var wave = signal.Dft[k];
                {
                    var waveVal = wave;
                    spectrumGv.Rows[k].Cells["k"].Value = k;
                    spectrumGv.Rows[k].Cells["Real"].Value = waveVal.Real;
                    spectrumGv.Rows[k].Cells["Imaginary"].Value = waveVal.Imaginary;
                    spectrumGv.Rows[k].Cells["A"].Value = waveVal.Magnitude;
                    spectrumGv.Rows[k].Cells["φ"].Value = waveVal.Phase;
                    for (int c = 1; c < convolutionWindow; c++)
                    {
                        spectrumGv.Rows[k].Cells[4 + c].Value = waveVal.Phase + c * signal.Omega.Invoke(k);
                    }
                }
            }
        }

        private void spectrumGv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int k = e.RowIndex;
                series.Points.Clear();
                series.Points.AddXY((double)spectrumGv.Rows[k].Cells["φ"].Value * 180.0 / Math.PI, 1);
                for (int c = 1; c < convolutionWindow; c++)
                {
                    series.Points.AddXY(0,0);
                    int p = series.Points.AddXY((double)spectrumGv.Rows[k].Cells[4 + c].Value * 180.0 / Math.PI, 1);
                    series.Points[p].Label = c.ToString();
                }
            }
        }
    }
}
