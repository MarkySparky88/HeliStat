using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMovements : Form
    {
        // TODO ist this object disposed somewhere?
        private frmAdministration administration = new frmAdministration();

        // Constructor
        public frmMovements()
        {
            InitializeComponent();

            // Fill comboboxes
            // TODO combine loading of datagridview and comboboxes upon form load?
            // TODO bind comboboxes as well to datasource (dataset / datatable)??
            FillCbxRegistration();
            FillCbxArrDep();

            // Actual year
            GetActualYear();
            DisplayActualYear();
            administration.ActualYearChanged += Administration_ActualYearChanged;

            // Fill datagridview
            // TODO need a bindingsource?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
            DataGridViewVisualSettings();
        }

        #region Fill boxes and views
        // Fill datagridview
        private DataTable FillDataGridView(string tableName)
        {
            using (DataTable dataTable = new DataTable())
            {
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
        }

        // Datagridview visual settings
        private void DataGridViewVisualSettings()
        {
            dgvMovements.Columns["Year"].Visible = false;
            dgvMovements.Columns["ActualTimeArr"].DefaultCellStyle.Format = @"hh\:mm";
            dgvMovements.Columns["ActualTimeDep"].DefaultCellStyle.Format = @"hh\:mm";
            CustomHeaderText();
        }

        // Custom column header text for dgv
        private void CustomHeaderText()
        {
            dgvMovements.Columns[0].HeaderText = "ID";
            dgvMovements.Columns[1].HeaderText = "Registration";
            dgvMovements.Columns[2].HeaderText = "Aircraft type";
            dgvMovements.Columns[3].HeaderText = "No. eng.";
            dgvMovements.Columns[4].HeaderText = "Operator";
            dgvMovements.Columns[5].HeaderText = "Type Ops";
            dgvMovements.Columns[6].HeaderText = "ARR from";
            dgvMovements.Columns[7].HeaderText = "DEP to";
            dgvMovements.Columns[8].HeaderText = "Overnight";
            dgvMovements.Columns[9].HeaderText = "Year";
            dgvMovements.Columns[10].HeaderText = "Date of ARR";
            dgvMovements.Columns[11].HeaderText = "ATA";
            dgvMovements.Columns[12].HeaderText = "Date of DEP";
            dgvMovements.Columns[13].HeaderText = "ATD";
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
                    string cmdText = "SELECT * FROM tblHelicopters ORDER BY Registration ASC";

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
                    string cmdText = "SELECT * FROM tblAirportCodes ORDER BY AirportCode ASC";

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
        #endregion

        #region Buttons
        // Button "Helicopters"
        private void btnHelicopters_Click(object sender, EventArgs e)
        {
            Helicopters();
        }

        // Button "+" (ICAO Designator)
        private void btnAddIcaoDes_Click(object sender, EventArgs e)
        {
            AddIcaoDesignator();
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

        // Button "Now"
        private void btnSetDateTimeNow_Click(object sender, EventArgs e)
        {
            SetDateTimeNow();
        }

        // Button "Today"
        private void btnSetToday_Click(object sender, EventArgs e)
        {
            SetDateToday();
        }
        #endregion

        #region Toolstrip
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
                administration.ShowDialog();
            }
        }
        #endregion

        #region Functions
        // Open "Helicopters" (and refresh)
        private void Helicopters()
        {
            using (frmHelicopters helicopters = new frmHelicopters())
            {
                if (helicopters.ShowDialog() == DialogResult.Cancel)
                {
                    FillCbxRegistration();
                }
            }
        }

        // Add ICAO designator to database
        private void AddIcaoDesignator()
        {
            using (frmMovementsAddIcaoDes addIcaoDes = new frmMovementsAddIcaoDes())
            {
                while (addIcaoDes.DialogBoxStatus == false)
                {
                    if (addIcaoDes.ShowDialog() == DialogResult.OK && addIcaoDes.DialogBoxStatus == true)
                    {
                        FillCbxArrDep();
                    }
                }
            }
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
            // TODO refactor? own method for refresh data?
            FillCbxArrDep();
            cbxArrFrom.ResetText();
            cbxDepTo.ResetText();
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
                // TODO is there a better / other way to reload / refresh the new added data in the datagrid?
                dgvMovements.DataSource = FillDataGridView(TableNameMov());
            }
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
                // TODO is there a better way to reload the new added data in the datagrid?
                dgvMovements.DataSource = FillDataGridView(TableNameMov());
            }
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
        // TODO functions set landing time and set departure time quite similar, one function with overloads?
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

        // Checks if no empty fields (left side of datagridview) before handling database
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

        // Checks if DateTimePickers ("DateOfFlight" & "ActualTime") are not empty
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

        // Clears all fields
        private void ClearFields()
        {
            cbxRegistration.Text = null;
            tbxAircraftType.Text = null;
            tbxOperator.Text = null;
            cbxTypeOfOps.Text = null;
            cbxArrFrom.Text = null;
            cbxDepTo.Text = null;
            ckbOvernight.Checked = false;
        }

        // Reset to current date & time
        private void SetDateTimeNow()
        {
            dtpActualTime.Value = DateTime.Now;
            dtpDateOfFlight.Value = DateTime.Now;
        }
        #endregion

        #region Functions (actual year)
        // Actual year has changed
        private void Administration_ActualYearChanged(object sender, EventArgs e)
        {
            // TODO is there a better way to refresh data in dgv?
            dgvMovements.DataSource = FillDataGridView(TableNameMov());
            DisplayActualYear();
        }

        // Get actual year from settings
        private string GetActualYear()
        {
            return Properties.Settings.Default.ActualYear;
        }

        // Display actual year in toolstrip textbox
        private string DisplayActualYear()
        {
            return toolStripTbxActualYear.Text = GetActualYear();
        }

        // Creates table name to display only movements of actual year
        private string TableNameMov()
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string tableName = sb.Append(GetActualYear()).ToString();
            return tableName;
        }
        #endregion

        #region Functions (filter)
        // Filter, date or checkbox changed
        private void dtpDayFilter_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDayFilter.Checked)
            {
                EnableFilter();
            }
            else
            {
                DisableFilter();
            }
        }

        // Enable filter function
        private void EnableFilter()
        {
            FilterDay(GetSelectedDate());

            // when no record selected, clear all fields
            if (dgvMovements.SelectedRows.Count == 0)
            {
                ClearFields();
            }
        }

        // Disable filter function
        private void DisableFilter()
        {
            ((DataTable)dgvMovements.DataSource).DefaultView.RowFilter = string.Empty;
        }

        // Filter selected day (of ARR)
        private void FilterDay(string selectedDate)
        {
            const string filter = "DateOfArr = '{0}'";
            ((DataTable)dgvMovements.DataSource).DefaultView.RowFilter = string.Format(filter, selectedDate);
        }

        // Get (build) selected date
        private string GetSelectedDate()
        {
            string dd = dtpDayFilter.Value.Day.ToString();
            string mm = dtpDayFilter.Value.Month.ToString();
            string selectedDate = string.Format("{0}.{1}.{2}", dd, mm, GetActualYear());
            return selectedDate;
        }

        // Set date today for filter
        private void SetDateToday()
        {
            dtpDayFilter.Value = DateTime.Now;
        }
        #endregion

        #region Events
        // Shows values in textboxes "aircraft type" and "operator" of selected helicopter
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

        // Display selected row from dgv in textboxes & comboboxes
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

        // Form closed
        private void frmMovements_FormClosed(object sender, FormClosedEventArgs e)
        {
            administration.Dispose();
        }
        #endregion
    }
}