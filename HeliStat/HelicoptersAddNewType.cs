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
    public partial class frmHelicoptersAddNewType : Form
    {
        private string newAircraftType;

        public string NewAircraftType
        {
            get { return newAircraftType; }
        }

        public frmHelicoptersAddNewType()
        {
            InitializeComponent();
        }

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxAircraftType.Text != null)
            {
                newAircraftType = tbxAircraftType.Text.ToString();
            }
            else
            {
                MessageBox.Show("Enter an aircraft type.", "Missing aircraft type",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
