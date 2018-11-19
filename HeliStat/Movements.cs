using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmMovements : Form
    {
        // Constructor
        public frmMovements()
        {
            InitializeComponent();
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
            dgvMovements.DataSource = FillDataGridView();
        }

        /// <summary>
        /// Fill boxes and views
        /// </summary>

        // Fill datagridview
        private DataTable FillDataGridView()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"SELECT * FROM tblMov";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
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
                    string cmdText = @"SELECT * FROM tblHelicopters
                                        ORDER BY Registration";

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
                    string cmdText = @"SELECT * FROM tblAirportCodes
                                        ORDER BY AirportCode";

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
                        MessageBox.Show("This ICAO-Designator already exists.\nEnter a new ICAO-Designator.", "ICAO-Designator exists",
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
            AddMovement();
        }

        // Button "Update"
        private void btnUpdateMvmt_Click(object sender, EventArgs e)
        {
            UpdateMovement();
        }

        // Button "Delete"
        private void btnDeleteMvmt_Click(object sender, EventArgs e)
        {
            DeleteMovement();
        }

        // Button "Land"
        private void btnSetLand_Click(object sender, EventArgs e)
        {
            SetLand();
        }

        // Button "Take-Off"
        private void btnSetTakeOff_Click(object sender, EventArgs e)
        {
            SetTakeOff();
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
            AddMovement();
        }

        // Toolstrip-Button "Update"
        private void toolStripBtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMovement();
        }

        // Toolstrip-Button "Delete"
        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            DeleteMovement();
        }

        // Toolstrip-Button "Change Year"
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAdminLogin adminLogin = new frmAdminLogin();
            adminLogin.Show();

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
                    string cmdText = @"INSERT INTO tblAirportCodes
                                     (AirportCode)
                                     VALUES
                                     (@AirportCode)";

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
                    string cmdText = @"DELETE FROM tblAirportCodes
                                        WHERE AirportCode = @AirportCode";

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
                    string cmdText = @"SELECT COUNT(*) FROM [tblAirportCodes]
                                        WHERE ([AirportCode] = @AirportCode)";

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
        private void AddMovement()
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

                            string cmdText2 = @"INSERT INTO tblMov
                                        (Registration, AircraftType, NoOfEng, Operator,
                                        TypeOfOperation, ArrFrom, DepTo, Overnight)
                                        VALUES
                                        (@Registration, @AircraftType, @NoOfEng, @Operator,
                                        @TypeOfOperation, @ArrFrom, @DepTo, @Overnight)";

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
            dgvMovements.DataSource = FillDataGridView();
        }

        // Update movement in database
        private void UpdateMovement()
        {
            // any row selected?
            if (dgvMovements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movement from the list to update", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to update?
            if (MessageBox.Show("Are you sure to update this movement?\nNote: Landing and take-off times are not affected!", "Confirm update",
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
                        string cmdText = @"UPDATE tblMov
                                        SET
                                        Registration = @registration, AircraftType = @aircraftType,
                                        Operator = @operator, TypeOfOperation = @typeOfOperation,
                                        ArrFrom = @arrFrom, DepTo = @depTo, Overnight = @overnight
                                        WHERE
                                        ID = @ID";

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
            dgvMovements.DataSource = FillDataGridView();
        }

        // Delete movement in database
        private void DeleteMovement()
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
                    string cmdText = @"DELETE FROM tblMov
                                        WHERE ID = @ID";

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
            dgvMovements.DataSource = FillDataGridView();
            ClearFields();
        }

        // Sets landing time of movement
        private void SetLand()
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
                        string cmdText = @"UPDATE tblMov
                                        SET
                                        DateOfArr = @dateOfArr, ActualTimeArr = @actualTimeArr
                                        WHERE
                                        ID = @ID";

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
            dgvMovements.DataSource = FillDataGridView();
        }

        // Sets take-off time of movement
        private void SetTakeOff()
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
                        string cmdText = @"UPDATE tblMov
                                        SET
                                        DateOfDep = @dateOfDep, ActualTimeDep = @actualTimeDep
                                        WHERE
                                        ID = @ID";

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
            dgvMovements.DataSource = FillDataGridView();
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
                    string cmdText = @"SELECT * FROM tblHelicopters
                                        WHERE Registration = @Registration";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Registration", cbxRegistration.Text.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string aircraftType = reader.GetString(2);
                                    string operatorName = reader.GetString(4);

                                    tbxAircraftType.Text = aircraftType;
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

        // get actual year from settings
        private void GetActualYear()
        {
            string actualYear = Properties.Settings.Default.ActualYear;
        }

        // display actual year in toolstrip textbox
        public string DisplayActualYear()
        {
            return toolStripTbxActualYear.Text = Properties.Settings.Default.ActualYear;
        }
    }
}