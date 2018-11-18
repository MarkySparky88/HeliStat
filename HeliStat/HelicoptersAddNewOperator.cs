using System;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmHelicoptersAddNewOperator : Form
    {
        public string NewOperator { get; private set; }
        public bool DialogBoxStatus = false;

        // Constructor
        public frmHelicoptersAddNewOperator()
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
            if (!string.IsNullOrEmpty(tbxOperator.Text))
            {
                NewOperator = tbxOperator.Text.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Enter an operator name.", "Missing operator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}
