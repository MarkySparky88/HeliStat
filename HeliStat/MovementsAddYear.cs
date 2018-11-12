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

        // allows only numbers and control keys
        private void tbxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
            }
        }

        // TODO check minimum length (4) of user input
        // TODO allow only range between 2000 and 2099
        // check user input if correct (not null or empty)
        private bool CheckUserInput()
        {
            if (!string.IsNullOrEmpty(tbxYear.Text))
            {
                NewYear = tbxYear.Text.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Enter a year.", "Missing year",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = CheckUserInput();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogBoxStatus = true;
        }
    }
}
