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
            this.dtpDayFilter = new System.Windows.Forms.DateTimePicker();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbxYears = new System.Windows.Forms.ComboBox();
            this.grbFilterDay = new System.Windows.Forms.GroupBox();
            this.btnSetToday = new System.Windows.Forms.Button();
            this.grbSelectYear = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.grbFilterDay.SuspendLayout();
            this.grbSelectYear.SuspendLayout();
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
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // dtpDayFilter
            // 
            this.dtpDayFilter.Checked = false;
            this.dtpDayFilter.CustomFormat = "dd.MM";
            this.dtpDayFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayFilter.Location = new System.Drawing.Point(6, 20);
            this.dtpDayFilter.Name = "dtpDayFilter";
            this.dtpDayFilter.ShowCheckBox = true;
            this.dtpDayFilter.ShowUpDown = true;
            this.dtpDayFilter.Size = new System.Drawing.Size(71, 20);
            this.dtpDayFilter.TabIndex = 6;
            this.dtpDayFilter.ValueChanged += new System.EventHandler(this.dtpDayFilter_ValueChanged_1);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
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
            this.cbxYears.SelectedIndexChanged += new System.EventHandler(this.cbxYears_SelectedIndexChanged);
            // 
            // grbFilterDay
            // 
            this.grbFilterDay.Controls.Add(this.btnSetToday);
            this.grbFilterDay.Controls.Add(this.dtpDayFilter);
            this.grbFilterDay.Location = new System.Drawing.Point(153, 53);
            this.grbFilterDay.Name = "grbFilterDay";
            this.grbFilterDay.Size = new System.Drawing.Size(166, 48);
            this.grbFilterDay.TabIndex = 10;
            this.grbFilterDay.TabStop = false;
            this.grbFilterDay.Text = "Filter day (of ARR)";
            // 
            // btnSetToday
            // 
            this.btnSetToday.Location = new System.Drawing.Point(83, 19);
            this.btnSetToday.Name = "btnSetToday";
            this.btnSetToday.Size = new System.Drawing.Size(75, 23);
            this.btnSetToday.TabIndex = 11;
            this.btnSetToday.Text = "Today";
            this.btnSetToday.UseVisualStyleBackColor = true;
            this.btnSetToday.Click += new System.EventHandler(this.btnSetToday_Click);
            // 
            // grbSelectYear
            // 
            this.grbSelectYear.Controls.Add(this.cbxYears);
            this.grbSelectYear.Location = new System.Drawing.Point(12, 53);
            this.grbSelectYear.Name = "grbSelectYear";
            this.grbSelectYear.Size = new System.Drawing.Size(135, 48);
            this.grbSelectYear.TabIndex = 11;
            this.grbSelectYear.TabStop = false;
            this.grbSelectYear.Text = "Select year";
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.grbSelectYear);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.grbFilterDay.ResumeLayout(false);
            this.grbSelectYear.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripStatistics;
        private System.Windows.Forms.MenuStrip menuStripStatistics;
        private System.Windows.Forms.StatusStrip statusStripStatistics;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.DateTimePicker dtpDayFilter;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cbxYears;
        private System.Windows.Forms.GroupBox grbFilterDay;
        private System.Windows.Forms.GroupBox grbSelectYear;
        private System.Windows.Forms.Button btnSetToday;
    }
}