using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmAdministrationAddYear : Form
    {
        private string newYear;
        public bool DialogBoxStatus { get; set; } = false;

        // Constructor
        public frmAdministrationAddYear()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddNewYear();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = true;
        }

        /// <summary>
        /// Functions
        /// </summary>

        // Allows only numbers and control keys during user input
        private void tbxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
            }
        }

        // Add new year
        private void AddNewYear()
        {
            newYear = tbxYear.Text.ToString();

            if (!CheckIfRecordExists(newYear))
            {
                if (CheckUserInput(newYear))
                {
                    AddToDatabase(newYear);
                    CopyFromTblMov(TableNameMov(newYear));
                }
            }
            else
            {
                MessageBox.Show("This year already exists.\nEnter a new year.", "Year exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
            }
        }

        // Check if record already exists
        private bool CheckIfRecordExists(string newYear)
        {
            bool recordExists = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblYears] WHERE ([Year] = @Year)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Year", newYear);

                        int i = (int)cmd.ExecuteScalar();

                        if (i > 0)
                        {
                            recordExists = true;
                        }
                        else
                        {
                            recordExists = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return recordExists;
            }
        }

        // Check user input
        private bool CheckUserInput(string newYear)
        {
            // textbox not null or empty
            if (!string.IsNullOrEmpty(newYear))
            {
                int length = newYear.Length;

                // year with 4 digits
                if (length == 4)
                {
                    int year = Convert.ToInt32(newYear);

                    // year range between 2000 - 2099
                    if (year >= 2000 && year < 2100)
                    {
                        //this.newYear = newYear;
                        DialogBoxStatus = true;
                        return true;
                    }
                    else
                    {

                        MessageBox.Show("Enter a year between 2000 and 2099.", "Year out of range",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DialogBoxStatus = false;
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Enter a year with 4 digits (yyyy).", "Year wrong format",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogBoxStatus = false;
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a year.", "Missing year",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
                return false;
            }
        }

        // Add year to database
        private void AddToDatabase(string newYear)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblYears (Year) VALUES (@Year)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Year", newYear);
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
        }

        // Create table name for movements table (year)
        private string TableNameMov(string newYear)
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string tableName = sb.Append(newYear).ToString();
            return tableName;
        }

        // Copy from tblMov and create new table (year)
        private void CopyFromTblMov(string tableName)
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
    }
}
