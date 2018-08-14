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
    public partial class frmHelicoptersAddNewOperator : Form
    {
        private string newOperator;

        public string NewOperator
        {
            get { return newOperator; }
        }

        public frmHelicoptersAddNewOperator()
        {
            InitializeComponent();
        }

        // Click OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            // TODO catch wrong entries
            if (tbxOperator.Text != null)
            {
                newOperator = tbxOperator.Text.ToString();
            }
            // T
            else
            {
                MessageBox.Show("Enter an operator name.", "Missing operator",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
