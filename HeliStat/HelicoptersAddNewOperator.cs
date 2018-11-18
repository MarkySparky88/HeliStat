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
            private set { CheckUserInput(value); }
        }

        public bool DialogStatus { get; set; } = false;

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
            NewOperator = tbxOperator.Text.ToString();
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
            if (!string.IsNullOrEmpty(value))
            {
                newOperator = value;
                DialogStatus = true;
            }
            else
            {
                MessageBox.Show("Enter an operator name.", "Missing operator",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogStatus = false;
            }
        }
    }
}
