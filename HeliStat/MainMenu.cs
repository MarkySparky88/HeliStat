using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMain : Form
    {
        // TODO: Add status strip ("Movements today" / "Helicopters in database"/ etc.)
        // TODO: deactivate console output (Go to Project -> HeliStat Properties -> Application -> Output type -> select Windows application

        public frmMain()
        {
            InitializeComponent();
        }

        // call "Movements" from Main form (button)
        private void btnMovements_Click(object sender, EventArgs e)
        {
            frmMovements movements = new frmMovements();
            movements.Show();
        }

        // call "Helicopters" from Main form (button)
        private void btnHelicopters_Click(object sender, EventArgs e)
        {
            frmHelicopters helicopters = new frmHelicopters();
            helicopters.Show();
        }

        // call "Statistics" from Main form (button)
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            frmStatistics statistics = new frmStatistics();
            statistics.Show();
        }
    }
}
