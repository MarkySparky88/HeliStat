using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.OleDb;
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
                using (OleDbConnection connection = new OleDbConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = string.Format("SELECT * FROM {0} WHERE Year_ = @Year_", tableName);

                        using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@Year_", selectedYear);
                            cmd.ExecuteNonQuery();

                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader != null)
                                {
                                    dataTable.Load(reader);
                                }
                            }
                        }
                    }
                    catch (OleDbException ex)
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
            dgvStatistics.Columns["Year_"].Visible = false;
            dgvStatistics.Columns["ActualTimeArr"].DefaultCellStyle.Format = "HH:mm";
            dgvStatistics.Columns["ActualTimeDep"].DefaultCellStyle.Format = "HH:mm";
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

            using (OleDbConnection connection = new OleDbConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM tblYears ORDER BY Year_ DESC";

                    using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    string addItem = reader.GetString(reader.GetOrdinal("Year_"));
                                    cbxYears.Items.Add(addItem);
                                }
                            }
                        }
                    }
                }
                catch (OleDbException ex)
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
        // Excel export
        private void ExcelExport()
        {
            // Retrieve data and save in excel
            using (DataTable dataTable = GetDataFromDatabase(TableNameMov(), GetSelectedYear()))
            {
                // Create workbook
                var wb = new XLWorkbook();

                // Create worksheet
                var ws = wb.Worksheets.Add(dataTable, "Statistics");

                // Styling
                VisualStylingWorksheet(ws);

                // Save workbook
                SaveExcelFile(wb, GetSelectedYear());
            }
        }

        // Styling worksheet
        private static void VisualStylingWorksheet(IXLWorksheet ws)
        {
            // Headers
            ws.Cell("C1").Value = "Aircraft type";
            ws.Cell("D1").Value = "No. eng.";
            ws.Cell("F1").Value = "Type Ops";
            ws.Cell("G1").Value = "ARR from";
            ws.Cell("H1").Value = "DEP to";
            ws.Cell("J1").Value = "Year";
            ws.Cell("K1").Value = "Date of ARR";
            ws.Cell("L1").Value = "ATA";
            ws.Cell("M1").Value = "Date of DEP";
            ws.Cell("N1").Value = "ATD";

            // Time format
            ws.Column("L").Style.NumberFormat.Format = "HH:mm";
            ws.Column("N").Style.NumberFormat.Format = "HH:mm";

            // Adjust column width to content
            ws.Columns("A", "N").AdjustToContents();

            // Adjust horizontal alignment
            ws.Column("A").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column("D").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column("I").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column("K").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column("L").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column("M").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column("N").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
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
                // TODO throws exception when savefiledialog is cancelled
                wb.SaveAs(saveFileDialog.FileName);
            }

            saveFileDialog.Dispose();
        }

        // Get data from database
        private DataTable GetDataFromDatabase(string tableName, string selectedYear)
        {
            using (DataTable dataTable = new DataTable())
            {
                using (OleDbConnection connection = new OleDbConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = string.Format("SELECT * FROM {0} WHERE Year_ = @Year_", tableName);

                        using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
                        {
                            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd))
                            {
                                cmd.Parameters.AddWithValue("@Year_", selectedYear);
                                cmd.ExecuteNonQuery();
                                dataAdapter.Fill(dataTable);
                            }
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
