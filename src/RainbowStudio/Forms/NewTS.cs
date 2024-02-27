using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowStudio.Forms
{
    public partial class NewTS : Form
    {
        public NewTS()
        {
            InitializeComponent();
        }


        private void timeSeriesGv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string value = (string)e.FormattedValue;
            if (value == "")
                return;
            e.Cancel = !double.TryParse(value, out _);
        }

        private void toTrajectoryBt_Click(object sender, EventArgs e)
        {
            var X = 
                Enumerable.
                Range(0, timeSeriesGv.Rows.Count - 1).
                Select(i => double.Parse((string)timeSeriesGv.Rows[i].Cells[0].Value)).
                ToArray();
            
            var trajectory = new Trajectory((int)convolutionWindowNud.Value)
            {
                x = X,
                MdiParent = MdiParent
            };
            trajectory.Show();
        }
    }
}
