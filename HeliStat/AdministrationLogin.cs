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
        // Constructor
        public frmAdminLogin()
        {
            InitializeComponent();
            tbxUsername.Text = "admin";
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
                    string cmdText = @"SELECT * FROM tblUsers
                                        WHERE Username = @Username AND Password = @Password";

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
                        OpenAdministration();
                    }
                    //else if (count > 1)
                    //{
                    //    MessageBox.Show("Duplicate Username and password.\nAccess denied.", "Access denied",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //}
                    else
                    {
                        MessageBox.Show("Username and / or password not correct.\nAccess denied.", "Access denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        // Open "Administration
        private void OpenAdministration()
        {
            Close();

            frmAdministration administration = new frmAdministration();
            administration.Show();
        }
    }
}
