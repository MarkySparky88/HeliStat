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
    public partial class frmMovements : Form
    {
        
        // connection string from file "DBConnection.settings"
        private static string connString = DBConnection.Default.HeliStatDBConnection;

        // Constructor
        public frmMovements()
        {
            InitializeComponent();
            FillCbxRegistration();
            FillCbxArrDep();
        }

        // load form
        private void frmMovements_Load(object sender, EventArgs e)
        {
            dgvMovements.DataSource = FillDataGridView();
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

        // fill combobox registration
        // TODO bind comboboxes to datatable?? (as well in the helicopters form..)
        public void FillCbxRegistration()
        {
            cbxRegistration.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connString))
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

        // fill comboboxes "ARR from" & "DEP to"
        private void FillCbxArrDep()
        {
            cbxArrFrom.Items.Clear();
            cbxDepTo.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connString))
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
            //helicopters.Show();

            if (helicopters.ShowDialog() == DialogResult.Cancel)
            {
                FillCbxRegistration();
            }
        }

        // Button "+" (ICAO Designator)
        private void btnAddIcaoDes_Click(object sender, EventArgs e)
        {
            frmMovementsAddIcaoDes addIcaoDes = new frmMovementsAddIcaoDes();

            if (addIcaoDes.ShowDialog() == DialogResult.OK)
            {
                AddIcaoDesignator(addIcaoDes);
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

        /// <summary>
        /// Functions
        /// </summary>

        // add ICAO designator to database
        private void AddIcaoDesignator(frmMovementsAddIcaoDes addIcaoDes)
        {
            using (SqlConnection connection = new SqlConnection(connString))
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
            cbxArrFrom.SelectedItem = null;
            cbxDepTo.SelectedItem = null;
        }

        // remove ICAO designator from database
        private void RemoveIcaoDesignator()
        {
            // any item selected?
            if (cbxArrFrom.SelectedItem == null)
            {
                MessageBox.Show("Please choose an ICAO designator out of the list 'ARR from' to delete.", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this ICAO designator?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
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
            // TODO how is this working in case of an error in the code above?
            FillCbxArrDep();
            cbxArrFrom.ResetText();
            cbxDepTo.ResetText();
        }

        // Add movement to database (without times)
        private void AddMovement()
        {
            int noOfEng = 0;
            string registration = "";
            string aircraftType = "";
            string operatorName = "";

            if (NoEmptyFields())
            {
                using (SqlConnection connection = new SqlConnection(connString))
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
                                        TypeOfOperation, ArrFrom, DepTo)
                                        VALUES
                                        (@Registration, @AircraftType, @NoOfEng, @Operator,
                                        @TypeOfOperation, @ArrFrom, @DepTo)";

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
                                        noOfEng = reader1.GetInt32(3);
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
            if (dgvMovements.SelectedRows == null)
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
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = @"UPDATE tblMov
                                        SET
                                        Registration = @registration, AircraftType = @aircraftType,
                                        Operator = @operator, TypeOfOperation = @typeOfOperation,
                                        ArrFrom = @arrFrom, DepTo = @depTo
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
            if (dgvMovements.SelectedRows == null)
            {
                MessageBox.Show("Please choose a movement from the list to delete", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // sure to delete?
            if (MessageBox.Show("Are you sure to delete this movement?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
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
                using (SqlConnection connection = new SqlConnection(connString))
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
                using (SqlConnection connection = new SqlConnection(connString))
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
            using (SqlConnection connection = new SqlConnection(connString))
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
                DataGridViewRow row = this.dgvMovements.SelectedRows[0];
                cbxRegistration.SelectedItem = row.Cells["Registration"].Value.ToString();
                tbxAircraftType.Text = row.Cells["AircraftType"].Value.ToString();
                tbxOperator.Text = row.Cells["Operator"].Value.ToString();
                cbxTypeOfOps.SelectedItem = row.Cells["TypeOfOperation"].Value;
                cbxArrFrom.SelectedItem = row.Cells["ArrFrom"].Value.ToString();
                cbxDepTo.SelectedItem = row.Cells["DepTo"].Value.ToString();
            }
        }

        // clears all fields
        private void ClearFields()
        {
            cbxRegistration.SelectedItem = null;
            tbxAircraftType.Text = null;
            tbxOperator.Text = null;
            cbxTypeOfOps.SelectedItem = null;
            cbxArrFrom.SelectedItem = null;
            cbxDepTo.SelectedItem = null;
        }

        // Button "Clear fields"
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}