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
    public partial class frmMovementsAddIcaoDes : Form
    {
        private string newIcaoDesignator;

        public string NewIcaoDesignator
        {
            get { return newIcaoDesignator; }
        }

        public bool ValidationResult;

        public frmMovementsAddIcaoDes()
        {
            InitializeComponent();
        }

        // check user input
        public bool UserEntryValidation()
        {
            if (tbxIcaoDesignator.Text != null && tbxIcaoDesignator.Text.Length == 4)
            {
                newIcaoDesignator = tbxIcaoDesignator.Text.ToString();
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
            ValidationResult = UserEntryValidation();
            tbxIcaoDesignator.Text = null;
        }
    }
}
