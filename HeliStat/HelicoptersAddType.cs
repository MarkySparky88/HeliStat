using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmHelicoptersAddType : Form
    {
        private string newAircraftType;
        public bool DialogBoxStatus { get; set; } = false;

        // Constructor
        public frmHelicoptersAddType()
        {
            InitializeComponent();
        }

        #region Buttons
        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddNewAircraftType();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = true;
        }
        #endregion

        #region Functions
        // Add new aircraft type
        private void AddNewAircraftType()
        {
            newAircraftType = tbxAircraftType.Text.ToString();

            if (!CheckIfRecordExists(newAircraftType))
            {
                if (CheckUserInput(newAircraftType))
                {
                    AddToDatabase(newAircraftType);
                }
            }
            else
            {
                MessageBox.Show("This aircraft type already exists.\nEnter a new aircraft type.", "Aircraft type exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
            }
        }

        // Check if record already exists
        private bool CheckIfRecordExists(string newAircraftType)
        {
            bool recordExists = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblAircraftTypes] WHERE ([AircraftType] = @AircraftType)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AircraftType", newAircraftType);

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
        private bool CheckUserInput(string newAircraftType)
        {
            if (!string.IsNullOrEmpty(newAircraftType) && newAircraftType.Length == 4)
            {
                DialogBoxStatus = true;
                return true;
            }
            else
            {
                MessageBox.Show("Enter a valid aircraft type (4-letter code).", "Invalid or missing aircraft type",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
                return false;
            }
        }

        // Add aircraft type to database
        private void AddToDatabase(string newAircraftType)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblAircraftTypes (AircraftType) VALUES (@AircraftType)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AircraftType", newAircraftType);
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