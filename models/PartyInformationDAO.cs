using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace cutcot_info_system.models
{
    public class PartyInformationDAO
    {
        public void insert(PartyInformation partyInformation)
        {
            string name = partyInformation.name;
            string address = partyInformation.address;
            int age = partyInformation.age;
            string contact = partyInformation.contact;
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "INSERT INTO party_information (name, address, age, contact) VALUES ('"+name+"','"+address+"', '"+age+"','"+contact+"')";

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Something wrong happened");
            }
            mySqlConnection.Close();
        }
        public int getLastID()
        {
            int lastId = 0;
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "SELECT LAST_INSERT_ID() from `party_information`";

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
    }
}
