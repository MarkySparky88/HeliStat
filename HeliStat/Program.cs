using System;
using System.Windows.Forms;

namespace HeliStat
{
    static class Program
    {
        public static string ConnString { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Database location in user app data folder
            // TODO activate upon release!
            //AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            // Connection string
            ConnString = Properties.Settings.Default.DBConnection;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
