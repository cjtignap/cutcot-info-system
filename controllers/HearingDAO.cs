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
    public class HearingDAO
    {
        public void insert(Hearing hearing)
        {
            string remarks = hearing.remarks;
            DateOnly schedule = hearing.hearingSchedule;

            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();

            String convertedDate = schedule.ToString();
            try
            {
                string sql = "INSERT INTO `hearings` (remarks, schedule) VALUES ('"+remarks+"',STR_TO_DATE('"+ convertedDate + "','%d/%m/%Y'))";
               
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            mySqlConnection.Close();
        }

        public int getLastID()
        {
            int lastId = 0;
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "SELECT LAST_INSERT_ID() from `hearings`";

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var result = cmd.ExecuteReader();
                result.Read();
                lastId = Convert.ToInt32(result[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            mySqlConnection.Close();
            return lastId;
        }


        public Hearing getHearingInformation(string id)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM `hearings` where `id` = '" + id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();
                Hearing hearing = new Hearing();

                while (reader.Read())
                {
                    hearing.Id = reader.GetInt32("id");
                    hearing.remarks = reader.GetString("remarks");
                    hearing.hearingSchedule = DateOnly.FromDateTime( reader.GetDateTime("schedule"));
                   
                }
                reader.Close();
                mySqlConnection.Close();
                return hearing;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Something went wrong!");
                return null;
            }
        }


    }
}
