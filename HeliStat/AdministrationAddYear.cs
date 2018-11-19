using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmAdministrationAddYear : Form
    {
        private string newYear;

        public string NewYear
        {
            get { return newYear; }
            private set { CheckUserInput(value); }
        }

        public bool UserInput { get; set; } = false;

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
            NewYear = tbxYear.Text.ToString();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserInput = true;
            Close();
        }

        /// <summary>
        /// Functions
        /// </summary>

        // allows only numbers and control keys during user input
        private void tbxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
            }
        }

        // check user input
        private void CheckUserInput(string value)
        {
            // textbox not null or empty
            if (!string.IsNullOrEmpty(value))
            {
                int length = value.Length;

                // year with 4 digits
                if (length == 4)
                {
                    int year = Convert.ToInt32(value);

                    // year range between 2000 - 2099
                    if (year >= 2000 && year < 2100)
                    {
                        newYear = value;
                        UserInput = true;
                    }
                    else
                    {

                        MessageBox.Show("Enter a year between 2000 and 2099.", "Year out of range",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        UserInput = false;
                    }
                }
                else
                {
                    MessageBox.Show("Enter a year with 4 digits (yyyy).", "Year wrong format",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UserInput = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a year.", "Missing year",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UserInput = false;
            }
        }
    }
}
