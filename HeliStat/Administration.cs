using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmAdministration : Form
    {
        // Constructor
        public frmAdministration()
        {
            InitializeComponent();
            FillCbxYears();
            DisplayActualYear();
        }

        /// <summary>
        /// Fill comboboxes
        /// </summary>

        // Fill combobox years
        private void FillCbxYears()
        {
            cbxYears.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblYears ORDER BY Year DESC";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Year"));
                                    cbxYears.Items.Add(addItem);
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cbxYears.SelectedItem = DisplayActualYear();
        }

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "Set"
        private void btnSetYear_Click(object sender, EventArgs e)
        {
            SetActualYear();
        }

        // Button "Add new year"
        private void btnAddYear_Click(object sender, EventArgs e)
        {
            AddYear();
        }

        // Button "Delete selected year"
        private void btnDeleteYear_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Archive year"
        private void btnAchriveYear_Click(object sender, EventArgs e)
        {
            // TODO enable button again (button properties window)
            // TODO write code here..
        }

        // Button "Retrieve year"
        private void btnRetrieveYear_Click(object sender, EventArgs e)
        {
            // TODO enable button again (button properties window)
            // TODO write code here..
        }

        // Button "Backup database"
        private void btnBackupDb_Click(object sender, EventArgs e)
        {
            // TODO enable button again (button properties window)
            // TODO write code here..
        }

        // Button "Restore database"
        private void btnRestoreDb_Click(object sender, EventArgs e)
        {
            // TODO enable button again (button properties window)
            // TODO write code here..
        }

        // Button "Delete database"
        private void btnDeleteDb_Click(object sender, EventArgs e)
        {
            // TODO enable button again (button properties window)
            // TODO write code here..
        }

        /// <summary>
        /// Funtions
        /// </summary>

        // Add year: Open and check dialog box for user input
        private void AddYear()
        {
            using (frmAdministrationAddYear addYear = new frmAdministrationAddYear())
            {
                while (addYear.UserInput == false)
                {
                    if (addYear.ShowDialog() == DialogResult.OK && addYear.UserInput == true)
                    {
                        if (!checkIfYearExists(addYear))
                        {
                            string year = addYear.NewYear;
                            string tableName = TableNameMov(addYear);

                            AddYearToTblYears(year);
                            CopyFromTblMov(addYear, tableName);
                        }
                        else
                        {
                            MessageBox.Show("This year already exists.\nEnter a new year.", "Year exists",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            addYear.UserInput = false;
                        }
                    }
                }
            }
        }

        // Checks if year already exists in database
        // TODO the exact same function exists for the ICAO-Designator! -> combine! Maybe it is possible to make one function and pass the table name via parameter?
        private bool checkIfYearExists(frmAdministrationAddYear addYear)
        {
            bool doesExist = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblYears] WHERE ([Year] = @Year)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Year", addYear.NewYear);

                        int entryExists = (int)cmd.ExecuteScalar();

                        if (entryExists > 0)
                        {
                            doesExist = true;
                        }
                        else
                        {
                            doesExist = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return doesExist;
        }

        // Create table name for movements table (year)
        private static string TableNameMov(frmAdministrationAddYear addYear)
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string tableName = sb.Append(addYear.NewYear).ToString();
            return tableName;
        }

        // Add year to database (tblYears)
        private void AddYearToTblYears(string year)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblYears (Year) VALUES (@Year)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Year has been added succesfully!", "Year added",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // TODO is there a better / other way to reload / refresh the new added data in the combobox
            FillCbxYears();
        }

        // Copy from tblMov and create new table (year)
        // TODO check if year already exists in database (catch SqlException does it actually already...)
        private void CopyFromTblMov(frmAdministrationAddYear addYear, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = string.Format("SELECT * INTO {0} FROM tblMov WHERE 1 = 0", tableName);

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Setting of actual year
        /// </summary>

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
            // catch if no year selected in combobox
            if (cbxYears.SelectedItem != null)
            {
                // set actual year in app settings
                string actualYear = cbxYears.SelectedItem.ToString();
                Properties.Settings.Default.ActualYear = actualYear;

                // calls event handler
                OnActualYearChanged(EventArgs.Empty);

                // display actual year
                DisplayActualYear();

                // message box
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
    }
}
