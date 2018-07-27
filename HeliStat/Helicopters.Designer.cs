namespace HeliStat
{
    partial class frmHelicopters
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
            System.Windows.Forms.Label registrationLabel;
            System.Windows.Forms.Label aircraftTypeLabel;
            System.Windows.Forms.Label noOfEngLabel;
            System.Windows.Forms.Label operatorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelicopters));
            this.btnAddNewAircraftType = new System.Windows.Forms.Button();
            this.btnAddNewOperator = new System.Windows.Forms.Button();
            this.cbxAircraftType = new System.Windows.Forms.ComboBox();
            this.cbxNoOfEng = new System.Windows.Forms.ComboBox();
            this.cbxOperator = new System.Windows.Forms.ComboBox();
            this.tbxRegistration = new System.Windows.Forms.TextBox();
            this.btnAddHeli = new System.Windows.Forms.Button();
            this.dgvHelicopters = new System.Windows.Forms.DataGridView();
            this.btnRemoveHeli = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateHeli = new System.Windows.Forms.Button();
            this.btnRemoveAircraftType = new System.Windows.Forms.Button();
            this.btnRemoveOperator = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            registrationLabel = new System.Windows.Forms.Label();
            aircraftTypeLabel = new System.Windows.Forms.Label();
            noOfEngLabel = new System.Windows.Forms.Label();
            operatorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelicopters)).BeginInit();
            this.SuspendLayout();
            // 
            // registrationLabel
            // 
            registrationLabel.AutoSize = true;
            registrationLabel.Location = new System.Drawing.Point(12, 66);
            registrationLabel.Name = "registrationLabel";
            registrationLabel.Size = new System.Drawing.Size(66, 13);
            registrationLabel.TabIndex = 16;
            registrationLabel.Text = "Registration:";
            // 
            // aircraftTypeLabel
            // 
            aircraftTypeLabel.AutoSize = true;
            aircraftTypeLabel.Location = new System.Drawing.Point(12, 92);
            aircraftTypeLabel.Name = "aircraftTypeLabel";
            aircraftTypeLabel.Size = new System.Drawing.Size(70, 13);
            aircraftTypeLabel.TabIndex = 18;
            aircraftTypeLabel.Text = "Aircraft Type:";
            // 
            // noOfEngLabel
            // 
            noOfEngLabel.AutoSize = true;
            noOfEngLabel.Location = new System.Drawing.Point(12, 118);
            noOfEngLabel.Name = "noOfEngLabel";
            noOfEngLabel.Size = new System.Drawing.Size(60, 13);
            noOfEngLabel.TabIndex = 20;
            noOfEngLabel.Text = "No Of Eng:";
            // 
            // operatorLabel
            // 
            operatorLabel.AutoSize = true;
            operatorLabel.Location = new System.Drawing.Point(12, 144);
            operatorLabel.Name = "operatorLabel";
            operatorLabel.Size = new System.Drawing.Size(51, 13);
            operatorLabel.TabIndex = 22;
            operatorLabel.Text = "Operator:";
            // 
            // btnAddNewAircraftType
            // 
            this.btnAddNewAircraftType.Location = new System.Drawing.Point(214, 87);
            this.btnAddNewAircraftType.Name = "btnAddNewAircraftType";
            this.btnAddNewAircraftType.Size = new System.Drawing.Size(23, 23);
            this.btnAddNewAircraftType.TabIndex = 12;
            this.btnAddNewAircraftType.Text = "+";
            this.btnAddNewAircraftType.UseVisualStyleBackColor = true;
            this.btnAddNewAircraftType.Click += new System.EventHandler(this.btnAddNewAircraftType_Click);
            // 
            // btnAddNewOperator
            // 
            this.btnAddNewOperator.Location = new System.Drawing.Point(214, 139);
            this.btnAddNewOperator.Name = "btnAddNewOperator";
            this.btnAddNewOperator.Size = new System.Drawing.Size(23, 23);
            this.btnAddNewOperator.TabIndex = 13;
            this.btnAddNewOperator.Text = "+";
            this.btnAddNewOperator.UseVisualStyleBackColor = true;
            this.btnAddNewOperator.Click += new System.EventHandler(this.btnAddNewOperator_Click);
            // 
            // cbxAircraftType
            // 
            this.cbxAircraftType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxAircraftType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAircraftType.FormattingEnabled = true;
            this.cbxAircraftType.Location = new System.Drawing.Point(88, 89);
            this.cbxAircraftType.Name = "cbxAircraftType";
            this.cbxAircraftType.Size = new System.Drawing.Size(100, 21);
            this.cbxAircraftType.TabIndex = 25;
            // 
            // cbxNoOfEng
            // 
            this.cbxNoOfEng.FormattingEnabled = true;
            this.cbxNoOfEng.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbxNoOfEng.Location = new System.Drawing.Point(88, 115);
            this.cbxNoOfEng.Name = "cbxNoOfEng";
            this.cbxNoOfEng.Size = new System.Drawing.Size(100, 21);
            this.cbxNoOfEng.TabIndex = 26;
            // 
            // cbxOperator
            // 
            this.cbxOperator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxOperator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxOperator.FormattingEnabled = true;
            this.cbxOperator.Location = new System.Drawing.Point(88, 141);
            this.cbxOperator.Name = "cbxOperator";
            this.cbxOperator.Size = new System.Drawing.Size(100, 21);
            this.cbxOperator.TabIndex = 27;
            // 
            // tbxRegistration
            // 
            this.tbxRegistration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxRegistration.Location = new System.Drawing.Point(88, 63);
            this.tbxRegistration.Name = "tbxRegistration";
            this.tbxRegistration.ShortcutsEnabled = false;
            this.tbxRegistration.Size = new System.Drawing.Size(100, 20);
            this.tbxRegistration.TabIndex = 28;
            this.tbxRegistration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxRegistration_KeyPress);
            // 
            // btnAddHeli
            // 
            this.btnAddHeli.Location = new System.Drawing.Point(15, 263);
            this.btnAddHeli.Name = "btnAddHeli";
            this.btnAddHeli.Size = new System.Drawing.Size(251, 23);
            this.btnAddHeli.TabIndex = 29;
            this.btnAddHeli.Text = "Add Heli";
            this.btnAddHeli.UseVisualStyleBackColor = true;
            this.btnAddHeli.Click += new System.EventHandler(this.btnAddHeli_Click);
            // 
            // dgvHelicopters
            // 
            this.dgvHelicopters.AllowUserToAddRows = false;
            this.dgvHelicopters.AllowUserToDeleteRows = false;
            this.dgvHelicopters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHelicopters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHelicopters.Location = new System.Drawing.Point(320, 46);
            this.dgvHelicopters.MultiSelect = false;
            this.dgvHelicopters.Name = "dgvHelicopters";
            this.dgvHelicopters.ReadOnly = true;
            this.dgvHelicopters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHelicopters.Size = new System.Drawing.Size(516, 511);
            this.dgvHelicopters.TabIndex = 30;
            this.dgvHelicopters.SelectionChanged += new System.EventHandler(this.ShowValues);
            // 
            // btnRemoveHeli
            // 
            this.btnRemoveHeli.Location = new System.Drawing.Point(15, 321);
            this.btnRemoveHeli.Name = "btnRemoveHeli";
            this.btnRemoveHeli.Size = new System.Drawing.Size(251, 23);
            this.btnRemoveHeli.TabIndex = 31;
            this.btnRemoveHeli.Text = "Remove Heli";
            this.btnRemoveHeli.UseVisualStyleBackColor = true;
            this.btnRemoveHeli.Click += new System.EventHandler(this.btnRemoveHeli_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(15, 534);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateHeli
            // 
            this.btnUpdateHeli.Location = new System.Drawing.Point(15, 292);
            this.btnUpdateHeli.Name = "btnUpdateHeli";
            this.btnUpdateHeli.Size = new System.Drawing.Size(251, 23);
            this.btnUpdateHeli.TabIndex = 34;
            this.btnUpdateHeli.Text = "Update Heli";
            this.btnUpdateHeli.UseVisualStyleBackColor = true;
            this.btnUpdateHeli.Click += new System.EventHandler(this.btnUpdateHeli_Click);
            // 
            // btnRemoveAircraftType
            // 
            this.btnRemoveAircraftType.Location = new System.Drawing.Point(243, 87);
            this.btnRemoveAircraftType.Name = "btnRemoveAircraftType";
            this.btnRemoveAircraftType.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveAircraftType.TabIndex = 35;
            this.btnRemoveAircraftType.Text = "-";
            this.btnRemoveAircraftType.UseVisualStyleBackColor = true;
            this.btnRemoveAircraftType.Click += new System.EventHandler(this.btnRemoveAircraftType_Click);
            // 
            // btnRemoveOperator
            // 
            this.btnRemoveOperator.Location = new System.Drawing.Point(243, 139);
            this.btnRemoveOperator.Name = "btnRemoveOperator";
            this.btnRemoveOperator.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveOperator.TabIndex = 36;
            this.btnRemoveOperator.Text = "-";
            this.btnRemoveOperator.UseVisualStyleBackColor = true;
            this.btnRemoveOperator.Click += new System.EventHandler(this.btnRemoveOperator_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(15, 182);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(251, 23);
            this.btnClearFields.TabIndex = 37;
            this.btnClearFields.Text = "Clear fields";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // frmHelicopters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 569);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.btnRemoveOperator);
            this.Controls.Add(this.btnRemoveAircraftType);
            this.Controls.Add(this.btnUpdateHeli);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveHeli);
            this.Controls.Add(this.dgvHelicopters);
            this.Controls.Add(this.btnAddHeli);
            this.Controls.Add(this.tbxRegistration);
            this.Controls.Add(this.cbxOperator);
            this.Controls.Add(this.cbxNoOfEng);
            this.Controls.Add(this.cbxAircraftType);
            this.Controls.Add(registrationLabel);
            this.Controls.Add(aircraftTypeLabel);
            this.Controls.Add(noOfEngLabel);
            this.Controls.Add(operatorLabel);
            this.Controls.Add(this.btnAddNewOperator);
            this.Controls.Add(this.btnAddNewAircraftType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHelicopters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStats v0.0.1 - Helicopters";
            this.Load += new System.EventHandler(this.frmHelicopters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHelicopters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddNewAircraftType;
        private System.Windows.Forms.Button btnAddNewOperator;
        private System.Windows.Forms.ComboBox cbxAircraftType;
        private System.Windows.Forms.ComboBox cbxNoOfEng;
        private System.Windows.Forms.ComboBox cbxOperator;
        private System.Windows.Forms.TextBox tbxRegistration;
        private System.Windows.Forms.Button btnAddHeli;
        private System.Windows.Forms.DataGridView dgvHelicopters;
        private System.Windows.Forms.Button btnRemoveHeli;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdateHeli;
        private System.Windows.Forms.Button btnRemoveAircraftType;
        private System.Windows.Forms.Button btnRemoveOperator;
        private System.Windows.Forms.Button btnClearFields;
    }
}