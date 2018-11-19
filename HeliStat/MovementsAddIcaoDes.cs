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

        public bool UserInput { get; set; } = false;

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
            UserInput = true;
            Close();
        }

        /// <summary>
        /// Functions
        /// </summary>

        // check user input
        // TODO this kind of code has been written many times for other functions / classes as well (refactor? one function / class for all?)
        private void CheckUserInput(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length == 4)
            {
                newIcaoDesignator = value;
                UserInput = true;
            }
            else
            {
                MessageBox.Show("Enter a valid ICAO-Designator (4 characters).", "Invalid or missing ICAO-Designator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UserInput = false;
            }
        }
    }
}