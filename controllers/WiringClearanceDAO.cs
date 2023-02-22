using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.controllers
{
    internal class WiringClearanceDAO
    {
        public void insert(WiringClearance wiringClearance)
        {
            string name = wiringClearance.name;
            string age = wiringClearance.age;
            DateOnly birthdate = wiringClearance.birthDate;
            string address= wiringClearance.address;
            string month = wiringClearance.month;
            string date= wiringClearance.date;
            string request_no = wiringClearance.request_no;

            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "INSERT INTO wiring_clearance (id,name,birthdate,address,date,month,age) VALUES " +
                    "('" + request_no + "','" + name + "'," + "STR_TO_DATE('" + birthdate + "','%d/%m/%Y')" + ",'" + address + "','" + date + "','" + month + "','" + age + "')";

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

        public WiringClearance GetWiringClearance(string request_no)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM `wiring_clearance` where `id` = '" + request_no + "';";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                WiringClearance wiringClearance = new WiringClearance();
                if (reader.Read())
                {
                    wiringClearance.address = reader.GetString("address");
                    wiringClearance.name = reader.GetString("name");
                    wiringClearance.month = reader.GetString("month");
                    wiringClearance.date = reader.GetString("date");
                    wiringClearance.age = reader.GetString("age");
                    wiringClearance.request_no = request_no;


                    wiringClearance.birthDate = DateOnly.FromDateTime(reader.GetDateTime("birthdate"));

                    reader.Close();


                }
                mySqlConnection.Close();
                return wiringClearance;
            }
            catch (Exception exc)
            {
                MessageBox.Show("THIS HERE " + exc.Message);
                return null;
            }
        }
    }
}
