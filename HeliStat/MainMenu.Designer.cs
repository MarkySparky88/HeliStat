namespace HeliStat
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnMovements = new System.Windows.Forms.Button();
            this.btnHelicopters = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMovements
            // 
            this.btnMovements.Location = new System.Drawing.Point(16, 15);
            this.btnMovements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMovements.Name = "btnMovements";
            this.btnMovements.Size = new System.Drawing.Size(289, 123);
            this.btnMovements.TabIndex = 0;
            this.btnMovements.Text = "Enter Movements";
            this.btnMovements.UseVisualStyleBackColor = true;
            this.btnMovements.Click += new System.EventHandler(this.btnMovements_Click);
            // 
            // btnHelicopters
            // 
            this.btnHelicopters.Location = new System.Drawing.Point(16, 159);
            this.btnHelicopters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHelicopters.Name = "btnHelicopters";
            this.btnHelicopters.Size = new System.Drawing.Size(133, 123);
            this.btnHelicopters.TabIndex = 1;
            this.btnHelicopters.Text = "Helicopters";
            this.btnHelicopters.UseVisualStyleBackColor = true;
            this.btnHelicopters.Click += new System.EventHandler(this.btnHelicopters_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(172, 159);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(133, 123);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdmin.Location = new System.Drawing.Point(16, 303);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(289, 39);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Administration";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnMovements;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 359);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnHelicopters);
            this.Controls.Add(this.btnMovements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMovements;
        private System.Windows.Forms.Button btnHelicopters;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnAdmin;
    }
}

