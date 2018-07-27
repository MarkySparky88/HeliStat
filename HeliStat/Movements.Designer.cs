namespace HeliStat
{
    partial class frmMovements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovements));
            this.tbxAircraftType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxOperator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTypeOfOps = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddIcaoDes = new System.Windows.Forms.Button();
            this.btnHelicopters = new System.Windows.Forms.Button();
            this.dtpDateOfFlight = new System.Windows.Forms.DateTimePicker();
            this.btnSetLand = new System.Windows.Forms.Button();
            this.btnSetTakeOff = new System.Windows.Forms.Button();
            this.cbxRegistration = new System.Windows.Forms.ComboBox();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.btnRmvIcaoDes = new System.Windows.Forms.Button();
            this.btnDeleteMvmt = new System.Windows.Forms.Button();
            this.dtpActualTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddMvmt = new System.Windows.Forms.Button();
            this.btnUpdateMvmt = new System.Windows.Forms.Button();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.btnAddYear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRemoveYear = new System.Windows.Forms.Button();
            this.cbxArrFrom = new System.Windows.Forms.ComboBox();
            this.cbxDepTo = new System.Windows.Forms.ComboBox();
            this.btnClearFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxAircraftType
            // 
            this.tbxAircraftType.HideSelection = false;
            this.tbxAircraftType.Location = new System.Drawing.Point(13, 95);
            this.tbxAircraftType.Name = "tbxAircraftType";
            this.tbxAircraftType.ReadOnly = true;
            this.tbxAircraftType.Size = new System.Drawing.Size(160, 20);
            this.tbxAircraftType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Registration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aircraft type:";
            // 
            // tbxOperator
            // 
            this.tbxOperator.Location = new System.Drawing.Point(13, 155);
            this.tbxOperator.Name = "tbxOperator";
            this.tbxOperator.ReadOnly = true;
            this.tbxOperator.Size = new System.Drawing.Size(160, 20);
            this.tbxOperator.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operator:";
            // 
            // cbxTypeOfOps
            // 
            this.cbxTypeOfOps.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxTypeOfOps.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTypeOfOps.FormattingEnabled = true;
            this.cbxTypeOfOps.Items.AddRange(new object[] {
            "CIV",
            "FOCA",
            "MIL",
            "MIL VIP"});
            this.cbxTypeOfOps.Location = new System.Drawing.Point(13, 215);
            this.cbxTypeOfOps.Name = "cbxTypeOfOps";
            this.cbxTypeOfOps.Size = new System.Drawing.Size(160, 21);
            this.cbxTypeOfOps.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type of operation:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ARR from:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "DEP to:";
            // 
            // btnAddIcaoDes
            // 
            this.btnAddIcaoDes.Location = new System.Drawing.Point(13, 308);
            this.btnAddIcaoDes.Name = "btnAddIcaoDes";
            this.btnAddIcaoDes.Size = new System.Drawing.Size(23, 23);
            this.btnAddIcaoDes.TabIndex = 5;
            this.btnAddIcaoDes.Text = "+";
            this.btnAddIcaoDes.UseVisualStyleBackColor = true;
            this.btnAddIcaoDes.Click += new System.EventHandler(this.btnAddIcaoDes_Click);
            // 
            // btnHelicopters
            // 
            this.btnHelicopters.Location = new System.Drawing.Point(200, 33);
            this.btnHelicopters.Name = "btnHelicopters";
            this.btnHelicopters.Size = new System.Drawing.Size(75, 23);
            this.btnHelicopters.TabIndex = 1;
            this.btnHelicopters.Text = "Helicopters";
            this.btnHelicopters.UseVisualStyleBackColor = true;
            this.btnHelicopters.Click += new System.EventHandler(this.btnHelicopters_Click);
            // 
            // dtpDateOfFlight
            // 
            this.dtpDateOfFlight.CustomFormat = "dd.MM.yyyy";
            this.dtpDateOfFlight.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfFlight.Location = new System.Drawing.Point(392, 567);
            this.dtpDateOfFlight.Name = "dtpDateOfFlight";
            this.dtpDateOfFlight.Size = new System.Drawing.Size(160, 20);
            this.dtpDateOfFlight.TabIndex = 6;
            // 
            // btnSetLand
            // 
            this.btnSetLand.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSetLand.Location = new System.Drawing.Point(392, 594);
            this.btnSetLand.Name = "btnSetLand";
            this.btnSetLand.Size = new System.Drawing.Size(75, 23);
            this.btnSetLand.TabIndex = 9;
            this.btnSetLand.Text = "Land";
            this.btnSetLand.UseVisualStyleBackColor = false;
            this.btnSetLand.Click += new System.EventHandler(this.btnSetLand_Click);
            // 
            // btnSetTakeOff
            // 
            this.btnSetTakeOff.BackColor = System.Drawing.Color.IndianRed;
            this.btnSetTakeOff.Location = new System.Drawing.Point(473, 594);
            this.btnSetTakeOff.Name = "btnSetTakeOff";
            this.btnSetTakeOff.Size = new System.Drawing.Size(75, 23);
            this.btnSetTakeOff.TabIndex = 11;
            this.btnSetTakeOff.Text = "Take-off";
            this.btnSetTakeOff.UseVisualStyleBackColor = false;
            this.btnSetTakeOff.Click += new System.EventHandler(this.btnSetTakeOff_Click);
            // 
            // cbxRegistration
            // 
            this.cbxRegistration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxRegistration.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxRegistration.FormattingEnabled = true;
            this.cbxRegistration.Location = new System.Drawing.Point(13, 35);
            this.cbxRegistration.Name = "cbxRegistration";
            this.cbxRegistration.Size = new System.Drawing.Size(160, 21);
            this.cbxRegistration.TabIndex = 0;
            this.cbxRegistration.SelectedIndexChanged += new System.EventHandler(this.cbxRegistration_SelectedIndexChanged);
            // 
            // dgvMovements
            // 
            this.dgvMovements.AllowUserToAddRows = false;
            this.dgvMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovements.Location = new System.Drawing.Point(392, 76);
            this.dgvMovements.MultiSelect = false;
            this.dgvMovements.Name = "dgvMovements";
            this.dgvMovements.ReadOnly = true;
            this.dgvMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovements.Size = new System.Drawing.Size(731, 473);
            this.dgvMovements.TabIndex = 21;
            this.dgvMovements.SelectionChanged += new System.EventHandler(this.ShowValues);
            // 
            // btnRmvIcaoDes
            // 
            this.btnRmvIcaoDes.Location = new System.Drawing.Point(42, 308);
            this.btnRmvIcaoDes.Name = "btnRmvIcaoDes";
            this.btnRmvIcaoDes.Size = new System.Drawing.Size(23, 23);
            this.btnRmvIcaoDes.TabIndex = 22;
            this.btnRmvIcaoDes.Text = "-";
            this.btnRmvIcaoDes.UseVisualStyleBackColor = true;
            this.btnRmvIcaoDes.Click += new System.EventHandler(this.btnRmvIcaoDes_Click);
            // 
            // btnDeleteMvmt
            // 
            this.btnDeleteMvmt.Location = new System.Drawing.Point(174, 437);
            this.btnDeleteMvmt.Name = "btnDeleteMvmt";
            this.btnDeleteMvmt.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMvmt.TabIndex = 23;
            this.btnDeleteMvmt.Text = "Delete";
            this.btnDeleteMvmt.UseVisualStyleBackColor = true;
            this.btnDeleteMvmt.Click += new System.EventHandler(this.btnDeleteMvmt_Click);
            // 
            // dtpActualTime
            // 
            this.dtpActualTime.CustomFormat = "HH:mm LT";
            this.dtpActualTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualTime.Location = new System.Drawing.Point(558, 567);
            this.dtpActualTime.Name = "dtpActualTime";
            this.dtpActualTime.ShowUpDown = true;
            this.dtpActualTime.Size = new System.Drawing.Size(160, 20);
            this.dtpActualTime.TabIndex = 10;
            // 
            // btnAddMvmt
            // 
            this.btnAddMvmt.Location = new System.Drawing.Point(12, 437);
            this.btnAddMvmt.Name = "btnAddMvmt";
            this.btnAddMvmt.Size = new System.Drawing.Size(75, 23);
            this.btnAddMvmt.TabIndex = 9;
            this.btnAddMvmt.Text = "Add";
            this.btnAddMvmt.UseVisualStyleBackColor = true;
            this.btnAddMvmt.Click += new System.EventHandler(this.btnAddMvmt_Click);
            // 
            // btnUpdateMvmt
            // 
            this.btnUpdateMvmt.Location = new System.Drawing.Point(93, 437);
            this.btnUpdateMvmt.Name = "btnUpdateMvmt";
            this.btnUpdateMvmt.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateMvmt.TabIndex = 9;
            this.btnUpdateMvmt.Text = "Update";
            this.btnUpdateMvmt.UseVisualStyleBackColor = true;
            this.btnUpdateMvmt.Click += new System.EventHandler(this.btnUpdateMvmt_Click);
            // 
            // cbxYear
            // 
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(392, 35);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(121, 21);
            this.cbxYear.TabIndex = 24;
            // 
            // btnAddYear
            // 
            this.btnAddYear.Location = new System.Drawing.Point(525, 33);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(23, 23);
            this.btnAddYear.TabIndex = 25;
            this.btnAddYear.Text = "+";
            this.btnAddYear.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Year:";
            // 
            // btnRemoveYear
            // 
            this.btnRemoveYear.Location = new System.Drawing.Point(554, 33);
            this.btnRemoveYear.Name = "btnRemoveYear";
            this.btnRemoveYear.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveYear.TabIndex = 27;
            this.btnRemoveYear.Text = "-";
            this.btnRemoveYear.UseVisualStyleBackColor = true;
            // 
            // cbxArrFrom
            // 
            this.cbxArrFrom.FormattingEnabled = true;
            this.cbxArrFrom.Location = new System.Drawing.Point(13, 273);
            this.cbxArrFrom.Name = "cbxArrFrom";
            this.cbxArrFrom.Size = new System.Drawing.Size(160, 21);
            this.cbxArrFrom.TabIndex = 28;
            // 
            // cbxDepTo
            // 
            this.cbxDepTo.FormattingEnabled = true;
            this.cbxDepTo.Location = new System.Drawing.Point(200, 273);
            this.cbxDepTo.Name = "cbxDepTo";
            this.cbxDepTo.Size = new System.Drawing.Size(160, 21);
            this.cbxDepTo.TabIndex = 29;
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(12, 388);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(237, 23);
            this.btnClearFields.TabIndex = 38;
            this.btnClearFields.Text = "Clear fields";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // frmMovements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 633);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.cbxDepTo);
            this.Controls.Add(this.cbxArrFrom);
            this.Controls.Add(this.btnRemoveYear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.btnDeleteMvmt);
            this.Controls.Add(this.btnRmvIcaoDes);
            this.Controls.Add(this.dgvMovements);
            this.Controls.Add(this.cbxRegistration);
            this.Controls.Add(this.btnSetTakeOff);
            this.Controls.Add(this.btnUpdateMvmt);
            this.Controls.Add(this.btnAddMvmt);
            this.Controls.Add(this.btnSetLand);
            this.Controls.Add(this.dtpDateOfFlight);
            this.Controls.Add(this.dtpActualTime);
            this.Controls.Add(this.btnHelicopters);
            this.Controls.Add(this.btnAddIcaoDes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxTypeOfOps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxOperator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAircraftType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMovements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStats v0.0.1 - Movements";
            this.Load += new System.EventHandler(this.frmMovements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxAircraftType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTypeOfOps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddIcaoDes;
        private System.Windows.Forms.Button btnHelicopters;
        private System.Windows.Forms.DateTimePicker dtpDateOfFlight;
        private System.Windows.Forms.Button btnSetLand;
        private System.Windows.Forms.Button btnSetTakeOff;
        private System.Windows.Forms.ComboBox cbxRegistration;
        private System.Windows.Forms.DataGridView dgvMovements;
        private System.Windows.Forms.Button btnRmvIcaoDes;
        private System.Windows.Forms.Button btnDeleteMvmt;
        private System.Windows.Forms.DateTimePicker dtpActualTime;
        private System.Windows.Forms.Button btnAddMvmt;
        private System.Windows.Forms.Button btnUpdateMvmt;
        private System.Windows.Forms.ComboBox cbxYear;
        private System.Windows.Forms.Button btnAddYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemoveYear;
        private System.Windows.Forms.ComboBox cbxArrFrom;
        private System.Windows.Forms.ComboBox cbxDepTo;
        private System.Windows.Forms.Button btnClearFields;
    }
}