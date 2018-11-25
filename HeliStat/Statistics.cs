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
    public partial class frmStatistics : Form
    {
        // Constructor
        public frmStatistics()
        {
            InitializeComponent();
            FillCbxYears();
        }

        // Load form
        private void frmStatistics_Load(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = FillDataGridView(TableNameMov(), GetSelectedYear());
        }

        /// <summary>
        /// Fill boxes and views
        /// </summary>

        // Fill datagridview (year only)
        // TODO such functions used often in other classes (= make own class for that)
        // TODO DataTable really needed when working anyway all the time with data direct from the database?
        private DataTable FillDataGridView(string tableName, string selectedYear)
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
                            cmd.Parameters.AddWithValue("@Year", selectedYear);
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

        // Fill combobox years
        // TODO same function used again and again and especially in frmAdministration as well for cbxYears (own class?)
        private void FillCbxYears()
        {
            cbxYears.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblYears ORDER BY Year DESC";

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Year"));
                                    cbxYears.Items.Add(addItem);
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
            DisplayActualYear();
        }

        /// <summary>
        /// Buttons
        /// </summary>
        
        // Button "Set" (Filter)
        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            FilterDay();
        }

        // Button "Today"
        private void btnSetToday_Click(object sender, EventArgs e)
        {
            SetDateToday();
        }

        /// <summary>
        /// Functions
        /// </summary>

        // Enable or disable day filter
        private void ckbFilterDay_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFilterDay.Checked)
            {
                dtpDay.Enabled = true;
            }
            else
            {
                dtpDay.Enabled = false;
                dgvStatistics.DataSource = FillDataGridView(TableNameMov(), GetSelectedYear());
            }
        }

        // Filter day (of ARR)
        private void FilterDay()
        {
            ////dgvStatistics.DataSource = FillDataGridViewFilterAct(TableNameMov(), GetSelectedYear(), GetSelectedDate());
            //DataView dataView = new DataView(FillDataGridView(TableNameMov(), GetSelectedYear()));
            //dataView.RowFilter = "Date = #22/11/2018#";
        }

        // Reset date picker to today
        private void SetDateToday()
        {
            dtpDay.Value = DateTime.Now;
        }

        // Get selected date
        private DateTime GetSelectedDate()
        {
            return dtpDay.Value;
        }

        // Get selected year
        private string GetSelectedYear()
        {
            return cbxYears.SelectedItem.ToString();
        }

        /// <summary>
        /// Actual year handling
        /// </summary>

        // get actual year from settings
        // TODO following functions (GetActualYear, DisplayActualYear) used as well in Movements (own class?)
        private string GetActualYear()
        {
            return Properties.Settings.Default.ActualYear;
        }

        // display actual year in toolstrip textbox
        private string DisplayActualYear()
        {
            return cbxYears.Text = GetActualYear();
        }

        // creates table name to display only movements of selected year
        private string TableNameMov()
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string selectedYear = cbxYears.SelectedItem.ToString();
            string tableName = sb.Append(selectedYear).ToString();
            return tableName;
        }
    }
}
