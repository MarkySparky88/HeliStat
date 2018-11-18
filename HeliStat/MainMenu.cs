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
        /// <summary>
        /// TODOs whole project: 
        /// TODO: Add status strip ("Movements today" / "Helicopters in database"/ etc.)
        /// TODO: deactivate console output (Go to Project -> HeliStat Properties -> Application -> Output type -> select Windows application
        /// TODO set a link to Icon8 in the info panel https://icons8.com/license/
        /// TODO delete unused namespaces (whole project)
        /// </summary>

        // Constructor
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Buttons
        /// </summary>
        
        // open "Movements"
        private void btnMovements_Click(object sender, EventArgs e)
        {
            frmMovements movements = new frmMovements();
            movements.Show();
        }

        // open "Helicopters"
        private void btnHelicopters_Click(object sender, EventArgs e)
        {
            frmHelicopters helicopters = new frmHelicopters();
            helicopters.Show();
        }

        // open "Statistics"
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            frmStatistics statistics = new frmStatistics();
            statistics.Show();
        }

        // open "Administration Login"
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdminLogin adminLogin = new frmAdminLogin();
            adminLogin.Show();
        }
    }
}
