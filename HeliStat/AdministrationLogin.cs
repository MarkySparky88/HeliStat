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
    public partial class frmAdminLogin : Form
    {
        public bool LoginSuccess { get; private set; }

        // Constructor
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        // Form load
        private void frmAdminLogin_Load(object sender, EventArgs e)
        {
            PresetTbxUsername("admin");
        }

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "Login"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Functions
        /// </summary>
        
        // Start Login process
        private void Login()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblUsers WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", tbxUsername.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", tbxPassword.Text.ToString());

                        CheckUsernamePassword(cmd);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Check username & password
        // TODO put that function into property "LoginSuccess" under "set"?
        private void CheckUsernamePassword(SqlCommand cmd)
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader != null)
                {
                    int count = 0;

                    while (reader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        LoginSuccess = true;
                    }
                    else
                    {
                        MessageBox.Show("Username and / or password not correct.\nAccess denied.", "Access denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        LoginSuccess = false;
                    }
                }
            }
        }

        // Preset text for username
        private void PresetTbxUsername(string username)
        {
            tbxUsername.Text = username;
        }
    }
}
