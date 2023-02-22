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
    internal class BusinessClearanceDAO
    {
        public void insert(BusinessClearance businessClearance)
        {
            string name = businessClearance.name;
            string business = businessClearance.business;
            string address = businessClearance.address;
            string month = businessClearance.month;
            string date = businessClearance.date;
            string request_no = businessClearance.request_no;


            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "INSERT INTO business_clearance (id,name,business,address,date,month) VALUES " +
                    "('"+request_no+"','"+name+"','"+business+"','"+address+"','"+date+"','"+month+"')";

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

        public BusinessClearance getBusinessClearance(string request_no)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM `business_clearance` where `id` = '" + request_no + "';";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                BusinessClearance businessClearance = new BusinessClearance();
                if (reader.Read()) { 

                    businessClearance.business = reader.GetString("business");
                    businessClearance.name = reader.GetString("name");
                    businessClearance.address = reader.GetString("address");
                    businessClearance.date=reader.GetString("date");
                    businessClearance.month = reader.GetString("month");
                    businessClearance.request_no = request_no;
                    reader.Close();
                    

                }
                mySqlConnection.Close();
                return businessClearance;
            }
            catch(Exception exc)
            {
                MessageBox.Show("THIS HERE "+exc.Message);
                return null;
            }
        }
    }
}
