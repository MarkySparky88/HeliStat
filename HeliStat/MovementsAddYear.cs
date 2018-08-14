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
    public partial class frmMovementsAddYear : Form
    {
        private string newYear;

        public string NewYear
        {
            get { return newYear; }
        }

        public frmMovementsAddYear()
        {
            InitializeComponent();
        }

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            // TODO catch wrong entries
            if (tbxNewYear.Text != null)
            {
                newYear = tbxNewYear.Text.ToString();
            }
            //else
            //{
            //    MessageBox.Show("Enter an ICAO Designator.", "Missing ICAO Designator",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
    }
}
