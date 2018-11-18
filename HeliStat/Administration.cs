using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmAdministration : Form
    {
        public static string ActualYear { get; set; }

        // Constructor
        public frmAdministration()
        {
            InitializeComponent();
            FillCbxActualYear();
        }

        /// <summary>
        /// Fill comboboxes
        /// </summary>

        // Fill combobox years
        private void FillCbxActualYear()
        {
            cbxActualYear.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"SELECT * FROM tblYears
                                        ORDER BY Year DESC";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Year"));
                                    cbxActualYear.Items.Add(addItem);
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
            // TODO show actual selected year in combobox
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
            frmAdministrationAddYear addYear = new frmAdministrationAddYear();

            while (addYear.DialogStatus == false)
            {
                if (addYear.ShowDialog() == DialogResult.OK && addYear.DialogStatus == true)
                {
                    if (!checkIfYearExists(addYear))
                    {
                        string year = addYear.NewYear;
                        string tableName = CreateTableNameMovYear(addYear);

                        AddYearToTblYears(year);
                        CopyFromTblMov(addYear, tableName);
                    }
                    else
                    {
                        MessageBox.Show("This year already exists.\nEnter a new year.", "Year exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        addYear.DialogStatus = false;
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
                    string cmdText = @"SELECT COUNT(*) FROM [tblYears]
                                        WHERE ([Year] = @Year)";

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
        private static string CreateTableNameMovYear(frmAdministrationAddYear addYear)
        {
            StringBuilder sbTableNameYear = new StringBuilder("tblMov");
            string tableName = sbTableNameYear.Append(addYear.NewYear).ToString();
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
                    string cmdText = @"INSERT INTO tblYears (Year)
                                        VALUES (@Year)";

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
            FillCbxActualYear();
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

        // Set actual year
        private void SetActualYear()
        {
            ActualYear = cbxActualYear.SelectedItem.ToString();

            string messageBoxText = string.Format("Year {0} has been set as the actual year for this program.", ActualYear);
            MessageBox.Show(messageBoxText, "Actual year set",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
