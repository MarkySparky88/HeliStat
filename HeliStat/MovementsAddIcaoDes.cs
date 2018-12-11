using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMovementsAddIcaoDes : Form
    {
        private string newIcaoDes;
        public bool DialogBoxStatus { get; set; } = false;

        // Constructor
        public frmMovementsAddIcaoDes()
        {
            InitializeComponent();
        }

        #region Buttons
        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddIcaoDes();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = true;
        }
        #endregion

        #region Functions
        // Add new ICAO designator
        private void AddIcaoDes()
        {
            newIcaoDes = tbxIcaoDesignator.Text.ToString();

            if (!CheckIfRecordExists(newIcaoDes))
            {
                if (CheckUserInput(newIcaoDes))
                {
                    AddToDatabase(newIcaoDes);
                }
            }
            else
            {
                MessageBox.Show("This ICAO location designator already exists.\nEnter a new ICAO location designator.",
                    "ICAO location designator exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
            }
        }

        // Check if record already exists
        private bool CheckIfRecordExists(string newIcaoDes)
        {
            bool recordExists = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblAirportCodes] WHERE ([AirportCode] = @AirportCode)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AirportCode", newIcaoDes);

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
        private bool CheckUserInput(string newIcaoDes)
        {
            if (!string.IsNullOrEmpty(newIcaoDes) && newIcaoDes.Length == 4)
            {
                DialogBoxStatus = true;
                return true;
            }
            else
            {
                MessageBox.Show("Enter a valid ICAO location designator (4-letter code).",
                    "Invalid or missing ICAO location designator",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
                return false;
            }
        }

        // Add ICAO designator to database
        private void AddToDatabase(string newIcaoDes)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblAirportCodes (AirportCode) VALUES (@AirportCode)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AirportCode", newIcaoDes);
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
        #endregion
    }
}