using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliStat
{
    public class DatabaseAccess
    {
        public bool DbAccessComplete { get; private set; }

        // Constructor
        public DatabaseAccess(/* TODO you can add parameter here.. */)
        {
            // TODO write constructor
        }

        // Fill a combobox
        public void FillCombobox(string cmdText, string columnOrdinal, out string addItem)
        {
            addItem = null;

            using (OleDbConnection connection = new OleDbConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    addItem = reader.GetString(reader.GetOrdinal(columnOrdinal));
                                }
                            }
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DbAccessComplete = true;
                }
            }
            DbAccessComplete = true;
        }
    }
}
