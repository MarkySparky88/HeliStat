using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliStat
{
    class CreateMovementTable
    {
        // connection string from file "DBConnection.settings"
        private string connString = DBConnection.Default.HeliStatDBConnection;
        
        //var commandStr = "If not exists (select name from sysobjects where name = 'Customer') CREATE TABLE Customer(First_Name char(50),Last_Name char(50),Address char(50),City char(50),Country char(25),Birth_Date datetime)";
        //using (SqlCommand command = new SqlCommand(commandStr, con))
        //command.ExecuteNonQuery();
    }
}
