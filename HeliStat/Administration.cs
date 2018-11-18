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
        // Connection string
        string connString = Properties.Settings.Default.DBConnection;

        // Constructor
        public frmAdministration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fill comboboxes
        /// </summary>
        
        // Fill combobox years
        private void FillToolStripCbxYear()
        {
            toolStripCbxYear.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"SELECT * FROM tblYears
                                        ORDER BY Year";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Year"));
                                    toolStripCbxYear.Items.Add(addItem);
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
        }

        /// <summary>
        /// Buttons
        /// </summary>

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

        // Button "Backup database"
        private void btnBackupDb_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        // Button "Delete database"
        private void btnDeleteDb_Click(object sender, EventArgs e)
        {
            // TODO write code here..
        }

        /// <summary>
        /// Funtions
        /// </summary>

        // Add year: Open and check dialog box for user input
        private void AddYear()
        {
            frmMovementsAddYear addYear = new frmMovementsAddYear();

            while (addYear.DialogBoxStatus == false)
            {
                if (addYear.ShowDialog() == DialogResult.OK && addYear.DialogBoxStatus == true)
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
                        addYear.DialogBoxStatus = false;
                    }
                }
            }
        }

        // Checks if year already exists in database
        // TODO the exact same function exists for the ICAO-Designator! -> combine! Maybe it is possible to make one function and pass the table name via parameter?
        private bool checkIfYearExists(frmMovementsAddYear addYear)
        {
            bool doesExist = false;

            using (SqlConnection connection = new SqlConnection(connString))
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
        private static string CreateTableNameMovYear(frmMovementsAddYear addYear)
        {
            StringBuilder sbTableNameYear = new StringBuilder("tblMov");
            string tableName = sbTableNameYear.Append(addYear.NewYear).ToString();
            return tableName;
        }

        // Add year to database (tblYears)
        private void AddYearToTblYears(string year)
        {
            using (SqlConnection connection = new SqlConnection(connString))
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
            FillToolStripCbxYear();
        }

        // Copy from tblMov and create new table (year)
        // TODO check if year already exists in database (catch SqlException does it actually already...)
        private void CopyFromTblMov(frmMovementsAddYear addYear, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connString))
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
    }
}
