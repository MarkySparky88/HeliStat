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
            private set { CheckUserInput(value); }
        }

        public bool DialogStatus { get; set; } = false;

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
            NewAircraftType = tbxAircraftType.Text.ToString();
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
                newAircraftType = value;
                DialogStatus = true;
            }
            else
            {
                MessageBox.Show("Enter a valid aircraft type (4-letter code).", "Invalid or missing aircraft type",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogStatus = false;
            }
        }   
    }
}
