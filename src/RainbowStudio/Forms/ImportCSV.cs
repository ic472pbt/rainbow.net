using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowStudio
{
    public partial class ImportCSV : Form
    {
        private readonly string CSVfileName;
        private char sep;

        public Dictionary<string, List<double>> inputSeries = new();
        public Dictionary<string, List<double>> outputSeries = new();

        public ImportCSV(string CSVfileName)
        {
            this.CSVfileName = CSVfileName;
            InitializeComponent();
            PrepareForm();
        }

        private void PrepareForm()
        {
            using var f = File.OpenText(CSVfileName);
            string line = f.ReadLine();
            sep = line.Contains(';') ? ';' : (line.Contains(',') ? ',' : '\t');
            foreach (string name in line.Split(sep))
            {
                dataGridView1.Rows.Add(string.Empty, name.Replace("\"", string.Empty));
            }
        }

        private void ReadData(List<int> inputs, List<int> outputs)
        {
            using var f = File.OpenText(CSVfileName);
            string line = f.ReadLine();
            string[] names = line.Split(sep);
            foreach (int i in inputs) { inputSeries[names[i]] = new(); }
            foreach (int i in outputs) { outputSeries[names[i]] = new (); }
            try
            {
                while ((line = f.ReadLine()) != null)
                {
                    var values = line.Split(sep);
                    foreach (int i in inputs)
                    {
                        inputSeries[names[i]].Add(double.Parse(values[i].Replace("\"", string.Empty), System.Globalization.CultureInfo.InvariantCulture));
                    }
                    foreach (int i in outputs) { 
                        outputSeries[names[i]].Add(double.Parse(values[i].Replace("\"", string.Empty), System.Globalization.CultureInfo.InvariantCulture)); 
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> inputs = new();
            List<int> outputs = new();
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((string)row.Cells["Dirrection"].Value == "Input")
                {
                    inputs.Add(i);
                }
                if ((string)row.Cells["Dirrection"].Value == "Output")
                {
                    outputs.Add(i);
                }
                i++;
            }
            if (inputs.Count == 0)
            {
                MessageBox.Show(
                                "Inputs list is empty. Please select at least one input.",
                                "Selection error"
                               );
                return;
            }
            if (outputs.Count == 0)
            {
                MessageBox.Show(
                    "Outputs list is empty. Please select at least one output.",
                    "Selection error"
                    );
                return;
            }
            ReadData(inputs, outputs);
            DialogResult = DialogResult.OK;
        }
    }
}
