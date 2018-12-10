﻿// TODO je nachdem, welche Art von Excel export verwendet wurde entweder Microsoft Referenzen oder closedXML deinstallieren und usings löschen
//using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
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
        }

        /// <summary>
        /// Fill boxes and views
        /// </summary>

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

        /// <summary>
        /// Export functions
        /// </summary>

        /// Other solutions available under:
        /// Var1 (Microsoft Office namespace): https://www.youtube.com/watch?v=YfcasWYaIzo&list=PL3WjWQ4vgGF-N4gf0wK8SR_J6upbM_TJI&index=29&t=201s
        /// Var2 (Forum 3rd answer, class extension method) https://stackoverflow.com/questions/8207869/how-to-export-datatable-to-excel

        // TODO dispose this datatable at the end?
        // TODO shift this field to the beginning of this class when really needed
        DataTable dataTableExport = new DataTable();
        //SqlDataAdapter dataAdapter = new SqlDataAdapter();

        // Excel export (closedXML)
        // Wiki: https://github.com/ClosedXML/ClosedXML/wiki
        private void ExcelExport2()
        {
            // TODO use "using" for dataset / datatable or dispose it seperately?
            DataSet dataSet = GetDataSetExport();
            

            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataSet);
                wb.SaveAs("Movements.xlsx");
            }

            Console.WriteLine("Excel file created!");
        }

        // Get DataSet
        private DataSet GetDataSetExport()
        {
            using (DataSet dataSet = new DataSet())
            {
                dataSet.Tables.Add(GetDataTableDay(TableNameMov(), dtpDayFilter.Value.Date));
                dataSet.Tables.Add(GetDataTableYear(TableNameMov(), GetSelectedYear()));
                return dataSet;
            }
        }

        // Get DataTable for selected date
        // TODO kann man diese Daten ohne Datenzugriff holen? Z.B. mit Funktion unten kombinieren (year), da holten wir ja die Daten schon
        // TODO pro Tag an welchem je ein Movement erfasst wurde ein Worksheet in Excel erstellen, nicht nur aktuell ausgewählter Tag
        private DataTable GetDataTableDay(string tableName, DateTime selectedDate)
        {
            using (DataTable dataTable = new DataTable())
            {
                dataTable.TableName = "Day";

                using (SqlConnection connection = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        connection.Open();
                        string cmdText = string.Format("SELECT * FROM {0} WHERE DateOfArr = @DateOfArr", tableName);

                        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                        {
                            cmd.Parameters.AddWithValue("@DateOfArr", selectedDate);
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

        // Get DataTable of selected year
        private DataTable GetDataTableYear(string tableName, string selectedYear)
        {
            using (DataTable dataTable = new DataTable())
            {
                dataTable.TableName = "Year";

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

        // Get datatable for statistics overview (total movements each day)
        // TODO still wip
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
                dataTable.Rows.Add();
                dataTable.Rows.Add();
                dataTable.Rows.Add();
                dataTable.Rows.Add();

                return dataTable;   
            }
        }

        private void GetDates()
        {
            List<DateTime> dates = new List<DateTime>();
            dataTableExport = GetDataTableYear(TableNameMov(), GetSelectedYear());
            // TODO dataAdapter needed?
            //dataAdapter.Fill(dataTableExport);

            DataView view = new DataView(dataTableExport);
            DataTable distinctDates = view.ToTable(true, "DateOfArr");


            //foreach (DataRow row in dataTableExport.Rows)
            //{
            //    dates.Add((DateTime)row["DateOfArr"]);
            //}
            //foreach (DateTime date in dates)
            //{
            //    Console.WriteLine(dates);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDates();
        }
    }
}
