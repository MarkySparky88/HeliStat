// TODO je nachdem, welche Art von Excel export verwendet wurde entweder Microsoft Referenzen oder closedXML deinstallieren und usings löschen
//using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

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
        }

        /// <summary>
        /// Fill boxes and views
        /// </summary>

        // Fill datagridview (year only)
        // TODO such functions used often in other classes (= make own class for that)
        // TODO DataTable really needed when working anyway all the time with data direct from the database?
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

        /// <summary>
        /// Buttons
        /// </summary>

        // Button "Today"
        private void btnSetToday_Click(object sender, EventArgs e)
        {
            SetDateToday();
        }

        // Button "Export"
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            // TODO delete unused functions
            //ExcelExport1();
            ExcelExport2();
            //ExcelExport3();
        }

        /// <summary>
        /// Functions
        /// </summary>

        // Update datagridview when year changed
        private void cbxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO is ther another best practice to reload / refresh datagridview?
            dgvStatistics.DataSource = FillDataGridView(TableNameMov(), GetSelectedYear());
        }

        /// <summary>
        /// Actual year handling
        /// </summary>

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

        /// <summary>
        /// Filter functions
        /// </summary>

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
            FilterDay(GetSelectedDate());
        }

        // Disable filter function
        private void DisableFilter()
        {
            ((DataTable)dgvStatistics.DataSource).DefaultView.RowFilter = string.Empty;
        }

        // Filter selected day (of ARR)
        private void FilterDay(string selectedDate)
        {
            const string filter = "DateOfArr = '{0}'";
            ((DataTable)dgvStatistics.DataSource).DefaultView.RowFilter = string.Format(filter, selectedDate);
        }

        // Get (build) selected date
        private string GetSelectedDate()
        {
            string dd = dtpDayFilter.Value.Day.ToString();
            string mm = dtpDayFilter.Value.Month.ToString();
            string selectedDate = string.Format("{0}.{1}.{2}", dd, mm, GetSelectedYear());
            return selectedDate;
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

        /// <summary>
        /// Export functions
        /// </summary>

        //// Excel export (Microsoft Office reference)
        //// acc. to https://www.youtube.com/watch?v=YfcasWYaIzo&list=PL3WjWQ4vgGF-N4gf0wK8SR_J6upbM_TJI&index=29&t=201s
        //private void ExcelExport1()
        //{
        //    // create application, workbook and worksheet
        //    // TODO need "using"?
        //    Excel.Application application = new Excel.Application();
        //    Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
        //    Excel.Worksheet worksheet = null;
        //    worksheet = workbook.Sheets["Tabelle1"];
        //    worksheet = workbook.ActiveSheet;
        //    // TODO change worksheet name..
        //    worksheet.Name = "Statistics";

        //    // fill with data from dgv
        //    // columns
        //    for (int i = 1; i < dgvStatistics.Columns.Count + 1; i++)
        //    {
        //        worksheet.Cells[1, i] = dgvStatistics.Columns[i - 1].HeaderText;
        //    }

        //    // rows
        //    for (int i = 0; i < dgvStatistics.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dgvStatistics.Columns.Count; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1] = dgvStatistics.Rows[i].Cells[j].Value.ToString();
        //        }
        //    }

        //    // save file
        //    // TODO double warning when overwritting file
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        try
        //        {
        //            // TODO create filename according year of exported data
        //            saveFileDialog.Title = "HeliStat - Export statistics";
        //            saveFileDialog.FileName = "Statistics_DavosTWR_Movements201x";
        //            saveFileDialog.DefaultExt = ".xlsx";
        //            saveFileDialog.Filter = "Excel-Arbeitsmappe|*.xlsx";

        //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                workbook.SaveAs(saveFileDialog.FileName);
        //            }
        //            application.Quit();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message, "Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}

        // Excel export (closedXML)
        // Wiki: https://github.com/ClosedXML/ClosedXML/wiki
        private void ExcelExport2()
        {
            //TODO use "using" for datatable or dispose it seperately?
            DataTable dataTable = FillDataGridView(TableNameMov(), GetSelectedYear());

            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable, "Movements");
                wb.SaveAs("Movements.xlsx");
            }
        }

        //// Excel export (extension method dataTable class)
        //private void ExcelExport3()
        //{
        //    DataTable dataTable;
        //    dataTable = FillDataGridView(TableNameMov(), GetSelectedYear());
        //    dataTable.ExportToExcel();
        //    dataTable.Dispose();
        //}
    }
}
