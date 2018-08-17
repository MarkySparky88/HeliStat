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
    public partial class frmHelicoptersAddNewType : Form
    {
        private string newAircraftType;

        public string NewAircraftType
        {
            get { return newAircraftType; }
        }

        public bool ValidationResult = false;

        public frmHelicoptersAddNewType()
        {
            InitializeComponent();
        }

        // TODO check if aircraft type already exists in database
        // check user input if correct (not null or empty)
        private bool CheckUserInput()
        {
            if (!String.IsNullOrEmpty(tbxAircraftType.Text))
            {
                newAircraftType = tbxAircraftType.Text.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Enter an aircraft type.", "Missing aircraft type",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidationResult = CheckUserInput();
        }

        // TODO cancel button not working
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
