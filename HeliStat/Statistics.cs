using Excel = Microsoft.Office.Interop.Excel;
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
        // TODO je nachdem, welche Art von Excel export verwendet wurde entweder Microsoft Referenzen oder closedXML deinstallieren
        
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

        // Checkbox filter
        private void ckbFilterDay_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFilterDay.Checked)
            {
                EnableFilter();
            }
            else
            {
                DisableFilter();
            }
        }

        // Button "Export"
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            //ExcelExport1();
            //ExcelExport2();
            ExcelExport3();
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

        // Enable filter function
        private void EnableFilter()
        {
            dtpDay.Enabled = true;
            btnSetFilter.Enabled = true;
            btnSetToday.Enabled = true;
        }

        // Disable filter function
        private void DisableFilter()
        {
            dtpDay.Enabled = false;
            btnSetFilter.Enabled = false;
            btnSetToday.Enabled = false;
            dgvStatistics.DataSource = FillDataGridView(TableNameMov(), GetSelectedYear());
        }

        // Filter selected day (of ARR)
        private void FilterDay()
        {
            const string filter = "DateOfArr = '{0}'";
            ((DataTable)dgvStatistics.DataSource).DefaultView.RowFilter = string.Format(filter, GetSelectedDate());
        }

        // Reset date picker to today
        private void SetDateToday()
        {
            dtpDay.Value = DateTime.Now;
            FilterDay();
        }

        // Get (build) selected date
        private string GetSelectedDate()
        {
            string dd = dtpDay.Value.Day.ToString();
            string mm = dtpDay.Value.Month.ToString();
            string selectedDate = string.Format("{0}.{1}.{2}", dd, mm, GetSelectedYear());
            return selectedDate;
        }

        // Get selected year
        private string GetSelectedYear()
        {
            return cbxYears.SelectedItem.ToString();
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

        // Creates table name to display only movements of selected year
        private string TableNameMov()
        {
            StringBuilder sb = new StringBuilder("tblMov");
            string selectedYear = cbxYears.SelectedItem.ToString();
            string tableName = sb.Append(selectedYear).ToString();
            return tableName;
        }

        // Excel export (Microsoft Office reference)
        // acc. to https://www.youtube.com/watch?v=YfcasWYaIzo&list=PL3WjWQ4vgGF-N4gf0wK8SR_J6upbM_TJI&index=29&t=201s
        private void ExcelExport1()
        {
            // TODO need "using"?
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            // opens excel
            //application.Visible = true;

            worksheet = workbook.Sheets["Tabelle1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "CustomerDetail";

            for (int i = 1; i < dgvStatistics.Columns.Count + 1; i++)
            {
                worksheet.Cells[i, 1] = dgvStatistics.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dgvStatistics.Rows.Count; i++)
            {
                for (int j = 0; j < dgvStatistics.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvStatistics.Rows[i].Cells[j].Value.ToString();
                }
            }

            // TODO need "using"?
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "output";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            application.Quit();
        }

        // Excel export (closedXML)
        private void ExcelExport2()
        {
            XLWorkbook workbook = new XLWorkbook();
            DataTable dataTable = FillDataGridView(TableNameMov(), GetSelectedYear());
            workbook.Worksheets.Add(dataTable, "Statistics");
        }

        private void ExcelExport3()
        {
            DataTable dataTable;
            dataTable = FillDataGridView(TableNameMov(), GetSelectedYear());
            dataTable.ExportToExcel();
            dataTable.Dispose();
        }
    }
}
