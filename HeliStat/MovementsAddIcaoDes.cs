using System;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMovementsAddIcaoDes : Form
    {
        public string NewIcaoDesignator { get; private set; }
        public bool DialogBoxStatus = false;

        public frmMovementsAddIcaoDes()
        {
            InitializeComponent();
        }

        // check user input if correct (ICAO 4-letter code)
        private bool CheckUserInput()
        {
            if (!string.IsNullOrEmpty(tbxIcaoDesignator.Text) && tbxIcaoDesignator.TextLength == 4)
            {
                NewIcaoDesignator = tbxIcaoDesignator.Text.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Enter a valid ICAO-Designator (4 characters).", "Invalid or missing ICAO-Designator",
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