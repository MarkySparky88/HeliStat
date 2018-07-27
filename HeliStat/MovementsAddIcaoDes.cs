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

        public frmMovementsAddIcaoDes()
        {
            InitializeComponent();
        }

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxIcaoDesignator.Text != null)
            {
                newIcaoDesignator = tbxIcaoDesignator.Text.ToString();
            }
            else
            {
                MessageBox.Show("Enter an ICAO Designator.", "Missing ICAO Designator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
