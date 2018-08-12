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
        // connection string from file "DBConnection.settings"
        private string connString = DBConnection.Default.HeliStatDBConnection;

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
        private DataTable FillDataGridView()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"SELECT * FROM tblHelicopters";

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
            cbxAircraftType.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"SELECT * FROM tblAircraftTypes
                                        ORDER BY AircraftType";
                
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

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"SELECT * FROM tblOperators
                                        ORDER BY Operator";

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
            frmHelicoptersAddNewType helicoptersAddNewType = new frmHelicoptersAddNewType();

            if (helicoptersAddNewType.ShowDialog() == DialogResult.OK)
            {
                AddNewAircraftType(helicoptersAddNewType);
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
            frmHelicoptersAddNewOperator helicoptersAddNewOperator = new frmHelicoptersAddNewOperator();

            if (helicoptersAddNewOperator.ShowDialog() == DialogResult.OK)
            {
                AddNewOperator(helicoptersAddNewOperator);
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

        // Button "Close"
        // TODO save or ask something here?
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Update combobox "Registration" in "Movements" form
            frmMovements movements = new frmMovements();
            movements.FillCbxRegistration();

            this.Close();
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
        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            RemoveHeli();
        }

        /// <summary>
        /// Functions
        /// </summary>

        // add new aircraft type to database
        private void AddNewAircraftType(frmHelicoptersAddNewType helicoptersAddNewType)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"INSERT INTO tblAircraftTypes (AircraftType)
                                     VALUES (@AircraftType)";

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
            cbxAircraftType.SelectedItem = null;
            ClearFields();
        }

        // remove aircraft type
        private void RemoveAircraftType()
        {
            // any item selected?
            if (cbxAircraftType.SelectedItem == null)
            {
                MessageBox.Show("Please choose an aircraft type out of the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this aircraft type?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"DELETE FROM tblAircraftTypes
                                        WHERE AircraftType = @AircraftType";

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
            ClearFields();   
        }

        // add new operator to database
        private void AddNewOperator(frmHelicoptersAddNewOperator helicoptersAddNewOperator)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"INSERT INTO tblOperators (Operator)
                                     VALUES (@Operator)";

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
            cbxOperator.Text = null;
            ClearFields();
        }

        // remove operator
        private void RemoveOperator()
        {
            // any item selected?
            if (cbxOperator.SelectedItem == null)
            {
                MessageBox.Show("Please choose an operator out of the list", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this operator?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"DELETE FROM tblOperators
                                        WHERE Operator = @Operator";

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
            cbxOperator.Text = null;
            ClearFields();
        }

        // add heli to database
        private void AddHeli()
        {
            if (NoEmptyFields())
            {
                using (SqlConnection connection = new SqlConnection(connString))
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
                            cmd.Parameters.AddWithValue("@NoOfEng", Convert.ToInt32(cbxNoOfEng.SelectedItem));
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

        // update selected heli in database
        private void UpdateHeli()
        {
            // any row selected?
            if (dgvHelicopters.SelectedRows == null)
            {
                MessageBox.Show("Please choose a helicopter from the list to update", "No item selected",
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
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = @"UPDATE tblHelicopters
                                     SET
                                     Registration = @registration, AircraftType = @aircraftType,
                                     NoOfEng = @noOfEng, Operator = @operator
                                     WHERE
                                     ID = @ID";

                        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", dgvHelicopters.SelectedRows[0].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@registration", tbxRegistration.Text.ToString());
                            cmd.Parameters.AddWithValue("@aircraftType", cbxAircraftType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@noOfEng", cbxNoOfEng.SelectedItem.ToString());
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

        // remove selected heli from database
        private void RemoveHeli()
        {
            // any row selected?
            if (dgvHelicopters.SelectedRows == null)
            {
                MessageBox.Show("Please choose a helicopter from the list to delete", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this helicopter?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string cmdText = @"DELETE FROM tblHelicopters
                                        WHERE ID = @ID";

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
        
        // display selected row from dgv in textboxes & comboboxes
        private void ShowValues(object sender, EventArgs e)
        {
            if (dgvHelicopters.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvHelicopters.SelectedRows[0];
                tbxRegistration.Text = row.Cells["Registration"].Value.ToString();
                cbxAircraftType.SelectedItem = row.Cells["AircraftType"].Value.ToString();
                cbxNoOfEng.SelectedItem = row.Cells["NoOfEng"].Value.ToString();
                cbxOperator.SelectedItem = row.Cells["Operator"].Value.ToString();
            }
        }

        // clears all fields
        private void ClearFields()
        {
            tbxRegistration.Text = null;
            cbxAircraftType.SelectedItem = null;
            cbxNoOfEng.SelectedItem = null;
            cbxOperator.SelectedItem = null;
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