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
    public partial class frmMovementsAddYear : Form
    {
        public string NewYear { get; private set; }
        public bool DialogBoxStatus = false;    // TODO is that a problem that there are several variables with the same name (DialogBoxStatus) in the project? This variable is in AddNewOperator, AddIcaoDes, etc. used as well

        public frmMovementsAddYear()
        {
            InitializeComponent();
        }

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
        private bool CheckUserInput()
        {
            // textbox not null or empty and digits only
            if (!string.IsNullOrEmpty(tbxYear.Text) && int.TryParse(tbxYear.Text, out int i))
            {
                int value = Convert.ToInt32(tbxYear.Text);

                // year range between 2000 - 2099
                if (value >= 2000 && value < 2100)
                {
                    NewYear = tbxYear.Text.ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("Enter a year between 2000 and 2099.", "Year out of range",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Enter 4 digits for a year (yyyy).", "Missing year",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = CheckUserInput();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogBoxStatus = true;
        }
    }
}
