using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliStat
{
    static class Program
    {
        // Connection string to server database
        //public static string ConnString = DBConnection.Default.HeliStatDBServerConnection;

        // Connection string to local database
        public static string ConnString = DBConnection.Default.HeliStatDBLocalConnection;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
