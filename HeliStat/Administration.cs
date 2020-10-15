using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmAdministration : Form
    {
        // Constructor
        public frmAdministration()
        {
            InitializeComponent();

            // Fill comboboxes
            // TODO bind comboboxes as well to datasource (dataset / datatable)??
            FillCbxYears();
            DisplayActualYear();
        }

        #region Fill boxes and views
        // Fill combobox years
        private void FillCbxYears()
        {
            cbxYears.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblYears ORDER BY Year_ DESC";

                    using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Year_"));
                                    cbxYears.Items.Add(addItem);
                                }
                            }
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cbxYears.SelectedItem = DisplayActualYear();
        }
        #endregion

        #region Buttons
        // Button "Set"
        private void btnSetYear_Click(object sender, EventArgs e)
        {
            SetActualYear();
        }

        // Button "Add new year"
        private void btnAddYear_Click(object sender, EventArgs e)
        {
            AddNewYear();
        }

        // Button "Delete selected year"
        private void btnDeleteYear_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Archive year"
        private void btnAchriveYear_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Retrieve year"
        private void btnRetrieveYear_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Backup database"
        private void btnBackupDb_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Restore database"
        private void btnRestoreDb_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Delete database"
        private void btnDeleteDb_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }
        #endregion

        #region Menu strip
        // File -> Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Functions
        // Add new year
        private void AddNewYear()
        {
            using (frmAdministrationAddYear addYear = new frmAdministrationAddYear())
            {
                while (addYear.DialogBoxStatus == false)
                {
                    if (addYear.ShowDialog() == DialogResult.OK && addYear.DialogBoxStatus == true)
                    {
                        // TODO is there a better / other way to reload / refresh the new added data in the combobox
                        FillCbxYears();
                    }
                }
            }
        }
        #endregion

        #region Functions (actual year)
        // Event handler when actual year has changed
        public delegate void ActualYearChangedEventHandler(object sender, EventArgs e);
        public event ActualYearChangedEventHandler ActualYearChanged;

        // Event handler function
        protected void OnActualYearChanged(EventArgs e)
        {
            ActualYearChanged?.Invoke(this, EventArgs.Empty);
        }

        // Set actual year
        private void SetActualYear()
        {
            // Check if a year is selected
            if (cbxYears.SelectedItem != null)
            {
                // Set actual year in app settings
                string actualYear = cbxYears.SelectedItem.ToString();
                Properties.Settings.Default.ActualYear = actualYear;

                // Call event handler
                OnActualYearChanged(EventArgs.Empty);

                // Display actual year
                DisplayActualYear();

                // Confirmation message
                string messageBoxText = string.Format("Year {0} has been set as the actual year for this program.", actualYear);
                MessageBox.Show(messageBoxText, "Actual year set",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a year from the list.", "No year selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Display actual year in textbox
        private string DisplayActualYear()
        {
            return tbxActualYear.Text = Properties.Settings.Default.ActualYear;
        }
        #endregion  
    }
}
