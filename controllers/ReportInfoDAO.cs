using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    public class ReportInfoDAO
    {
        public void insert(ReportInfo reportInfo)
        {


            PartyInformation firstPartyInformation = reportInfo.first_party_info; 
            PartyInformation secondPartyInformation = reportInfo.second_party_info;
            int firstPartyId;
            int secondPartyId;

            PartyInformationDAO partyInformationDAO= new PartyInformationDAO();

            partyInformationDAO.insert(firstPartyInformation);
            firstPartyId = partyInformationDAO.getLastID();

            partyInformationDAO.insert(secondPartyInformation);
            secondPartyId = partyInformationDAO.getLastID();


            string blotterType = reportInfo.report_type;
            string nature = reportInfo.nature_of_dispute;
            string recordPhoto  = reportInfo.record_photo;
            int page = reportInfo.page_no;
            DateTime firstHearingDate = reportInfo.first_hearing;
            DateOnly dateOnly = DateOnly.FromDateTime(firstHearingDate);

            DateTime dateNow = DateTime.Now.Date;
            DateOnly dateOnlyNow = DateOnly.FromDateTime(dateNow);
            string sql="";

            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                 sql = "INSERT INTO `reports` ( " +
                    "`type`," +
                    "`page`," +
                    " `nature_of_dispute`," +
                    " `record_photo`," +
                    "`first_hearing_date`," +
                    "`first_party_info`," +
                    "`second_party_info`,`date`) values ('"+blotterType+
                    "','"+page+
                    "','" + nature +
                    "','" +recordPhoto+
                    "',STR_TO_DATE('"+dateOnly+ "','%d/%m/%Y')," + firstPartyId+","+secondPartyId+ ",STR_TO_DATE('" + DateTime.Now + "','%d/%m/%Y %h:%i:%s %p'))";

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully inserted new record");

                mySqlConnection.Close();
            }
            catch(Exception e)
            {
                
                MessageBox.Show(e.Message);
            }
            mySqlConnection.Close();
        }

        public MySqlDataReader getReports()
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "Select * from `reports`";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();   
                return reader;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
            mySqlConnection.Close();
        }

       

        public MySqlDataReader getReportsByName(string name)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * from `reports` where (`reports`.`first_party_info` in (select `party_information`.`party_info_id` from `party_information` where `party_information`.`name` like '%"+name+"%')) or (`reports`.`second_party_info` in (select `party_information`.`party_info_id` from `party_information` where `party_information`.`name` like '%"+name+"%'));";
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

        public ReportInfo getReport(string caseNo)
        {
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM `reports` where `case_no` = '" + caseNo + "';";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();
                ReportInfo reportInfo = new ReportInfo();

                PartyInformationDAO partyInformationDAO = new PartyInformationDAO();


                reader.Read();
                reportInfo.case_no = reader.GetString("case_no");
                reportInfo.date = reader.GetDateTime("date");
                reportInfo.nature_of_dispute = reader.GetString("nature_of_dispute");
                reportInfo.record_photo = reader.GetString("record_photo");
                reportInfo.report_type = reader.GetString("type");
                reportInfo.first_hearing = reader.GetDateTime("first_hearing_date");
                reportInfo.page_no = reader.GetInt32("page");

                string firstId = reader.GetString("first_party_info");
                string secondId = reader.GetString("second_party_info");

                reader.Close();

                mySqlConnection.Close();
                reportInfo.first_party_info = partyInformationDAO.getPartyInformation(firstId);

                reportInfo.second_party_info = partyInformationDAO.getPartyInformation(secondId);



                return reportInfo;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
            mySqlConnection.Close();
        }
    }


}
