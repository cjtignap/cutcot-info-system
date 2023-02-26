using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace cutcot_info_system.controllers
{
    internal class DocumentRequestsDAO
    {
        public void insert(DocumentRequest documentRequest)
        {

            string type = documentRequest.docType;
            string requestBy = documentRequest.requestBy;
            string status = documentRequest.status;
           
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "INSERT INTO requests (document_type,requested_by,status) VALUES ('"+type+"','"+requestBy+"','"+status+"')";

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
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
                string sql = "SELECT LAST_INSERT_ID() from `requests`";

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
        public MySqlDataReader getDocumentRequests()
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * from `requests` ORDER BY `id` DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
            mySqlConnection.Close();
        }
        public Boolean deleteRequest(string request_no)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "delete from `requests` where `id` = "+request_no+"";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Request sucessfully removed.");

                mySqlConnection.Close();
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

                mySqlConnection.Close();
                return false;
            }
        }
    }
}
