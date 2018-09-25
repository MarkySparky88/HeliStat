using System;
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

        public bool DialogBoxStatus = false;

        public frmHelicoptersAddNewType()
        {
            InitializeComponent();
        }

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
            DialogBoxStatus = CheckUserInput();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogBoxStatus = true;
        }
    }
}
