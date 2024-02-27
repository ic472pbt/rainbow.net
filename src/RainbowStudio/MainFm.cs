using RainbowStudio.Forms;

namespace RainbowStudio
{
    public partial class MainFm : Form
    {
        public MainFm()
        {
            InitializeComponent();
        }

        private void newTimeSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TsForm = new NewTS
            {
                MdiParent = this
            };
            TsForm.Show();
        }

        private void ImportCSVmi_Click(object sender, EventArgs e)
        {
            var res = OpenCSVfd.ShowDialog(this);
            if(res == DialogResult.OK)
            {
                var importCSV = new ImportCSV(OpenCSVfd.FileName);
                var dialogResult = importCSV.ShowDialog();
                if(dialogResult == DialogResult.OK)
                {
                    var oneDConvForm = new OneD_conv(importCSV.inputSeries, importCSV.outputSeries)
                    {
                        MdiParent = this
                    };
                    oneDConvForm.Show();
                }
            }
        }
    }
}