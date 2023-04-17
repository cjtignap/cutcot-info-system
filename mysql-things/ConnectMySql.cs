using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using cutcot_info_system.Properties;

namespace cutcot_info_system.mysql_things
{
   
    public class ConnectMySql
    {

        private static MySqlConnection mySqlConnection;
        private ConnectMySql() { }

       //public static string serverAddress = "192.168.0.23";
        //public static string serverAddress = "192.168.1.24";
        public static string serverAddress = "localhost";
        public static MySqlConnection getMySqlConnection()
        {
            if (mySqlConnection == null)
            {


                string cs = @"server="+ConnectMySql.serverAddress+";userid=dbadmin;password=password;database=cutcot-info-system";
                mySqlConnection = new MySqlConnection(cs);
            }
            return mySqlConnection;
        }

    }
}
