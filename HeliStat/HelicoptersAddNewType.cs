using System;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmHelicoptersAddNewType : Form
    {
        public string NewAircraftType { get; private set; }
        public bool DialogBoxStatus = false;

        // Constructor
        public frmHelicoptersAddNewType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Buttons
        /// </summary>

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

        /// <summary>
        /// Functions
        /// </summary>

        // check user input if correct (not null or empty)
        private bool CheckUserInput()
        {
            if (!string.IsNullOrEmpty(tbxAircraftType.Text))
            {
                NewAircraftType = tbxAircraftType.Text.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Enter an aircraft type.", "Missing aircraft type",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }   
    }
}
