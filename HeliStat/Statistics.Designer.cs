namespace HeliStat
{
    partial class frmStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatistics));
            this.toolStripStatistics = new System.Windows.Forms.ToolStrip();
            this.menuStripStatistics = new System.Windows.Forms.MenuStrip();
            this.statusStripStatistics = new System.Windows.Forms.StatusStrip();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbxYears = new System.Windows.Forms.ComboBox();
            this.ckbFilterDay = new System.Windows.Forms.CheckBox();
            this.grbFilterDay = new System.Windows.Forms.GroupBox();
            this.grbYear = new System.Windows.Forms.GroupBox();
            this.btnSetFilter = new System.Windows.Forms.Button();
            this.btnSetToday = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.grbFilterDay.SuspendLayout();
            this.grbYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatistics
            // 
            this.toolStripStatistics.Location = new System.Drawing.Point(0, 24);
            this.toolStripStatistics.Name = "toolStripStatistics";
            this.toolStripStatistics.Size = new System.Drawing.Size(914, 25);
            this.toolStripStatistics.TabIndex = 0;
            this.toolStripStatistics.Text = "toolStrip1";
            // 
            // menuStripStatistics
            // 
            this.menuStripStatistics.Location = new System.Drawing.Point(0, 0);
            this.menuStripStatistics.Name = "menuStripStatistics";
            this.menuStripStatistics.Size = new System.Drawing.Size(914, 24);
            this.menuStripStatistics.TabIndex = 1;
            this.menuStripStatistics.Text = "menuStrip1";
            // 
            // statusStripStatistics
            // 
            this.statusStripStatistics.Location = new System.Drawing.Point(0, 578);
            this.statusStripStatistics.Name = "statusStripStatistics";
            this.statusStripStatistics.Size = new System.Drawing.Size(914, 22);
            this.statusStripStatistics.TabIndex = 2;
            this.statusStripStatistics.Text = "statusStrip1";
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Location = new System.Drawing.Point(12, 107);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.ReadOnly = true;
            this.dgvStatistics.Size = new System.Drawing.Size(890, 404);
            this.dgvStatistics.TabIndex = 3;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(12, 532);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(75, 23);
            this.btnExcelExport.TabIndex = 4;
            this.btnExcelExport.Text = "Export";
            this.btnExcelExport.UseVisualStyleBackColor = true;
            // 
            // dtpDay
            // 
            this.dtpDay.CustomFormat = "dd.MM";
            this.dtpDay.Enabled = false;
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDay.Location = new System.Drawing.Point(27, 19);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.ShowUpDown = true;
            this.dtpDay.Size = new System.Drawing.Size(71, 20);
            this.dtpDay.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(94, 532);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // cbxYears
            // 
            this.cbxYears.FormattingEnabled = true;
            this.cbxYears.Location = new System.Drawing.Point(6, 19);
            this.cbxYears.Name = "cbxYears";
            this.cbxYears.Size = new System.Drawing.Size(121, 21);
            this.cbxYears.TabIndex = 8;
            // 
            // ckbFilterDay
            // 
            this.ckbFilterDay.AutoSize = true;
            this.ckbFilterDay.Location = new System.Drawing.Point(6, 22);
            this.ckbFilterDay.Name = "ckbFilterDay";
            this.ckbFilterDay.Size = new System.Drawing.Size(15, 14);
            this.ckbFilterDay.TabIndex = 9;
            this.ckbFilterDay.UseVisualStyleBackColor = true;
            this.ckbFilterDay.CheckedChanged += new System.EventHandler(this.ckbFilterDay_CheckedChanged);
            // 
            // grbFilterDay
            // 
            this.grbFilterDay.Controls.Add(this.btnSetToday);
            this.grbFilterDay.Controls.Add(this.btnSetFilter);
            this.grbFilterDay.Controls.Add(this.dtpDay);
            this.grbFilterDay.Controls.Add(this.ckbFilterDay);
            this.grbFilterDay.Location = new System.Drawing.Point(153, 53);
            this.grbFilterDay.Name = "grbFilterDay";
            this.grbFilterDay.Size = new System.Drawing.Size(269, 48);
            this.grbFilterDay.TabIndex = 10;
            this.grbFilterDay.TabStop = false;
            this.grbFilterDay.Text = "Filter day (of ARR)";
            // 
            // grbYear
            // 
            this.grbYear.Controls.Add(this.cbxYears);
            this.grbYear.Location = new System.Drawing.Point(12, 53);
            this.grbYear.Name = "grbYear";
            this.grbYear.Size = new System.Drawing.Size(135, 48);
            this.grbYear.TabIndex = 11;
            this.grbYear.TabStop = false;
            this.grbYear.Text = "Set year";
            // 
            // btnSetFilter
            // 
            this.btnSetFilter.Location = new System.Drawing.Point(104, 17);
            this.btnSetFilter.Name = "btnSetFilter";
            this.btnSetFilter.Size = new System.Drawing.Size(75, 23);
            this.btnSetFilter.TabIndex = 10;
            this.btnSetFilter.Text = "Set";
            this.btnSetFilter.UseVisualStyleBackColor = true;
            this.btnSetFilter.Click += new System.EventHandler(this.btnSetFilter_Click);
            // 
            // btnSetToday
            // 
            this.btnSetToday.Location = new System.Drawing.Point(185, 17);
            this.btnSetToday.Name = "btnSetToday";
            this.btnSetToday.Size = new System.Drawing.Size(75, 23);
            this.btnSetToday.TabIndex = 11;
            this.btnSetToday.Text = "Today";
            this.btnSetToday.UseVisualStyleBackColor = true;
            this.btnSetToday.Click += new System.EventHandler(this.btnSetToday_Click);
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.grbYear);
            this.Controls.Add(this.grbFilterDay);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.dgvStatistics);
            this.Controls.Add(this.statusStripStatistics);
            this.Controls.Add(this.toolStripStatistics);
            this.Controls.Add(this.menuStripStatistics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripStatistics;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStat - Statistics";
            this.Load += new System.EventHandler(this.frmStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.grbFilterDay.ResumeLayout(false);
            this.grbFilterDay.PerformLayout();
            this.grbYear.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripStatistics;
        private System.Windows.Forms.MenuStrip menuStripStatistics;
        private System.Windows.Forms.StatusStrip statusStripStatistics;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.DateTimePicker dtpDay;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cbxYears;
        private System.Windows.Forms.CheckBox ckbFilterDay;
        private System.Windows.Forms.GroupBox grbFilterDay;
        private System.Windows.Forms.GroupBox grbYear;
        private System.Windows.Forms.Button btnSetToday;
        private System.Windows.Forms.Button btnSetFilter;
    }
}