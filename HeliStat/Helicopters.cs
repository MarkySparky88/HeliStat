using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmHelicopters : Form
    {
        private string newHeli;

        public string NewHeli
        {
            get { return newHeli; }
            set { newHeli = value; }
        }

        // Constructor
        public frmHelicopters()
        {
            InitializeComponent();

            // Fill comboboxes
            // TODO combine loading of datagridview and comboboxes upon form load?
            // TODO bind comboboxes as well to datasource (dataset / datatable)??
            FillCbxAircraftType();
            FillCbxOperator();

            // Fill datagridview
            // TODO need bindingsource?
            dgvHelicopters.DataSource = FillDataGridView();
            CustomHeaderText();
        }

        #region Fill boxes and views
        // Fill datagridview from database
        // TODO create one big class for all connections in this program
        // TODO whole program: use "verbindungslose Klassen" (SqlDataAdapter, DataSet, DataTable, etc.) instead of live-connections?
        private DataTable FillDataGridView()
        {
            using (DataTable dataTable = new DataTable())
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = "SELECT * FROM tblHelicopters";

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
        }

        // Custom column header text for dgv
        private void CustomHeaderText()
        {
            dgvHelicopters.Columns[0].HeaderText = "ID";
            dgvHelicopters.Columns[1].HeaderText = "Registration";
            dgvHelicopters.Columns[2].HeaderText = "Aircraft type";
            dgvHelicopters.Columns[3].HeaderText = "No. eng.";
            dgvHelicopters.Columns[4].HeaderText = "Operator";
        }

        // Fill combobox aircraft type
        private void FillCbxAircraftType()
        {
            cbxAircraftType.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblAircraftTypes ORDER BY AircraftType ASC";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("AircraftType"));
                                    cbxAircraftType.Items.Add(addItem);
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
   
        // Fill combobox operator
        private void FillCbxOperator()
        {
            cbxOperator.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblOperators ORDER BY Operator ASC";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Operator"));
                                    cbxOperator.Items.Add(addItem);
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
        // Button "+" (Aircraft Type)
        private void btnAddNewAircraftType_Click(object sender, EventArgs e)
        {
            AddNewAircraftType();
        }

        // Button "-" (Aircraft type)
        private void btnRemoveAircraftType_Click(object sender, EventArgs e)
        {
            RemoveAircraftType();
        }

        // Button "+" (Operator)
        private void btnAddNewOperator_Click(object sender, EventArgs e)
        {
            AddNewOperator();
        }

        // Button "-" (Operator)
        private void btnRemoveOperator_Click(object sender, EventArgs e)
        {
            RemoveOperator();
        }

        // Button "Clear fields"
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Button "Add Heli"
        private void btnAddHeli_Click(object sender, EventArgs e)
        {
            AddHeli();
        }

        // Button "Remove Heli"
        private void btnRemoveHeli_Click(object sender, EventArgs e)
        {
            RemoveHeli();
        }

        // Button "Update-Heli"
        private void btnUpdateHeli_Click(object sender, EventArgs e)
        {
            UpdateHeli();
        }
        #endregion

        #region Toolstrip
        // Toolstrip-Button "Add"
        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            AddHeli();
        }

        // Toolstrip-Button "Update"
        private void toolStripBtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateHeli();
        }

        // Toolstrip-Button "Delete"
        private void toolStripBtnRemove_Click(object sender, EventArgs e)
        {
            RemoveHeli();
        }
        #endregion

        #region Functions
        // Add aircraft type
        private void AddNewAircraftType()
        {
            using (frmHelicoptersAddType helicoptersAddType = new frmHelicoptersAddType())
            {
                while (helicoptersAddType.DialogBoxStatus == false)
                {
                    if (helicoptersAddType.ShowDialog() == DialogResult.OK && helicoptersAddType.DialogBoxStatus == true)
                    {
                        // TODO better way to refresh data?
                        FillCbxAircraftType();
                        cbxAircraftType.ResetText();
                    }
                }
            }
        }

        // Remove aircraft type
        private void RemoveAircraftType()
        {
            // Any item selected?
            if (cbxAircraftType.SelectedItem == null)
            {
                MessageBox.Show("Please select an aircraft type out of the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Sure to delete?
            string selectedItem = cbxAircraftType.SelectedItem.ToString();
            string messageBoxText = string.Format("Are you sure to delete '{0}' from the list?", selectedItem);

            if (MessageBox.Show(messageBoxText, "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Database access
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "DELETE FROM tblAircraftTypes WHERE AircraftType = @AircraftType";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AircraftType", cbxAircraftType.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Aircraft type has been deleted successfully!", "Aircraft type deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Refresh data
            FillCbxAircraftType();
            cbxAircraftType.ResetText();
        }

        // Add operator
        private void AddNewOperator()
        {
            using (frmHelicoptersAddOperator helicoptersAddOperator = new frmHelicoptersAddOperator())
            {
                while (helicoptersAddOperator.DialogBoxStatus == false)
                {
                    if (helicoptersAddOperator.ShowDialog() == DialogResult.OK && helicoptersAddOperator.DialogBoxStatus == true)
                    {
                        // TODO better way to refresh data?
                        FillCbxOperator();
                        cbxOperator.ResetText();
                    }
                }
            }
        }

        // Remove operator
        private void RemoveOperator()
        {
            // Any item selected?
            if (cbxOperator.SelectedItem == null)
            {
                MessageBox.Show("Please select an operator out of the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Sure to delete?
            string selectedItem = cbxOperator.SelectedItem.ToString();
            string messageBoxText = string.Format("Are you sure to delete '{0}' from the list?", selectedItem);

            if (MessageBox.Show(messageBoxText, "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Database access
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "DELETE FROM tblOperators WHERE Operator = @Operator";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Operator", cbxOperator.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Operator has been deleted successfully!", "Operator deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Refresh data
            FillCbxOperator();
            cbxOperator.ResetText();
        }

        // Add heli
        private void AddHeli()
        {
            string registration = tbxRegistration.Text.ToString();

            // Check if heli exists
            if (!CheckIfHeliExists(registration))
            {
                if (NoEmptyFields())
                {
                    // Database access
                    AddHeliDatabaseAccess(registration);

                    // Make new heli accessible for movements form (via public property at top of code)
                    newHeli = registration;

                    // Refresh data
                    // TODO is there a better / other way to reload / refresh the new added data in the datagrid? (whole project! maybe work with BindingSource or DataSource class?)
                    dgvHelicopters.DataSource = FillDataGridView();

                    // Select row in dgv of helic which has just been created
                    AddHeliSelectCreatedRow(registration);
                }
            }
            else
            {
                MessageBox.Show("This helicopter already exists.\nEnter a new helicopter.", "Helicopter exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Add heli: Database access
        private void AddHeliDatabaseAccess(string registration)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"INSERT INTO tblHelicopters (Registration, AircraftType, NoOfEng, Operator)
                                        VALUES (@Registration, @AircraftType, @NoOfEng, @Operator)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Registration", registration);
                        cmd.Parameters.AddWithValue("@AircraftType", cbxAircraftType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@NoOfEng", Convert.ToByte(cbxNoOfEng.SelectedItem));
                        cmd.Parameters.AddWithValue("@Operator", cbxOperator.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Heli has been added successfully!", "Helicopter added",
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

        // Add heli: Select row in dgv of heli which has just been created
        private void AddHeliSelectCreatedRow(string registration)
        {
            foreach (DataGridViewRow row in dgvHelicopters.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(registration))
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        // Update selected heli
        private void UpdateHeli()
        {
            // Any row selected?
            if (dgvHelicopters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a helicopter from the list to update", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Sure to update?
            if (MessageBox.Show("Are you sure to update this helicopter?", "Confirm update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Database access
            if (NoEmptyFields())
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = @"UPDATE tblHelicopters SET
                                     Registration = @registration, AircraftType = @aircraftType,
                                     NoOfEng = @noOfEng, Operator = @operator
                                     WHERE ID = @ID";

                        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", dgvHelicopters.SelectedRows[0].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@registration", tbxRegistration.Text.ToString());
                            cmd.Parameters.AddWithValue("@aircraftType", cbxAircraftType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@noOfEng", Convert.ToByte(cbxNoOfEng.SelectedItem));
                            cmd.Parameters.AddWithValue("@operator", cbxOperator.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Heli has been updated successfully!", "Helicopter updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Refresh data
                // TODO is there a better way to reload the new added data in the datagrid?
                dgvHelicopters.DataSource = FillDataGridView();
                ClearFields();
            }
        }

        // Remove selected heli
        private void RemoveHeli()
        {
            // Any row selected?
            if (dgvHelicopters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a helicopter from the list to delete", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Sure to delete?
            if (MessageBox.Show("Are you sure to delete this helicopter?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Database access
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "DELETE FROM tblHelicopters WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", dgvHelicopters.SelectedRows[0].Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Heli has been deleted successfully!", "Helicopter deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Refresh data
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvHelicopters.DataSource = FillDataGridView();
            ClearFields();
        }

        // Check if heli already exists
        // TODO this function already used for new operator, aircraft type and ICAO designator (own class for all?)
        // TODO kann man diese Abfragen (gilt auch für new operator / aircraft type / ICAO designator) nicht ohne Datenzugriff lösen? Z.B. mittels DataTable?
        private bool CheckIfHeliExists(string registration)
        {
            bool recordExists = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblHelicopters] WHERE ([Registration] = @Registration)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Registration", registration);

                        int i = (int)cmd.ExecuteScalar();

                        if (i > 0)
                        {
                            recordExists = true;
                        }
                        else
                        {
                            recordExists = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return recordExists;
            }
        }

        // Clears all fields
        private void ClearFields()
        {
            tbxRegistration.Text = null;
            cbxAircraftType.Text = null;
            cbxNoOfEng.Text = null;
            cbxOperator.Text = null;
        }

        // Checks if no empty fields before handling database
        private bool NoEmptyFields()
        {
            if (!string.IsNullOrWhiteSpace(tbxRegistration.Text) && tbxRegistration.Text.Length > 0 &&
                cbxAircraftType.SelectedItem != null &&
                cbxNoOfEng.SelectedItem != null &&
                cbxOperator.SelectedItem != null)
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
        #endregion

        #region Events
        // Display selected row from dgv in textboxes & comboboxes
        private void ShowValues(object sender, EventArgs e)
        {
            if (dgvHelicopters.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvHelicopters.SelectedRows[0];
                tbxRegistration.Text = row.Cells["Registration"].Value.ToString();
                cbxAircraftType.Text = row.Cells["AircraftType"].Value.ToString();
                cbxNoOfEng.Text = row.Cells["NoOfEng"].Value.ToString();
                cbxOperator.Text = row.Cells["Operator"].Value.ToString();
            }
        }

        // Alphabetical characters only (tbx registration)
        private void tbxRegistration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        // When datasource of datagridview changes
        private void dgvHelicopters_DataSourceChanged(object sender, EventArgs e)
        {
            dgvHelicopters.Columns["Operator"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion
    }
}