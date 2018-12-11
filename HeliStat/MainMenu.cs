using System;
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
        /// TODO delete unused namespaces (whole project) (CRTL + R, CTRL + G)
        /// TODO Code aufräumen (Refactor!), wird gleicher Code mehrfach verwendet (Refactor / eine Funktion für alles)
        /// TODO alle Datenbankverbindungen irgendwie zusammenfassen! (ev eigene Klasse?)
        /// TODO auskommentierte Zeilen im Code welche nicht mehr gebraucht werden, und nur zum testen gebraucht wurden, löschen
        /// </summary>

        // Constructor
        public frmMain()
        {
            InitializeComponent();
        }

        #region Buttons
        // open "Movements"
        private void btnMovements_Click(object sender, EventArgs e)
        {
            using (frmMovements movements = new frmMovements())
            {
                movements.ShowDialog();
            }
        }

        // open "Helicopters"
        private void btnHelicopters_Click(object sender, EventArgs e)
        {
            using (frmHelicopters helicopters = new frmHelicopters())
            {
                helicopters.ShowDialog();
            }
        }

        // open "Statistics"
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            using (frmStatistics statistics = new frmStatistics())
            {
                statistics.ShowDialog();
            }
        }

        // open "Administration Login"
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            using (frmAdminLogin adminLogin = new frmAdminLogin())
            {
                // if username & password correct, open administation panel
                if (adminLogin.ShowDialog() == DialogResult.OK && adminLogin.LoginSuccess)
                {
                    using (frmAdministration administration = new frmAdministration())
                    {
                        administration.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}