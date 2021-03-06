﻿namespace HeliStat
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
            this.cbxArrFrom = new System.Windows.Forms.ComboBox();
            this.cbxDepTo = new System.Windows.Forms.ComboBox();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.toolStripBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMov = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTbxActualYear = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripBtnChangeYear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripMov = new System.Windows.Forms.MenuStrip();
            this.statusStripMov = new System.Windows.Forms.StatusStrip();
            this.ckbOvernight = new System.Windows.Forms.CheckBox();
            this.btnSetDateTimeNow = new System.Windows.Forms.Button();
            this.grbFilterDay = new System.Windows.Forms.GroupBox();
            this.btnSetToday = new System.Windows.Forms.Button();
            this.dtpDayFilter = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.toolStripMov.SuspendLayout();
            this.grbFilterDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxAircraftType
            // 
            this.tbxAircraftType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAircraftType.HideSelection = false;
            this.tbxAircraftType.Location = new System.Drawing.Point(13, 155);
            this.tbxAircraftType.Name = "tbxAircraftType";
            this.tbxAircraftType.ReadOnly = true;
            this.tbxAircraftType.Size = new System.Drawing.Size(160, 20);
            this.tbxAircraftType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Registration:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aircraft type:";
            // 
            // tbxOperator
            // 
            this.tbxOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOperator.Location = new System.Drawing.Point(13, 215);
            this.tbxOperator.Name = "tbxOperator";
            this.tbxOperator.ReadOnly = true;
            this.tbxOperator.Size = new System.Drawing.Size(160, 20);
            this.tbxOperator.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operator:";
            // 
            // cbxTypeOfOps
            // 
            this.cbxTypeOfOps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTypeOfOps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypeOfOps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxTypeOfOps.FormattingEnabled = true;
            this.cbxTypeOfOps.Items.AddRange(new object[] {
            "CIV",
            "FOCA",
            "MIL",
            "MIL VIP"});
            this.cbxTypeOfOps.Location = new System.Drawing.Point(13, 275);
            this.cbxTypeOfOps.Name = "cbxTypeOfOps";
            this.cbxTypeOfOps.Size = new System.Drawing.Size(160, 21);
            this.cbxTypeOfOps.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type of operation:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ARR from:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "DEP to:";
            // 
            // btnAddIcaoDes
            // 
            this.btnAddIcaoDes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddIcaoDes.Location = new System.Drawing.Point(13, 368);
            this.btnAddIcaoDes.Name = "btnAddIcaoDes";
            this.btnAddIcaoDes.Size = new System.Drawing.Size(23, 23);
            this.btnAddIcaoDes.TabIndex = 5;
            this.btnAddIcaoDes.Text = "+";
            this.btnAddIcaoDes.UseVisualStyleBackColor = true;
            this.btnAddIcaoDes.Click += new System.EventHandler(this.btnAddIcaoDes_Click);
            // 
            // btnHelicopters
            // 
            this.btnHelicopters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelicopters.Location = new System.Drawing.Point(200, 93);
            this.btnHelicopters.Name = "btnHelicopters";
            this.btnHelicopters.Size = new System.Drawing.Size(75, 23);
            this.btnHelicopters.TabIndex = 1;
            this.btnHelicopters.Text = "Helicopters";
            this.btnHelicopters.UseVisualStyleBackColor = true;
            this.btnHelicopters.Click += new System.EventHandler(this.btnHelicopters_Click);
            // 
            // dtpDateOfFlight
            // 
            this.dtpDateOfFlight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfFlight.CustomFormat = "dd.MM.yyyy";
            this.dtpDateOfFlight.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfFlight.Location = new System.Drawing.Point(392, 526);
            this.dtpDateOfFlight.Name = "dtpDateOfFlight";
            this.dtpDateOfFlight.Size = new System.Drawing.Size(160, 20);
            this.dtpDateOfFlight.TabIndex = 6;
            // 
            // btnSetLand
            // 
            this.btnSetLand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetLand.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSetLand.Location = new System.Drawing.Point(392, 553);
            this.btnSetLand.Name = "btnSetLand";
            this.btnSetLand.Size = new System.Drawing.Size(75, 23);
            this.btnSetLand.TabIndex = 9;
            this.btnSetLand.Text = "Land";
            this.btnSetLand.UseVisualStyleBackColor = false;
            this.btnSetLand.Click += new System.EventHandler(this.btnSetLand_Click);
            // 
            // btnSetTakeOff
            // 
            this.btnSetTakeOff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetTakeOff.BackColor = System.Drawing.Color.IndianRed;
            this.btnSetTakeOff.Location = new System.Drawing.Point(473, 553);
            this.btnSetTakeOff.Name = "btnSetTakeOff";
            this.btnSetTakeOff.Size = new System.Drawing.Size(75, 23);
            this.btnSetTakeOff.TabIndex = 11;
            this.btnSetTakeOff.Text = "Take-off";
            this.btnSetTakeOff.UseVisualStyleBackColor = false;
            this.btnSetTakeOff.Click += new System.EventHandler(this.btnSetTakeOff_Click);
            // 
            // cbxRegistration
            // 
            this.cbxRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRegistration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxRegistration.FormattingEnabled = true;
            this.cbxRegistration.Location = new System.Drawing.Point(13, 95);
            this.cbxRegistration.Name = "cbxRegistration";
            this.cbxRegistration.Size = new System.Drawing.Size(160, 21);
            this.cbxRegistration.TabIndex = 0;
            this.cbxRegistration.SelectedIndexChanged += new System.EventHandler(this.cbxRegistration_SelectedIndexChanged);
            // 
            // dgvMovements
            // 
            this.dgvMovements.AllowUserToAddRows = false;
            this.dgvMovements.AllowUserToDeleteRows = false;
            this.dgvMovements.AllowUserToResizeRows = false;
            this.dgvMovements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovements.Location = new System.Drawing.Point(392, 93);
            this.dgvMovements.MultiSelect = false;
            this.dgvMovements.Name = "dgvMovements";
            this.dgvMovements.ReadOnly = true;
            this.dgvMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovements.Size = new System.Drawing.Size(1000, 427);
            this.dgvMovements.TabIndex = 21;
            this.dgvMovements.SelectionChanged += new System.EventHandler(this.ShowValues);
            // 
            // btnRmvIcaoDes
            // 
            this.btnRmvIcaoDes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRmvIcaoDes.Location = new System.Drawing.Point(42, 368);
            this.btnRmvIcaoDes.Name = "btnRmvIcaoDes";
            this.btnRmvIcaoDes.Size = new System.Drawing.Size(23, 23);
            this.btnRmvIcaoDes.TabIndex = 22;
            this.btnRmvIcaoDes.Text = "-";
            this.btnRmvIcaoDes.UseVisualStyleBackColor = true;
            this.btnRmvIcaoDes.Click += new System.EventHandler(this.btnRmvIcaoDes_Click);
            // 
            // btnDeleteMvmt
            // 
            this.btnDeleteMvmt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMvmt.Location = new System.Drawing.Point(174, 497);
            this.btnDeleteMvmt.Name = "btnDeleteMvmt";
            this.btnDeleteMvmt.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMvmt.TabIndex = 23;
            this.btnDeleteMvmt.Text = "Delete";
            this.btnDeleteMvmt.UseVisualStyleBackColor = true;
            this.btnDeleteMvmt.Click += new System.EventHandler(this.btnDeleteMvmt_Click);
            // 
            // dtpActualTime
            // 
            this.dtpActualTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActualTime.CustomFormat = "HH:mm LT";
            this.dtpActualTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualTime.Location = new System.Drawing.Point(558, 526);
            this.dtpActualTime.Name = "dtpActualTime";
            this.dtpActualTime.ShowUpDown = true;
            this.dtpActualTime.Size = new System.Drawing.Size(160, 20);
            this.dtpActualTime.TabIndex = 10;
            // 
            // btnAddMvmt
            // 
            this.btnAddMvmt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMvmt.Location = new System.Drawing.Point(12, 497);
            this.btnAddMvmt.Name = "btnAddMvmt";
            this.btnAddMvmt.Size = new System.Drawing.Size(75, 23);
            this.btnAddMvmt.TabIndex = 9;
            this.btnAddMvmt.Text = "Add";
            this.btnAddMvmt.UseVisualStyleBackColor = true;
            this.btnAddMvmt.Click += new System.EventHandler(this.btnAddMvmt_Click);
            // 
            // btnUpdateMvmt
            // 
            this.btnUpdateMvmt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateMvmt.Location = new System.Drawing.Point(93, 497);
            this.btnUpdateMvmt.Name = "btnUpdateMvmt";
            this.btnUpdateMvmt.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateMvmt.TabIndex = 9;
            this.btnUpdateMvmt.Text = "Update";
            this.btnUpdateMvmt.UseVisualStyleBackColor = true;
            this.btnUpdateMvmt.Click += new System.EventHandler(this.btnUpdateMvmt_Click);
            // 
            // cbxArrFrom
            // 
            this.cbxArrFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxArrFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArrFrom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxArrFrom.FormattingEnabled = true;
            this.cbxArrFrom.Location = new System.Drawing.Point(13, 333);
            this.cbxArrFrom.Name = "cbxArrFrom";
            this.cbxArrFrom.Size = new System.Drawing.Size(160, 21);
            this.cbxArrFrom.TabIndex = 28;
            // 
            // cbxDepTo
            // 
            this.cbxDepTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDepTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxDepTo.FormattingEnabled = true;
            this.cbxDepTo.Location = new System.Drawing.Point(200, 333);
            this.cbxDepTo.Name = "cbxDepTo";
            this.cbxDepTo.Size = new System.Drawing.Size(160, 21);
            this.cbxDepTo.TabIndex = 29;
            // 
            // btnClearFields
            // 
            this.btnClearFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFields.Location = new System.Drawing.Point(12, 455);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(237, 23);
            this.btnClearFields.TabIndex = 38;
            this.btnClearFields.Text = "Clear fields";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // toolStripBtnAdd
            // 
            this.toolStripBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAdd.Image = global::HeliStat.Properties.Resources.Plus;
            this.toolStripBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAdd.Name = "toolStripBtnAdd";
            this.toolStripBtnAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnAdd.Text = "Add Movement";
            this.toolStripBtnAdd.Click += new System.EventHandler(this.toolStripBtnAdd_Click);
            // 
            // toolStripBtnUpdate
            // 
            this.toolStripBtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnUpdate.Image = global::HeliStat.Properties.Resources.Update;
            this.toolStripBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUpdate.Name = "toolStripBtnUpdate";
            this.toolStripBtnUpdate.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnUpdate.Text = "Update Movement";
            this.toolStripBtnUpdate.Click += new System.EventHandler(this.toolStripBtnUpdate_Click);
            // 
            // toolStripBtnDelete
            // 
            this.toolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDelete.Image = global::HeliStat.Properties.Resources.Delete;
            this.toolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDelete.Name = "toolStripBtnDelete";
            this.toolStripBtnDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDelete.Text = "Delete Movement";
            this.toolStripBtnDelete.Click += new System.EventHandler(this.toolStripBtnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMov
            // 
            this.toolStripMov.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAdd,
            this.toolStripBtnUpdate,
            this.toolStripBtnDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTbxActualYear,
            this.toolStripBtnChangeYear,
            this.toolStripSeparator2});
            this.toolStripMov.Location = new System.Drawing.Point(0, 24);
            this.toolStripMov.Name = "toolStripMov";
            this.toolStripMov.Size = new System.Drawing.Size(1404, 25);
            this.toolStripMov.TabIndex = 39;
            this.toolStripMov.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "Year:";
            // 
            // toolStripTbxActualYear
            // 
            this.toolStripTbxActualYear.Name = "toolStripTbxActualYear";
            this.toolStripTbxActualYear.ReadOnly = true;
            this.toolStripTbxActualYear.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripBtnChangeYear
            // 
            this.toolStripBtnChangeYear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnChangeYear.Image = global::HeliStat.Properties.Resources.calendar;
            this.toolStripBtnChangeYear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnChangeYear.Name = "toolStripBtnChangeYear";
            this.toolStripBtnChangeYear.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnChangeYear.Text = "Change Year";
            this.toolStripBtnChangeYear.Click += new System.EventHandler(this.toolStripBtnChangeYear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // menuStripMov
            // 
            this.menuStripMov.Location = new System.Drawing.Point(0, 0);
            this.menuStripMov.Name = "menuStripMov";
            this.menuStripMov.Size = new System.Drawing.Size(1404, 24);
            this.menuStripMov.TabIndex = 40;
            this.menuStripMov.Text = "menuStrip1";
            // 
            // statusStripMov
            // 
            this.statusStripMov.Location = new System.Drawing.Point(0, 594);
            this.statusStripMov.Name = "statusStripMov";
            this.statusStripMov.Size = new System.Drawing.Size(1404, 22);
            this.statusStripMov.SizingGrip = false;
            this.statusStripMov.TabIndex = 41;
            this.statusStripMov.Text = "statusStrip1";
            // 
            // ckbOvernight
            // 
            this.ckbOvernight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbOvernight.AutoSize = true;
            this.ckbOvernight.Location = new System.Drawing.Point(13, 406);
            this.ckbOvernight.Name = "ckbOvernight";
            this.ckbOvernight.Size = new System.Drawing.Size(78, 17);
            this.ckbOvernight.TabIndex = 42;
            this.ckbOvernight.Text = "Overnight?";
            this.ckbOvernight.UseVisualStyleBackColor = true;
            // 
            // btnSetDateTimeNow
            // 
            this.btnSetDateTimeNow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDateTimeNow.Location = new System.Drawing.Point(724, 525);
            this.btnSetDateTimeNow.Name = "btnSetDateTimeNow";
            this.btnSetDateTimeNow.Size = new System.Drawing.Size(75, 23);
            this.btnSetDateTimeNow.TabIndex = 43;
            this.btnSetDateTimeNow.Text = "Now";
            this.btnSetDateTimeNow.UseVisualStyleBackColor = true;
            this.btnSetDateTimeNow.Click += new System.EventHandler(this.btnSetDateTimeNow_Click);
            // 
            // grbFilterDay
            // 
            this.grbFilterDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFilterDay.Controls.Add(this.btnSetToday);
            this.grbFilterDay.Controls.Add(this.dtpDayFilter);
            this.grbFilterDay.Location = new System.Drawing.Point(392, 39);
            this.grbFilterDay.Name = "grbFilterDay";
            this.grbFilterDay.Size = new System.Drawing.Size(166, 48);
            this.grbFilterDay.TabIndex = 45;
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
            this.dtpDayFilter.ValueChanged += new System.EventHandler(this.dtpDayFilter_ValueChanged);
            // 
            // frmMovements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1404, 616);
            this.Controls.Add(this.grbFilterDay);
            this.Controls.Add(this.btnSetDateTimeNow);
            this.Controls.Add(this.ckbOvernight);
            this.Controls.Add(this.statusStripMov);
            this.Controls.Add(this.toolStripMov);
            this.Controls.Add(this.menuStripMov);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.cbxDepTo);
            this.Controls.Add(this.cbxArrFrom);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMov;
            this.MinimizeBox = false;
            this.Name = "frmMovements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStat - Movements";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMovements_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.toolStripMov.ResumeLayout(false);
            this.toolStripMov.PerformLayout();
            this.grbFilterDay.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cbxArrFrom;
        private System.Windows.Forms.ComboBox cbxDepTo;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdd;
        private System.Windows.Forms.ToolStripButton toolStripBtnUpdate;
        private System.Windows.Forms.ToolStripButton toolStripBtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStripMov;
        private System.Windows.Forms.MenuStrip menuStripMov;
        private System.Windows.Forms.StatusStrip statusStripMov;
        private System.Windows.Forms.CheckBox ckbOvernight;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTbxActualYear;
        private System.Windows.Forms.ToolStripButton toolStripBtnChangeYear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnSetDateTimeNow;
        private System.Windows.Forms.GroupBox grbFilterDay;
        private System.Windows.Forms.Button btnSetToday;
        private System.Windows.Forms.DateTimePicker dtpDayFilter;
    }
}