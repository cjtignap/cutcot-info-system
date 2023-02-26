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
        public static MySqlConnection getMySqlConnection()
        {
            if (mySqlConnection == null)
            {
                XDocument xml = XDocument.Parse(Resources.database_info);
                string cs = (string)xml.Element("ConnectionString");


                //string cs = @"server=localhost;userid=root;password=admin;database=cutcot-info-system";
                mySqlConnection = new MySqlConnection(cs);
            }
            return mySqlConnection;
        }

    }
}
