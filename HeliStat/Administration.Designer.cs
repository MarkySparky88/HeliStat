namespace HeliStat
{
    partial class frmAdministration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministration));
            this.menuStripAdmin = new System.Windows.Forms.MenuStrip();
            this.toolStripAdmin = new System.Windows.Forms.ToolStrip();
            this.statusStripAdmin = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxYears = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddYear = new System.Windows.Forms.Button();
            this.btnDeleteYear = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBackupDb = new System.Windows.Forms.Button();
            this.btnDeleteDb = new System.Windows.Forms.Button();
            this.btnSetYear = new System.Windows.Forms.Button();
            this.btnRestoreDb = new System.Windows.Forms.Button();
            this.btnAchriveYear = new System.Windows.Forms.Button();
            this.btnRetrieveYear = new System.Windows.Forms.Button();
            this.tbxActualYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(487, 24);
            this.menuStripAdmin.TabIndex = 0;
            this.menuStripAdmin.Text = "menuStrip1";
            // 
            // toolStripAdmin
            // 
            this.toolStripAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripAdmin.Location = new System.Drawing.Point(0, 24);
            this.toolStripAdmin.Name = "toolStripAdmin";
            this.toolStripAdmin.Size = new System.Drawing.Size(487, 25);
            this.toolStripAdmin.TabIndex = 1;
            this.toolStripAdmin.Text = "toolStrip1";
            // 
            // statusStripAdmin
            // 
            this.statusStripAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripAdmin.Location = new System.Drawing.Point(0, 507);
            this.statusStripAdmin.Name = "statusStripAdmin";
            this.statusStripAdmin.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripAdmin.Size = new System.Drawing.Size(487, 22);
            this.statusStripAdmin.SizingGrip = false;
            this.statusStripAdmin.TabIndex = 2;
            this.statusStripAdmin.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HeliStat.Properties.Resources.calendar;
            this.pictureBox1.Location = new System.Drawing.Point(16, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 33);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Calendar year management";
            // 
            // cbxYears
            // 
            this.cbxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYears.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYears.FormattingEnabled = true;
            this.cbxYears.Location = new System.Drawing.Point(132, 167);
            this.cbxYears.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxYears.Name = "cbxYears";
            this.cbxYears.Size = new System.Drawing.Size(159, 24);
            this.cbxYears.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Set actual year:";
            // 
            // btnAddYear
            // 
            this.btnAddYear.Location = new System.Drawing.Point(20, 222);
            this.btnAddYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(161, 28);
            this.btnAddYear.TabIndex = 7;
            this.btnAddYear.Text = "Add year";
            this.btnAddYear.UseVisualStyleBackColor = true;
            this.btnAddYear.Click += new System.EventHandler(this.btnAddYear_Click);
            // 
            // btnDeleteYear
            // 
            this.btnDeleteYear.Enabled = false;
            this.btnDeleteYear.Location = new System.Drawing.Point(20, 257);
            this.btnDeleteYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteYear.Name = "btnDeleteYear";
            this.btnDeleteYear.Size = new System.Drawing.Size(161, 28);
            this.btnDeleteYear.TabIndex = 8;
            this.btnDeleteYear.Text = "Delete year";
            this.btnDeleteYear.UseVisualStyleBackColor = true;
            this.btnDeleteYear.Click += new System.EventHandler(this.btnDeleteYear_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HeliStat.Properties.Resources.database;
            this.pictureBox2.Location = new System.Drawing.Point(16, 322);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 32);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 36);
            this.label3.TabIndex = 10;
            this.label3.Text = "Database management";
            // 
            // btnBackupDb
            // 
            this.btnBackupDb.Enabled = false;
            this.btnBackupDb.Location = new System.Drawing.Point(20, 382);
            this.btnBackupDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackupDb.Name = "btnBackupDb";
            this.btnBackupDb.Size = new System.Drawing.Size(161, 28);
            this.btnBackupDb.TabIndex = 11;
            this.btnBackupDb.Text = "Backup database";
            this.btnBackupDb.UseVisualStyleBackColor = true;
            this.btnBackupDb.Click += new System.EventHandler(this.btnBackupDb_Click);
            // 
            // btnDeleteDb
            // 
            this.btnDeleteDb.Enabled = false;
            this.btnDeleteDb.Location = new System.Drawing.Point(20, 453);
            this.btnDeleteDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteDb.Name = "btnDeleteDb";
            this.btnDeleteDb.Size = new System.Drawing.Size(161, 28);
            this.btnDeleteDb.TabIndex = 12;
            this.btnDeleteDb.Text = "Delete database";
            this.btnDeleteDb.UseVisualStyleBackColor = true;
            this.btnDeleteDb.Click += new System.EventHandler(this.btnDeleteDb_Click);
            // 
            // btnSetYear
            // 
            this.btnSetYear.Location = new System.Drawing.Point(300, 165);
            this.btnSetYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetYear.Name = "btnSetYear";
            this.btnSetYear.Size = new System.Drawing.Size(100, 28);
            this.btnSetYear.TabIndex = 13;
            this.btnSetYear.Text = "Set";
            this.btnSetYear.UseVisualStyleBackColor = true;
            this.btnSetYear.Click += new System.EventHandler(this.btnSetYear_Click);
            // 
            // btnRestoreDb
            // 
            this.btnRestoreDb.Enabled = false;
            this.btnRestoreDb.Location = new System.Drawing.Point(20, 417);
            this.btnRestoreDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRestoreDb.Name = "btnRestoreDb";
            this.btnRestoreDb.Size = new System.Drawing.Size(161, 28);
            this.btnRestoreDb.TabIndex = 14;
            this.btnRestoreDb.Text = "Restore database";
            this.btnRestoreDb.UseVisualStyleBackColor = true;
            this.btnRestoreDb.Click += new System.EventHandler(this.btnRestoreDb_Click);
            // 
            // btnAchriveYear
            // 
            this.btnAchriveYear.Enabled = false;
            this.btnAchriveYear.Location = new System.Drawing.Point(239, 222);
            this.btnAchriveYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAchriveYear.Name = "btnAchriveYear";
            this.btnAchriveYear.Size = new System.Drawing.Size(161, 28);
            this.btnAchriveYear.TabIndex = 15;
            this.btnAchriveYear.Text = "Archive year";
            this.btnAchriveYear.UseVisualStyleBackColor = true;
            this.btnAchriveYear.Click += new System.EventHandler(this.btnAchriveYear_Click);
            // 
            // btnRetrieveYear
            // 
            this.btnRetrieveYear.Enabled = false;
            this.btnRetrieveYear.Location = new System.Drawing.Point(239, 257);
            this.btnRetrieveYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRetrieveYear.Name = "btnRetrieveYear";
            this.btnRetrieveYear.Size = new System.Drawing.Size(161, 28);
            this.btnRetrieveYear.TabIndex = 16;
            this.btnRetrieveYear.Text = "Retrieve year";
            this.btnRetrieveYear.UseVisualStyleBackColor = true;
            this.btnRetrieveYear.Click += new System.EventHandler(this.btnRetrieveYear_Click);
            // 
            // tbxActualYear
            // 
            this.tbxActualYear.Location = new System.Drawing.Point(132, 135);
            this.tbxActualYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxActualYear.Name = "tbxActualYear";
            this.tbxActualYear.ReadOnly = true;
            this.tbxActualYear.Size = new System.Drawing.Size(159, 22);
            this.tbxActualYear.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Actual year:";
            // 
            // frmAdministration
            // 
            this.AcceptButton = this.btnSetYear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 529);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxActualYear);
            this.Controls.Add(this.btnRetrieveYear);
            this.Controls.Add(this.btnAchriveYear);
            this.Controls.Add(this.btnRestoreDb);
            this.Controls.Add(this.btnSetYear);
            this.Controls.Add(this.btnDeleteDb);
            this.Controls.Add(this.btnBackupDb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnDeleteYear);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxYears);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStripAdmin);
            this.Controls.Add(this.toolStripAdmin);
            this.Controls.Add(this.menuStripAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripAdmin;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdministration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStat - Administration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStrip toolStripAdmin;
        private System.Windows.Forms.StatusStrip statusStripAdmin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxYears;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddYear;
        private System.Windows.Forms.Button btnDeleteYear;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBackupDb;
        private System.Windows.Forms.Button btnDeleteDb;
        private System.Windows.Forms.Button btnSetYear;
        private System.Windows.Forms.Button btnRestoreDb;
        private System.Windows.Forms.Button btnAchriveYear;
        private System.Windows.Forms.Button btnRetrieveYear;
        private System.Windows.Forms.TextBox tbxActualYear;
        private System.Windows.Forms.Label label4;
    }
}