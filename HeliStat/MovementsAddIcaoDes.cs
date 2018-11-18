using System;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMovementsAddIcaoDes : Form
    {
        private string newIcaoDesignator;

        public string NewIcaoDesignator
        {
            get { return newIcaoDesignator; }
            private set { CheckUserInput(value); }
        }

        public bool DialogStatus { get; set; } = false;

        // Constructor
        public frmMovementsAddIcaoDes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            NewIcaoDesignator = tbxIcaoDesignator.Text.ToString();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogStatus = true;
            Close();
        }

        /// <summary>
        /// Functions
        /// </summary>

        // check user input
        private void CheckUserInput(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length == 4)
            {
                newIcaoDesignator = value;
                DialogStatus = true;
            }
            else
            {
                MessageBox.Show("Enter a valid ICAO-Designator (4 characters).", "Invalid or missing ICAO-Designator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogStatus = false;
            }
        }
    }
}