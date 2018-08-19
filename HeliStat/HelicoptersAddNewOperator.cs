﻿using System;
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

        public bool DialogBoxStatus = false;

        public frmHelicoptersAddNewOperator()
        {
            InitializeComponent();
        }

        // TODO check if operator already exists in database
        // check user input if correct (not null or empty)
        private bool CheckUserInput()
        {
            if (!String.IsNullOrEmpty(tbxOperator.Text))
            {
                newOperator = tbxOperator.Text.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Enter an operator name.", "Missing operator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // Button "OK"
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogBoxStatus = CheckUserInput();
        }

        // Button "Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogBoxStatus = true;
        }
    }
}
