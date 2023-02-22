using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.controllers
{
    internal class WaterClearanceDAO
    {
        public void insert(WaterClearance waterClearance)
        {
            string name = waterClearance.name;
            string age = waterClearance.age;
            DateOnly birthdate = waterClearance.birthdate;
            string address = waterClearance.address;
            string date = waterClearance.date;
            string month = waterClearance.month;
            string request_no = waterClearance.request_no;

            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "INSERT INTO water_clearance (id,name,birthdate,address,date,month,age) VALUES " +
                    "('"+ request_no + "','"+name+"',"+ "STR_TO_DATE('"+birthdate+ "','%d/%m/%Y')" + ",'"+address+"','"+date+"','"+month+"','"+age+"')";

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Oops something went wrong!, Make sure you enter the correct data");
            }
            mySqlConnection.Close();
        }

        public WaterClearance getWaterClearance(string request_no)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM `water_clearance` where `id` = '" + request_no + "';";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                WaterClearance waterClearance = new WaterClearance();
                if (reader.Read())
                {
                    waterClearance.address = reader.GetString("address");
                    waterClearance.name = reader.GetString("name");
                    waterClearance.month = reader.GetString("month");
                    waterClearance.date = reader.GetString("date");
                    waterClearance.age = reader.GetString("age");
                    waterClearance.request_no = request_no;

                    
                    waterClearance.birthdate = DateOnly.FromDateTime(reader.GetDateTime("birthdate"));

                    reader.Close();


                }
                mySqlConnection.Close();
                return waterClearance;
            }
            catch (Exception exc)
            {
                MessageBox.Show("THIS HERE " + exc.Message);
                return null;
            }
        }
    }
}
