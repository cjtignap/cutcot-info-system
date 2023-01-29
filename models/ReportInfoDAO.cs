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
                    "`second_party_info`) values ('"+blotterType+
                    "','"+page+
                    "','" + nature +
                    "','" +recordPhoto+
                    "',STR_TO_DATE('"+dateOnly+ "','%d/%m/%Y')," + firstPartyId+","+secondPartyId+")";

                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully inserted new record");
            }
            catch(Exception e)
            {
                
                MessageBox.Show(e.Message);
                MessageBox.Show(sql);
            }
            mySqlConnection.Close();
        }
    }
}
