﻿using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HeliStat
{
    public partial class frmStatistics : Form
    {
        // Constructor
        public frmStatistics()
        {
            InitializeComponent();

            // Fill comboboxes
            // TODO combine loading of datagridview and comboboxes upon form load?
            // TODO bind comboboxes as well to datasource (dataset / datatable)??
            FillCbxYears();
            DisplayActualYear();

            // Fill datagridview
            // TODO need bindingsource?
            dgvStatistics.DataSource = FillDataGridView(TableNameMov(), GetSelectedYear());
            DataGridViewVisualSettings();
        }

        #region Fill boxes and views
        // Fill datagridview (year only)
        // TODO such functions used often in other classes (= make own class for that)
        // TODO nochmals recherchieren ob das wirklich best practice ist um datagridview zu füllen?
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

        // Datagridview visual settings
        private void DataGridViewVisualSettings()
        {
            dgvStatistics.Columns["Year"].Visible = false;
            dgvStatistics.Columns["ActualTimeArr"].DefaultCellStyle.Format = @"hh\:mm";
            dgvStatistics.Columns["ActualTimeDep"].DefaultCellStyle.Format = @"hh\:mm";
            CustomHeaderText();
        }

        // Custom column header text for dgv
        private void CustomHeaderText()
        {
            dgvStatistics.Columns[0].HeaderText = "ID";
            dgvStatistics.Columns[1].HeaderText = "Registration";
            dgvStatistics.Columns[2].HeaderText = "Aircraft type";
            dgvStatistics.Columns[3].HeaderText = "No. eng.";
            dgvStatistics.Columns[4].HeaderText = "Operator";
            dgvStatistics.Columns[5].HeaderText = "Type Ops";
            dgvStatistics.Columns[6].HeaderText = "ARR from";
            dgvStatistics.Columns[7].HeaderText = "DEP to";
            dgvStatistics.Columns[8].HeaderText = "Overnight";
            dgvStatistics.Columns[9].HeaderText = "Year";
            dgvStatistics.Columns[10].HeaderText = "Date of ARR";
            dgvStatistics.Columns[11].HeaderText = "ATA";
            dgvStatistics.Columns[12].HeaderText = "Date of DEP";
            dgvStatistics.Columns[13].HeaderText = "ATD";
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
        }
        #endregion

        #region Buttons
        // Button "Today"
        private void btnSetToday_Click(object sender, EventArgs e)
        {
            SetDateToday();
        }

        // Button "Export"
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }
        #endregion

        #region Functions
        // none
        #endregion

        #region Functions (actual year)
        // Get actual year from settings
        // TODO following functions (GetActualYear, DisplayActualYear) used as well in Movements (own class?)
        private string GetActualYear()
        {
            return Properties.Settings.Default.ActualYear;
        }

        // Display actual year in toolstrip textbox
        private string DisplayActualYear()
        {
            return cbxYears.Text = GetActualYear();
        }

        // Creates table name according selected year
        private string TableNameMov()
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string selectedYear = cbxYears.SelectedItem.ToString();
            string tableName = sb.Append(selectedYear).ToString();
            return tableName;
        }
        #endregion

        #region Functions (filter)
        // Filter, date or checkbox changed
        private void dtpDayFilter_ValueChanged_1(object sender, EventArgs e)
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
            FilterDay();
        }

        // Disable filter function
        private void DisableFilter()
        {
            ((DataTable)dgvStatistics.DataSource).DefaultView.RowFilter = string.Empty;
        }

        // Filter selected day (of ARR)
        private void FilterDay()
        {
            const string filter = "DateOfArr = '{0}'";
            ((DataTable)dgvStatistics.DataSource).DefaultView.RowFilter = string.Format(filter, dtpDayFilter.Value.Date.ToString());
        }

        // Get selected year
        private string GetSelectedYear()
        {
            return cbxYears.SelectedItem.ToString();
        }

        // Set date today for filter
        private void SetDateToday()
        {
            dtpDayFilter.Value = DateTime.Now;
        }
        #endregion

        #region Functions (Excel export)
        /// Other solutions available under:
        /// Var1 (Microsoft Office namespace): https://www.youtube.com/watch?v=YfcasWYaIzo&list=PL3WjWQ4vgGF-N4gf0wK8SR_J6upbM_TJI&index=29&t=201s
        /// Var2 (Forum 3rd answer, class extension method) https://stackoverflow.com/questions/8207869/how-to-export-datatable-to-excel

        // Excel export (closedXML)
        private void ExcelExport()
        {
            using (DataSet dataSet = GetDataSetForExport())
            {
                // Create workbook and worksheets
                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dataSet);
                    SaveExcelFile(wb, GetSelectedYear());
                }
            }
        }

        // Save file dialog
        private static void SaveExcelFile(XLWorkbook wb, string selectedYear)
        {
            string fileName = string.Format("WEF {0} Statistics", selectedYear);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Export statistics to Excel file",
                FileName = fileName,
                Filter = "Excel-Workbook (*.xlsx)|*.xlsx"
            };

            saveFileDialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                wb.SaveAs(saveFileDialog.FileName);
            }

            saveFileDialog.Dispose();
        }

        // Get DataSet for excel export from different DataTables
        private DataSet GetDataSetForExport()
        {
            using (DataSet dataSet = new DataSet())
            {
                dataSet.Tables.Add(GetDataFromDatabase(TableNameMov(), GetSelectedYear()));
                return dataSet;
            }
        }

        // Get data for excel export (from database)
        private DataTable GetDataFromDatabase(string tableName, string selectedYear)
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

        // Get data for selected date (connectionless)
        private DataTable GetDataTablePerDay()
        {
            using (DataTable dtPerDay = new DataTable())
            {
                dtPerDay.TableName = "Day xx.xx";

                // TODO write function for connectionless dataTable

                return dtPerDay;
            }
        }

        // Get data for selected year (connectionless)
        private DataTable GetDataTablePerYear()
        {
            using (DataTable dtPerYear = new DataTable())
            {
                dtPerYear.TableName = "Year";

                // TODO write function for connectionless dataTable

                return dtPerYear;
            }
        }

        // Get data for total statistic overview (connectionless)
        private DataTable GetDataTableTotalStatistic()
        {
            using (DataTable dataTable = new DataTable())
            {
                // Columns
                dataTable.Columns.Add("Date");
                dataTable.Columns.Add("Dep 1 Eng");
                dataTable.Columns.Add("Dep 2 Eng");
                dataTable.Columns.Add("Dep Total");
                dataTable.Columns.Add("Arr 1 Eng");
                dataTable.Columns.Add("Arr 2 Eng");
                dataTable.Columns.Add("Arr Total");
                dataTable.Columns.Add("Overnight");
                dataTable.Columns.Add("Movements");

                // Rows
                // TODO add content
                dataTable.Rows.Add();
                dataTable.Rows.Add();
                // TODO wip...

                return dataTable;   
            }
        }
        #endregion

        #region Events
        // Update datagridview when year changed
        private void cbxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO is ther another best practice to reload / refresh datagridview?
            dgvStatistics.DataSource = FillDataGridView(TableNameMov(), GetSelectedYear());
        }
        #endregion
    }
}
