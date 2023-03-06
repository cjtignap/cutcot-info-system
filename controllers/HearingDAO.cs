using cutcot_info_system.forms;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public Hearing[] getHearingsSoon()
        {

            Hearing[] hearings = new Hearing[30];
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {

                int i = 0;
                mySqlConnection.Open();
                string sql = "select * from `hearings` where `schedule` >= curdate() order by `schedule` asc limit 30;";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    
                    Hearing hearing = new Hearing();
                    hearing.hearingSchedule = DateOnly.FromDateTime(reader.GetDateTime("schedule"));
                    hearing.remarks = reader.GetString("remarks");
                    hearing.Id = reader.GetInt32("id");
                    hearings[i] = hearing;
                    i++;

                }

                reader.Close();
                mySqlConnection.Close();
                return hearings;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

                mySqlConnection.Close();
                return hearings;
            }
        }
        public void updateHearing(Hearing hearing)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();

            try
            {

                String convertedDate = hearing.hearingSchedule.ToString();
                string sql = "UPDATE `hearings` SET `schedule` = STR_TO_DATE('"+ convertedDate + "','%d/%m/%Y'), `remarks` = '" + hearing.remarks+"' WHERE `id` = "+hearing.Id;
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                cmd.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR HERE : " + e.Message);
            }
            mySqlConnection.Close();
        }

    }
}
