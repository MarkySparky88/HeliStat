﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMovements : Form
    {
        private frmAdministration administration = new frmAdministration();
        
        // Constructor
        public frmMovements()
        {
            InitializeComponent();
            timerMovements.Start();
            // TODO correct position for event delegate? In Video Kurs ist es so beschrieben, diesen im Constructor einzuhängen, aber warum? Könnte der nicht sonst wo sein?
            administration.ActualYearChanged += Administration_ActualYearChanged;
            // TODO combine loading of datagridview and comboboxes upon form load?
            // TODO bind comboboxes as well to datasource (dataset / datatable)??
            // TODO gehört das nicht auch in die Load form function? Wie das Laden des Datagridview? (ganzes Projekt!)
            FillCbxRegistration();
            FillCbxArrDep();
        }

        // Load form
        private void frmMovements_Load(object sender, EventArgs e)
        {
            GetActualYear();
            DisplayActualYear();
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
        }

        /// <summary>
        /// Fill boxes and views
        /// </summary>

        // Fill datagridview
        private DataTable FillDataGridView(string tableName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = string.Format("SELECT * FROM {0} WHERE Year = @Year", tableName);

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Year", GetActualYear());
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return dataTable;
        }

        // Fill combobox registration
        public void FillCbxRegistration()
        {
            cbxRegistration.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblHelicopters ORDER BY Registration";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Registration"));
                                    cbxRegistration.Items.Add(addItem);
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Fill comboboxes "ARR from" & "DEP to"
        private void FillCbxArrDep()
        {
            cbxArrFrom.Items.Clear();
            cbxDepTo.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblAirportCodes ORDER BY AirportCode";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("AirportCode"));
                                    cbxArrFrom.Items.Add(addItem);
                                    cbxDepTo.Items.Add(addItem);
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "Helicopters"
        private void btnHelicopters_Click(object sender, EventArgs e)
        {
            frmHelicopters helicopters = new frmHelicopters();

            if (helicopters.ShowDialog() == DialogResult.Cancel)
            {
                FillCbxRegistration();
            }
        }

        // Button "+" (ICAO Designator)
        private void btnAddIcaoDes_Click(object sender, EventArgs e)
        {
            frmMovementsAddIcaoDes addIcaoDes = new frmMovementsAddIcaoDes();

            while (addIcaoDes.UserInput == false)
            {
                if (addIcaoDes.ShowDialog() == DialogResult.OK && addIcaoDes.UserInput == true)
                {
                    if (!CheckIfDesignatorExists(addIcaoDes))
                    {
                        AddIcaoDesignator(addIcaoDes);
                    }
                    else
                    {
                        MessageBox.Show("This ICAO-Designator already exists.\nEnter a new ICAO-Designator.",
                            "ICAO-Designator exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        addIcaoDes.UserInput = false;
                    }

                }
            }
        }

        // Button "-" (ICAO Designator)
        private void btnRmvIcaoDes_Click(object sender, EventArgs e)
        {
            RemoveIcaoDesignator();
        }

        // Button "Add"
        private void btnAddMvmt_Click(object sender, EventArgs e)
        {
            AddMovement(TableNameMov());
        }

        // Button "Update"
        private void btnUpdateMvmt_Click(object sender, EventArgs e)
        {
            UpdateMovement(TableNameMov());
        }

        // Button "Delete"
        private void btnDeleteMvmt_Click(object sender, EventArgs e)
        {
            DeleteMovement(TableNameMov());
        }

        // Button "Land"
        private void btnSetLand_Click(object sender, EventArgs e)
        {
            SetLand(TableNameMov());
        }

        // Button "Take-Off"
        private void btnSetTakeOff_Click(object sender, EventArgs e)
        {
            SetTakeOff(TableNameMov());
        }

        // Button "Clear fields"
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Toolstrip
        /// </summary>

        // Toolstrip-Button "Add"
        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            AddMovement(TableNameMov());
        }

        // Toolstrip-Button "Update"
        private void toolStripBtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMovement(TableNameMov());
        }

        // Toolstrip-Button "Delete"
        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            DeleteMovement(TableNameMov());
        }

        // Toolstrip-Button "Change Year"
        private void toolStripBtnChangeYear_Click(object sender, EventArgs e)
        {
            frmAdminLogin adminLogin = new frmAdminLogin();

            // if username & password correct, open administation panel
            if (adminLogin.ShowDialog() == DialogResult.OK && adminLogin.LoginSuccess)
            {
                administration.Show();
            }

            // TODO refresh displayed year in toolstrip "movements" when year has been changed in admin panel
        }

        //// Toolstrip-Button "Add Year"
        //private void toolStripBtnAddYear_Click(object sender, EventArgs e)
        //{
        //    AddYear();
        //}

        /// <summary>
        /// Functions
        /// </summary>

        // Add ICAO designator to database
        private void AddIcaoDesignator(frmMovementsAddIcaoDes addIcaoDes)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblAirportCodes (AirportCode) VALUES (@AirportCode)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AirportCode", addIcaoDes.NewIcaoDesignator);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            FillCbxArrDep();
            //cbxArrFrom.ResetText();
            //cbxDepTo.ResetText();
        }

        // Remove ICAO designator from database
        private void RemoveIcaoDesignator()
        {
            // any item selected?
            // TODO dieser code wird immer wieder im gleichen Stil verwendet (auch in Helicopters) -> Refactor / eine gemeinsame Klasse?
            if (cbxArrFrom.SelectedItem == null)
            {
                MessageBox.Show("Please select an ICAO designator out of the list 'ARR from' to delete.", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            // TODO dieser code wird immer wieder im gleichen Stil verwendet (auch in Helicopters) -> Refactor / eine gemeinsame Klasse?
            string selectedItem = cbxArrFrom.SelectedItem.ToString();
            string messageBoxText = string.Format("Are you sure to delete '{0}' from the list?", selectedItem);

            if (MessageBox.Show(messageBoxText, "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // database access
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "DELETE FROM tblAirportCodes WHERE AirportCode = @AirportCode";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AirportCode", cbxArrFrom.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ICAO designator has been deleted successfully!", "ICAO designator deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // refresh data
            // TODO how is this working in case of an error in the code above?
            FillCbxArrDep();
            cbxArrFrom.ResetText();
            cbxDepTo.ResetText();
        }

        // Check if ICAO designator exists in database
        // TODO function does exactly the same as functions in Helicopters-class (aircraft type & operator) -> combine into one function!
        private bool CheckIfDesignatorExists(frmMovementsAddIcaoDes addIcaoDes)
        {
            bool doesExist = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblAirportCodes] WHERE ([AirportCode] = @AirportCode)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AirportCode", addIcaoDes.NewIcaoDesignator);

                        int entryExists = (int)cmd.ExecuteScalar();

                        if (entryExists > 0)
                        {
                            //Console.WriteLine("Entry exists.");
                            doesExist = true;
                        }
                        else
                        {
                            //Console.WriteLine("Entry does not exist.");
                            doesExist = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return doesExist;
        }

        // Add movement to database
        private void AddMovement(string tableName)
        {
            byte noOfEng = 0;
            string registration = "";
            string aircraftType = "";
            string operatorName = "";

            if (NoEmptyFields())
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            string cmdText1 = @"SELECT * FROM tblHelicopters
                                        WHERE Registration = @Reg";

                            string cmdText2 = string.Format(@"INSERT INTO {0} (Registration, AircraftType, NoOfEng, Operator,
                                                            TypeOfOperation, ArrFrom, DepTo, Overnight, Year)
                                                            VALUES (@Registration, @AircraftType, @NoOfEng, @Operator,
                                                            @TypeOfOperation, @ArrFrom, @DepTo, @Overnight, @Year)", tableName);

                            cmd.Connection = connection;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = cmdText1;

                            // first query (get helicopter data)
                            cmd.Parameters.AddWithValue("@Reg", cbxRegistration.SelectedItem.ToString());
                            using (SqlDataReader reader1 = cmd.ExecuteReader())
                            {
                                if (reader1 != null)
                                {
                                    while (reader1.Read())
                                    {
                                        registration = reader1.GetString(1);
                                        aircraftType = reader1.GetString(2);
                                        noOfEng = reader1.GetByte(3);
                                        operatorName = reader1.GetString(4);
                                    }
                                }
                            }

                            // second query (write movement into table)
                            cmd.CommandText = cmdText2;
                            cmd.Parameters.AddWithValue("@Registration", registration);
                            cmd.Parameters.AddWithValue("@AircraftType", aircraftType);
                            cmd.Parameters.AddWithValue("@NoOfEng", noOfEng);
                            cmd.Parameters.AddWithValue("@Operator", operatorName);
                            cmd.Parameters.AddWithValue("@TypeOfOperation", cbxTypeOfOps.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@ArrFrom", cbxArrFrom.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@DepTo", cbxDepTo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Overnight", ckbOvernight.Checked);
                            cmd.Parameters.AddWithValue("@Year", GetActualYear());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            // TODO is there a better / other way to reload / refresh the new added data in the datagrid?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
        }

        // Update movement in database
        private void UpdateMovement(string tableName)
        {
            // any row selected?
            if (dgvMovements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movement from the list to update", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to update?
            if (MessageBox.Show("Are you sure to update this movement?\nNote: Landing and take-off times are not affected!",
                "Confirm update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (NoEmptyFields())
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = string.Format(@"UPDATE {0} SET Registration = @registration, AircraftType = @aircraftType,
                                                        Operator = @operator, TypeOfOperation = @typeOfOperation,
                                                        ArrFrom = @arrFrom, DepTo = @depTo, Overnight = @overnight
                                                        WHERE ID = @ID", tableName);

                        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", dgvMovements.SelectedRows[0].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@registration", cbxRegistration.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@aircraftType", tbxAircraftType.Text.ToString());
                            cmd.Parameters.AddWithValue("@operator", tbxOperator.Text.ToString());
                            cmd.Parameters.AddWithValue("@typeOfOperation", cbxTypeOfOps.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@arrFrom", cbxArrFrom.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@depTo", cbxDepTo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@overnight", ckbOvernight.Checked);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Movement has been updated successfully!", "Movement updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
        }

        // Delete movement in database
        private void DeleteMovement(string tableName)
        {
            // any row selected?
            if (dgvMovements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movement from the list to delete", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this movement?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = string.Format("DELETE FROM {0} WHERE ID = @ID", tableName);

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", dgvMovements.SelectedRows[0].Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Movement has been deleted successfully!", "Movement deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
            ClearFields();
        }

        // Sets landing time of movement
        private void SetLand(string tableName)
        {
            // any row selected?
            if (dgvMovements.SelectedRows == null)
            {
                MessageBox.Show("Please select a movement from the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to update?
            if (MessageBox.Show("Are you sure to update this movement with the landing time & date?", "Confirm update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (DateTimeNotEmpty())
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = string.Format(@"UPDATE {0} SET DateOfArr = @dateOfArr,
                                                        ActualTimeArr = @actualTimeArr
                                                        WHERE ID = @ID", tableName);

                        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", dgvMovements.SelectedRows[0].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@dateOfArr", dtpDateOfFlight.Value);
                            cmd.Parameters.AddWithValue("@actualTimeArr", dtpActualTime.Value.ToString("HH:mm"));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Landing time & date has been updated successfully!", "Landing time updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
        }

        // Sets take-off time of movement
        private void SetTakeOff(string tableName)
        {
            // any row selected?
            if (dgvMovements.SelectedRows == null)
            {
                MessageBox.Show("Please select a movement from the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to update?
            if (MessageBox.Show("Are you sure to update this movement with the take-off time & date?", "Confirm update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (DateTimeNotEmpty())
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = string.Format(@"UPDATE {0} SET DateOfDep = @dateOfDep,
                                                        ActualTimeDep = @actualTimeDep
                                                        WHERE ID = @ID", tableName);

                        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", dgvMovements.SelectedRows[0].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@dateOfDep", dtpDateOfFlight.Value);
                            cmd.Parameters.AddWithValue("@actualTimeDep", dtpActualTime.Value.ToString("HH:mm"));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Take-off time & date has been updated successfully!", "Landing time updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
        }

        // checks if no empty fields (left side of datagridview) before handling database
        private bool NoEmptyFields()
        {
            if (cbxRegistration != null &&
                !string.IsNullOrWhiteSpace(tbxAircraftType.Text) && tbxAircraftType.Text.Length > 0 &&
                !string.IsNullOrWhiteSpace(tbxOperator.Text) && tbxOperator.Text.Length > 0 &&
                cbxTypeOfOps.SelectedItem != null &&
                cbxArrFrom.SelectedItem != null &&
                cbxDepTo.SelectedItem != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("One or more information missing. All fields are required.", "Missing information",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // checks if DateTimePickers ("DateOfFlight" & "ActualTime") are not empty
        private bool DateTimeNotEmpty()
        {
            if (dtpDateOfFlight.Value != null && dtpActualTime.Value != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please select a valid date and time.", "Missing information",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // shows values in textboxes "aircraft type" and "operator" of selected helicopter
        private void cbxRegistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblHelicopters WHERE Registration = @Registration";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Registration", cbxRegistration.Text.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    // read & assign aircraft type
                                    string aircraftType = reader.GetString(2);
                                    tbxAircraftType.Text = aircraftType;

                                    // read & assign operator name
                                    string operatorName = reader.GetString(4);
                                    tbxOperator.Text = operatorName;
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // display selected row from dgv in textboxes & comboboxes
        private void ShowValues(object sender, EventArgs e)
        {
            if (dgvMovements.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvMovements.SelectedRows[0];
                cbxRegistration.Text = row.Cells["Registration"].Value.ToString();
                tbxAircraftType.Text = row.Cells["AircraftType"].Value.ToString();
                tbxOperator.Text = row.Cells["Operator"].Value.ToString();
                cbxTypeOfOps.Text = row.Cells["TypeOfOperation"].Value.ToString();
                cbxArrFrom.Text = row.Cells["ArrFrom"].Value.ToString();
                cbxDepTo.Text = row.Cells["DepTo"].Value.ToString();

                // checkbox "Overnight?"
                byte overnight = Convert.ToByte(row.Cells["Overnight"].Value);
                if (overnight == 1)
                {
                    ckbOvernight.Checked = true;
                }
                else
                {
                    ckbOvernight.Checked = false;
                }
            }
        }

        // clears all fields
        private void ClearFields()
        {
            cbxRegistration.Text = null;
            tbxAircraftType.Text = null;
            tbxOperator.Text = null;
            cbxTypeOfOps.Text = null;
            cbxArrFrom.Text = null;
            cbxDepTo.Text = null;
        }

        // make datetimepicker display current time
        private void timerMovements_Tick(object sender, EventArgs e)
        {
            dtpActualTime.Value = DateTime.Now;
        }


        /// <summary>
        /// Actual year handling
        /// </summary>

        // get actual year from settings
        private string GetActualYear()
        {
            return Properties.Settings.Default.ActualYear;
        }

        // display actual year in toolstrip textbox
        private string DisplayActualYear()
        {
            return toolStripTbxActualYear.Text = GetActualYear();
        }

        // creates table name to display only movements of actual year
        private string TableNameMov()
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string tableName = sb.Append(GetActualYear()).ToString();
            return tableName;
        }

        // event when actual year has changed
        private void Administration_ActualYearChanged(object sender, EventArgs e)
        {
            // reload datagridview
            // TODO is there a better way to refresh data in dgv?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
            DisplayActualYear();
        }
    }
}