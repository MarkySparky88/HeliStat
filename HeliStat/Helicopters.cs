using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmHelicopters : Form
    {
        // constructor
        public frmHelicopters()
        {
            InitializeComponent();
            // TODO combine loading of datagridview and comboboxes upon form load?
            FillCbxAircraftType();
            FillCbxOperator();
        }

        // load form
        private void frmHelicopters_Load(object sender, EventArgs e)
        {
            dgvHelicopters.DataSource = FillDataGridView();
            // TODO bind comboboxes as well to datasource (dataset / datatable)??
            ClearFields();
        }

        /// <summary>
        /// Fill boxes and views
        /// </summary>

        // fill datagridview from database
        // TODO create one big class for all connections in this program
        // TODO whole program: use "verbindungslose Klassen" (SqlDataAdapter, DataSet, DataTable, etc.) instead of live-connections?
        private DataTable FillDataGridView()
        {
            DataTable dataTable = new DataTable();

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

        // fill combobox aircraft type
        private void FillCbxAircraftType()
        {
            //// TODO test for a shared class for all database interactions (DatabaseAccess.cs)
            //string cmdText = "SELECT * FROM tblAircraftTypes ORDER BY AircraftType";
            //string columnOrdinal = "AircraftType";
            //string addItem;
            //string[] items = new string[99];

            //cbxAircraftType.Items.Clear();

            //DatabaseAccess databaseAccess = new DatabaseAccess();
            //while (!databaseAccess.DbAccessComplete)
            //{
            //    databaseAccess.FillCombobox(cmdText, columnOrdinal, out addItem);
            //    cbxAircraftType.Items.Add(addItem);
            //}


            cbxAircraftType.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblAircraftTypes ORDER BY AircraftType";

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
   
        // fill combobox operator
        private void FillCbxOperator()
        {
            cbxOperator.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblOperators ORDER BY Operator";

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

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "+" (Aircraft Type)
        private void btnAddNewAircraftType_Click(object sender, EventArgs e)
        {
            using (frmHelicoptersAddNewType helicoptersAddNewType = new frmHelicoptersAddNewType())
            {
                while (helicoptersAddNewType.UserInput == false)
                {
                    if (helicoptersAddNewType.ShowDialog() == DialogResult.OK && helicoptersAddNewType.UserInput == true)
                    {
                        if (!checkIfAircraftTypeExists(helicoptersAddNewType))
                        {
                            AddNewAircraftType(helicoptersAddNewType);
                        }
                        else
                        {
                            MessageBox.Show("This aircraft type already exists.\nEnter a new aircraft type.", "Aircraft type exists",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            helicoptersAddNewType.UserInput = false;
                        }
                    }
                }
            }
        }

        // Button "-" (Aircraft type)
        private void btnRemoveAircraftType_Click(object sender, EventArgs e)
        {
            RemoveAircraftType();
        }

        // Button "+" (Operator)
        private void btnAddNewOperator_Click(object sender, EventArgs e)
        {
            using (frmHelicoptersAddNewOperator helicoptersAddNewOperator = new frmHelicoptersAddNewOperator())
            {
                while (helicoptersAddNewOperator.UserInput == false)
                {
                    if (helicoptersAddNewOperator.ShowDialog() == DialogResult.OK && helicoptersAddNewOperator.UserInput == true)
                    {
                        if (!checkIfOperatorExists(helicoptersAddNewOperator))
                        {
                            AddNewOperator(helicoptersAddNewOperator);
                        }
                        else
                        {
                            MessageBox.Show("This operator already exists.\nEnter a new operator.", "Operator exists",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            helicoptersAddNewOperator.UserInput = false;
                        }
                    }
                }
            }
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

        /// <summary>
        /// Toolstrip
        /// </summary>

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

        /// <summary>
        /// Functions
        /// </summary>

        // add aircraft type
        private void AddNewAircraftType(frmHelicoptersAddNewType helicoptersAddNewType)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblAircraftTypes (AircraftType) VALUES (@AircraftType)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AircraftType", helicoptersAddNewType.NewAircraftType);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            FillCbxAircraftType();
            cbxAircraftType.ResetText();
        }

        // remove aircraft type
        private void RemoveAircraftType()
        {
            // any item selected?
            if (cbxAircraftType.SelectedItem == null)
            {
                MessageBox.Show("Please select an aircraft type out of the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            string selectedItem = cbxAircraftType.SelectedItem.ToString();
            string messageBoxText = string.Format("Are you sure to delete '{0}' from the list?", selectedItem);

            if (MessageBox.Show(messageBoxText, "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

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
            // TODO how is this working in case of an error in the code above?
            FillCbxAircraftType();
            cbxAircraftType.ResetText();
        }

        // add operator
        private void AddNewOperator(frmHelicoptersAddNewOperator helicoptersAddNewOperator)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "INSERT INTO tblOperators (Operator) VALUES (@Operator)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Operator", helicoptersAddNewOperator.NewOperator);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            FillCbxOperator();
            cbxOperator.ResetText();
        }

        // remove operator
        private void RemoveOperator()
        {
            // any item selected?
            if (cbxOperator.SelectedItem == null)
            {
                MessageBox.Show("Please select an operator out of the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            string selectedItem = cbxOperator.SelectedItem.ToString();
            string messageBoxText = string.Format("Are you sure to delete '{0}' from the list?", selectedItem);

            if (MessageBox.Show(messageBoxText, "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

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
            // TODO how is this working in case of an error in the code above?
            FillCbxOperator();
            cbxOperator.ResetText();
        }

        // add heli
        private void AddHeli()
        {
            if (NoEmptyFields())
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
                            cmd.Parameters.AddWithValue("@Registration", tbxRegistration.Text.ToString());
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
            // TODO is there a better / other way to reload / refresh the new added data in the datagrid?
            dgvHelicopters.DataSource = FillDataGridView();
            ClearFields();
        }

        // update selected heli
        private void UpdateHeli()
        {
            // any row selected?
            if (dgvHelicopters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a helicopter from the list to update", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to update?
            if (MessageBox.Show("Are you sure to update this helicopter?", "Confirm update",
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
            }
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvHelicopters.DataSource = FillDataGridView();
            ClearFields();
        }

        // remove selected heli
        private void RemoveHeli()
        {
            // any row selected?
            if (dgvHelicopters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a helicopter from the list to delete", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this helicopter?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

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
            // TODO is there a better way to reload the new added data in the datagrid?
            dgvHelicopters.DataSource = FillDataGridView();
            ClearFields();
        }

        // checks if record (aircraft type) already exists in database
        // TODO tableName cannot be parameterized (see for possible workaround https://stackoverflow.com/questions/17947736/sqlparameter-does-not-allows-table-name-other-options-without-sql-injection-at)
        // oder https://stackoverflow.com/questions/23357481/how-can-i-pass-a-table-name-to-sqlcommand
        // TODO make this function usable for new aircraft type AND new operator
        // TODO parameters (tableName, helicoptersAddNewType) in function definition / title really needed?
        // TODO fuction not yet really tested, but seems to work (use console output as a help)
        private bool checkIfAircraftTypeExists(frmHelicoptersAddNewType helicoptersAddNewType)
        {
            bool doesExist = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblAircraftTypes] WHERE ([AircraftType] = @AircraftType)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@AircraftType", helicoptersAddNewType.NewAircraftType);

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

        // checks if record (operator) already exists in database
        // TODO function does exactly the same as function above for aircraft types -> combine into one function!
        private bool checkIfOperatorExists(frmHelicoptersAddNewOperator helicoptersAddNewOperator)
        {
            bool doesExist = false;

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT COUNT(*) FROM [tblOperators] WHERE ([Operator] = @Operator)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.Parameters.AddWithValue("@Operator", helicoptersAddNewOperator.NewOperator);

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

        // display selected row from dgv in textboxes & comboboxes
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

        // clears all fields
        private void ClearFields()
        {
            tbxRegistration.Text = null;
            cbxAircraftType.Text = null;
            cbxNoOfEng.Text = null;
            cbxOperator.Text = null;
        }

        // alphabetical characters only (tbx registration)
        private void tbxRegistration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        // checks if no empty fields before handling database
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
    }
}