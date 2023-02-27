using cutcot_info_system.controllers;
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

            Hearing firstHearing = reportInfo.firstHearing;
            Hearing secondHearing = reportInfo.secondHearing;
            Hearing thirdHearing = reportInfo.thirdHearing;

            int firstHearingId=0;
            int secondHearingId=0;
            int thirdHearingId=0;

            //Linking Partyinformations with the report
            PartyInformationDAO partyInformationDAO= new PartyInformationDAO();

            partyInformationDAO.insert(firstPartyInformation);
            firstPartyId = partyInformationDAO.getLastID();

            partyInformationDAO.insert(secondPartyInformation);
            secondPartyId = partyInformationDAO.getLastID();


            //Linking Hearing information with the report
            HearingDAO hearingDAO = new HearingDAO();
            if(!(firstHearing is null))
            {
                hearingDAO.insert(firstHearing);
                firstHearingId = hearingDAO.getLastID();
            }

            if (!(secondHearing is null))
            {
                hearingDAO.insert(secondHearing);
                secondHearingId = hearingDAO.getLastID();
            }

            if (!(thirdHearing is null))
            {
                hearingDAO.insert(thirdHearing);
                thirdHearingId = hearingDAO.getLastID();
            }


            string blotterType = reportInfo.report_type;
            string nature = reportInfo.nature_of_dispute;
            string recordPhoto  = reportInfo.record_photo;
            int page = reportInfo.page_no;

            DateTime dateNow = DateTime.Now.Date;
            DateOnly dateOnlyNow = DateOnly.FromDateTime(dateNow);
            string sql="";

            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                sql = "INSERT INTO `reports` ( `type`, `nature_of_dispute`, `record_photo`, `date`, `first_party_info`, `second_party_info`, `page`, `first_hearing`, `second_hearing`, `third_hearing`) VALUES ('"+blotterType+"','"+nature+"','"+recordPhoto+"',STR_TO_DATE('" + DateOnly.FromDateTime(DateTime.Now).ToString() + "','%d/%m/%Y'),'"+firstPartyId+"','"+secondPartyId+"','"+page+"','"+firstHearingId+"','"+secondHearingId+"','"+thirdHearingId+"')";
                    

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully inserted new record");

                mySqlConnection.Close();
            }
            catch(Exception e)
            {
                
                MessageBox.Show("ERROR HERE : "+e.Message);
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
                HearingDAO hearingDAO = new HearingDAO();

                reader.Read();
                reportInfo.case_no = reader.GetString("case_no");
                reportInfo.date = reader.GetDateTime("date");
                reportInfo.nature_of_dispute = reader.GetString("nature_of_dispute");
                reportInfo.record_photo = reader.GetString("record_photo");
                reportInfo.report_type = reader.GetString("type");


                
                reportInfo.page_no = reader.GetInt32("page");

                string firstId = reader.GetString("first_party_info");
                string secondId = reader.GetString("second_party_info");

                string firstHearingId = reader.GetString("first_hearing");
                string secondHearingId = reader.GetString("second_hearing");
                string thirdHearingId = reader.GetString("third_hearing");
                reader.Close();

                mySqlConnection.Close();
                reportInfo.first_party_info = partyInformationDAO.getPartyInformation(firstId);

                reportInfo.second_party_info = partyInformationDAO.getPartyInformation(secondId);
                reportInfo.firstHearing = hearingDAO.getHearingInformation(firstHearingId);
                reportInfo.secondHearing = hearingDAO.getHearingInformation(secondHearingId);
                reportInfo.thirdHearing = hearingDAO.getHearingInformation(thirdHearingId);


                return reportInfo;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
            mySqlConnection.Close();
        }

        public int getLastID()
        {
            int lastId = 0;
            MySqlConnection mySqlConnection = ConnectMySql.getMySqlConnection();
            try
            {
                string sql = "SELECT LAST_INSERT_ID() from `reports`";

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
