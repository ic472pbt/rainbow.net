using RainbowStudio.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Rainbow.NET;

namespace RainbowStudio
{
    public partial class OneD_conv : Form
    {
        private readonly Dictionary<string, List<double>> inputSeries;
        private readonly Dictionary<string, List<double>> outputSeries;
        private Dictionary<string, List<double>> sampleSeries = new();
        private List<double> selectedSeries = new();
        private readonly int N;
        private Model? model = null;
        private Signal? outputSignal;
        private string OutputName = string.Empty;
        private Dictionary<string, Signal> inputSignals = new();

        private readonly Chart chart;
        public OneD_conv(Dictionary<string, List<double>> inputSeries, Dictionary<string, List<double>> outputSeries)
        {
            InitializeComponent();

            this.outputSeries = outputSeries;
            this.inputSeries = inputSeries;
            N = inputSeries.Values.First().Count;

            InputsLV.Items.AddRange(inputSeries.Select(kv => new ListViewItem(kv.Key)).ToArray());
            OutputsLV.Items.AddRange(outputSeries.Select(kv => new ListViewItem(kv.Key)).ToArray());
            chart = new() { Dock = DockStyle.Fill };
            chart.ChartAreas.Add("chart1");
            splitContainer1.Panel2.Controls.Add(chart);
        }

        private void CreatePlot(Dictionary<string, List<double>> seriesData, AxisType axisType, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var series = chart.Series.Add(e.Item.Text);
                series.ChartType = SeriesChartType.Line;
                series.YAxisType = axisType;
                foreach (double value in seriesData[e.Item.Text])
                {
                    series.Points.Add(value);
                }
            }
            else
            {
                chart.Series.Remove(chart.Series[e.Item.Text]);
            }
        }
        private void InputsLV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            CreatePlot(inputSeries, AxisType.Primary, e);
            GenerateConvBt.Enabled =
                !InputsLV.SelectedItems.
                    OfType<ListViewItem>().
                    FirstOrDefault(new ListViewItem("+")).
                    Text.
                    Contains('+');
        }

        private void OutputsLV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            CreatePlot(outputSeries, AxisType.Secondary, e);
            HifhFreqBt.Enabled =
                !OutputsLV.SelectedItems.
                    OfType<ListViewItem>().
                    FirstOrDefault(new ListViewItem("+")).
                    Text.
                    Contains('+');
            LowFreqBt.Enabled = HifhFreqBt.Enabled;
        }

        private void GenerateConvBt_Click(object sender, EventArgs e)
        {
            int convolutionWindow = (int)WindowNud.Value;
            string varName =
                InputsLV.SelectedItems.
                    OfType<ListViewItem>().
                    First().Text;
            for (int c = 1; c < convolutionWindow; c++)
            {
                string columnName = $"{varName}+{c}";
                if (!inputSeries.ContainsKey(columnName))
                {
                    inputSeries.Add(columnName, new List<double>());
                    InputsLV.Items.Add(columnName);
                }
            }

            int L = inputSeries[varName].Count;
            for (int c = 1; c < convolutionWindow; c++)
            {
                string columnName = $"{varName}+{c}";
                if (inputSeries.ContainsKey(columnName))
                {
                    for (int i = 0; i < L; i++)
                    {
                        inputSeries[columnName].Add(inputSeries[varName][(i + c) % L]);
                    }
                }
            }
        }

        private void LowFreqBt_Click(object sender, EventArgs e)
        {
            string varName =
                OutputsLV.SelectedItems.
                    OfType<ListViewItem>().
                    First().Text;
            var sortedOutput =
                outputSeries[varName].
                    Zip(Enumerable.Range(0, outputSeries[varName].Count)).
                    OrderByDescending(v => v.First).
                    ToArray();
            double N = sortedOutput.Length;
            double w = 2.0 * Math.PI / N;
            double cSum = 0.0, sSum = 0.0;
            for (int i = 0; i < sortedOutput.Length; i++)
            {
                cSum += sortedOutput[i].First * Math.Cos(w * i);
                sSum -= sortedOutput[i].First * Math.Sin(w * i);
            }
            Complex wave = new(cSum / N, sSum / N);
            string columnName = $"{varName}+LOW";
            double[] tags = new double[(int)N];
            for (int i = 0; i < sortedOutput.Length; i++)
            {
                tags[sortedOutput[i].Second] = 2.0 * wave.Magnitude * Math.Cos(w * i + wave.Phase);
            }
            outputSeries.Add(columnName, tags.ToList());
            OutputsLV.Items.Add(columnName);
        }

        private void BuildSetBt_Click(object sender, EventArgs e)
        {
            sampleSeries.Clear();
            selectedSeries =
                outputSeries.ContainsKey(OutputsListCb.Text) ?
                    outputSeries[OutputsListCb.Text] :
                    inputSeries[OutputsListCb.Text];
            var respectedOutput =
                selectedSeries.
                    Zip(Enumerable.Range(0, selectedSeries.Count)).
                    OrderByDescending(kv => kv.First);
            int[] idxs;
            int mid = respectedOutput.Count() / 2;
            switch ((int)SampleSizeNud.Value)
            {
                case 2:
                    idxs = new int[] { respectedOutput.Last().Second, respectedOutput.First().Second };
                    goto case 5;
                case 3:
                    idxs = new int[] {
                        respectedOutput.Last().Second,
                        respectedOutput.First().Second,
                        respectedOutput.ElementAt(mid).Second
                    };
                    goto case 5;
                case 4:
                    var beggining = respectedOutput.Take(2);
                    var end = respectedOutput.Skip(respectedOutput.Count() - 2);
                    idxs = new int[] {
                        end.Last().Second,
                        beggining.First().Second,
                        end.First().Second,
                        beggining.Last().Second
                    };
                    goto case 5;
                case 5:
                    var beggining5 = respectedOutput.Take(2);
                    var end5 = respectedOutput.Skip(respectedOutput.Count() - 2);
                    idxs = new int[] {
                        end5.Last().Second,
                        beggining5.First().Second,
                        end5.First().Second,
                        beggining5.Last().Second,
                        respectedOutput.ElementAt(mid).Second
                    };
                    foreach (var s in inputSeries)
                    {
                        List<double> samplesList = new();
                        foreach (var idx in idxs) samplesList.Add(s.Value[idx]);
                        sampleSeries.Add(s.Key, samplesList);
                    }
                    foreach (var s in outputSeries)
                    {
                        List<double> samplesList = new();
                        foreach (var idx in idxs) samplesList.Add(s.Value[idx]);
                        sampleSeries.Add(s.Key, samplesList);
                    }
                    if (model is null) model = new(sampleSeries[OutputsListCb.Text].Count);
                    if (!model.Outputs.ContainsKey(OutputsListCb.Text))
                    {
                        outputSignal = model.CreateOutput(sampleSeries[OutputsListCb.Text], OutputsListCb.Text);
                        OutputName = OutputsListCb.Text;
                    }

                    foreach (var s in inputSeries)
                    {
                        if (!inputSignals.ContainsKey(s.Key))
                            inputSignals.Add(s.Key, model.CreateInput(sampleSeries[s.Key], s.Key));
                    }
                    break;
                default:
                    break;
            }
            // rebuild samples table
            SamplesDg.Rows.Clear();
            SamplesDg.Columns.Clear();

            foreach (var s in sampleSeries)
            {
                SamplesDg.Columns.Add(s.Key, s.Key);
            }
            for (int j = 0; j < (int)SampleSizeNud.Value; j++)
            {
                int row = SamplesDg.Rows.Add();
                int i = 0;
                foreach (var s in sampleSeries)
                {
                    SamplesDg.Rows[row].Cells[i].Value = s.Value[j];
                    i++;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1 when OutputsListCb.Items.Count == 0:
                    // OutputsListCb.Items.Clear();
                    OutputsListCb.Items.AddRange(
                        InputsLV.
                            Items.
                            OfType<ListViewItem>().
                            Select(v => v.Text).
                            Concat(OutputsLV.
                                    Items.
                                    OfType<ListViewItem>().
                                    Select(v => v.Text))
                            .ToArray()
                     );
                    OutputsListCb.SelectedIndex = 0;
                    break;
                case 2:
                    CalculateFourier();
                    break;
            }
        }

        private void CalculateFourier()
        {
            var signal = outputSignal; // new Harmonics(sampleSeries[OutputsListCb.Text]).ToSignal;
            TargetRainbowDg.Rows.Clear();
            TargetRainbowDg.Rows.Add(sampleSeries[OutputsListCb.Text].Count / 2);
            double sumSq = 0.0;
            for (int k = 0; k <= sampleSeries[OutputsListCb.Text].Count / 2; k++)
            {
                // DFT calculated here
                var wave = signal?.TryGetWave(k);
                if (wave != null)
                {
                    var waveVal = wave.Value;
                    TargetRainbowDg.Rows[k].Cells["k"].Value = waveVal.k;
                    TargetRainbowDg.Rows[k].Cells["Fourier"].Value = $"{waveVal.C.Real:f3} + {waveVal.C.Imaginary:f3}";
                    TargetRainbowDg.Rows[k].Cells["Magnitude"].Value = waveVal.C.Magnitude;
                    TargetRainbowDg.Rows[k].Cells["Phase"].Value = waveVal.C.Phase;
                    sumSq += waveVal.C.Magnitude * waveVal.C.Magnitude;
                }
            }
            for (int k = 0; k <= sampleSeries[OutputsListCb.Text].Count / 2; k++)
            {
                var wave = signal?.TryGetWave(k);
                if (wave != null)
                {
                    var waveVal = wave.Value;
                    TargetRainbowDg.Rows[k].Cells["Energy"].Value = $"{waveVal.C.Magnitude * waveVal.C.Magnitude / sumSq * 100.0:f3}%";
                }
            }
        }

        private void OpenConstructorBt_Click(object sender, EventArgs e)
        {
            var constructor = new Constructor(model, inputSignals, outputSignal, OutputName);
            var res = constructor.ShowDialog();
            if (res == DialogResult.OK)
            {
                SubnetsDg.Rows.Clear();
                SubnetsDg.Columns.Clear();

                SubnetsDg.Columns.Add("NodeName", "Name");
                int j = 0;
                for (int k = 0; k < model.HalfN; k++)
                {
                    j = SubnetsDg.Columns.Add($"wave{k}", k.ToString());
                    SubnetsDg.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                j = SubnetsDg.Columns.Add("Formula", "Formula");
                SubnetsDg.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                foreach (var kv in constructor.inputSignals)
                {
                    int idx = SubnetsDg.Rows.Add(kv.Key);
                    if (model.Nodes.ContainsKey(kv.Key))
                        SubnetsDg.Rows[idx].Cells["Formula"].Value = model.Nodes[kv.Key].ToString();
                    for (int k = 0; k < model.HalfN; k++)
                    {
                        var wave = kv.Value.TryGetWave(k);
                        if (wave is not null)
                            if (wave.Value.isConstant)
                                SubnetsDg.Rows[idx].Cells[$"wave{k}"].Value = wave.Value.C.Real;
                            else
                                SubnetsDg.Rows[idx].Cells[$"wave{k}"].Value = wave.Value.C;
                    }
                }
            }
        }

        private async void ExportCsvBt_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                using var file = File.OpenWrite(saveFileDialog1.FileName);
                using var writer = new StreamWriter(file);
                for (int i = 0; i < N; i++)
                {
                    await writer.WriteLineAsync(
                        string.Join(";",
                            InputsLV.SelectedItems.
                                OfType<ListViewItem>().
                                Select(inputName => inputSeries[inputName.Text][i].ToString()).
                                Concat(OutputsLV.SelectedItems.
                                    OfType<ListViewItem>().
                                    Select(outputName => outputSeries[outputName.Text][i].ToString())
                                )
                         )
                    );
                }
            }
        }

        // Change target name
        private void OutputsListCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(model is not null)
            {
                if (!model.Outputs.ContainsKey(OutputsListCb.Text))
                {
                    outputSignal = model.CreateOutput(sampleSeries[OutputsListCb.Text], OutputsListCb.Text);
                    OutputName = OutputsListCb.Text;
                }
            }
        }
    }
}
