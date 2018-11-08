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
        public string NewYear { get; private set; }

        public frmMovementsAddYear()
        {
            InitializeComponent();
        }

        private void tbxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && !Char.IsControl(ch))
            {
                e.Handled = true;
            }
        }
    }
}
