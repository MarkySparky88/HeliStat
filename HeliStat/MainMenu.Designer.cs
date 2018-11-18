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
            this.btnMovements.Location = new System.Drawing.Point(12, 12);
            this.btnMovements.Name = "btnMovements";
            this.btnMovements.Size = new System.Drawing.Size(217, 100);
            this.btnMovements.TabIndex = 0;
            this.btnMovements.Text = "Enter Movements";
            this.btnMovements.UseVisualStyleBackColor = true;
            this.btnMovements.Click += new System.EventHandler(this.btnMovements_Click);
            // 
            // btnHelicopters
            // 
            this.btnHelicopters.Location = new System.Drawing.Point(12, 129);
            this.btnHelicopters.Name = "btnHelicopters";
            this.btnHelicopters.Size = new System.Drawing.Size(100, 100);
            this.btnHelicopters.TabIndex = 1;
            this.btnHelicopters.Text = "Helicopters";
            this.btnHelicopters.UseVisualStyleBackColor = true;
            this.btnHelicopters.Click += new System.EventHandler(this.btnHelicopters_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(129, 129);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(100, 100);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdmin.Location = new System.Drawing.Point(12, 246);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(217, 32);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Administration";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 292);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnHelicopters);
            this.Controls.Add(this.btnMovements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

