using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmHelicoptersAddOperator : Form
    {
        private string newOperator;
        public bool DialogBoxStatus { get; set; } = false;

        // Constructor
        public frmHelicoptersAddOperator()
        {
            InitializeComponent();
        }

        #region Buttons
        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddNewOperator();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = true;
        }
        #endregion

        #region Functions
        // TODO folgende Funktionen wurden für addOperator, addType, addIcaoDes und addYear ziemlich gleich verwendet (eine Klasse für alles? z.B. "AddNew.cs")

        // Add new operator
        private void AddNewOperator()
        {
            newOperator = tbxOperator.Text.ToString();

            // Check if operator exists
            if (!CheckIfRecordExists(newOperator))
            {
                // Check if user input correct
                if (CheckUserInput(newOperator))
                {
                    AddToDatabase(newOperator);
                }
            }
            else
            {
                MessageBox.Show("This operator already exists.\nEnter a new operator.", "Operator exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
            }
        }

        // Check if record already exists
        private bool CheckIfRecordExists(string newOperator)
        {
            bool recordExists = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblOperators] WHERE ([Operator] = @Operator)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Operator", newOperator);

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
        private bool CheckUserInput(string newOperator)
        {
            if (!string.IsNullOrEmpty(newOperator))
            {
                DialogBoxStatus = true;
                return true;
            }
            else
            {
                MessageBox.Show("Enter an operator name.", "Missing operator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogBoxStatus = false;
                return false;
            }
        }

        // Add opertor type to database
        private void AddToDatabase(string newOperator)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblOperators (Operator) VALUES (@Operator)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Operator", newOperator);
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
