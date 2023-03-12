using cutcot_info_system.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.printable_form
{
    public partial class BlotterReport : Form
    {
        public Panel panelToPrint;
        public BlotterReport(ReportInfo reportInfo)
        {
            InitializeComponent();

            lblType.Text= lblType.Text +  reportInfo.report_type;
            lblNature.Text = lblNature.Text + reportInfo.nature_of_dispute;
            lblStatus.Text = lblStatus.Text + reportInfo.status;
            lblPageNo.Text = lblPageNo.Text + reportInfo.page_no;
            lblCaseNo.Text = lblCaseNo.Text + reportInfo.case_no;
            lblDate.Text = lblDate.Text + reportInfo.date.ToShortDateString();

            lblFirstName.Text = lblFirstName.Text + reportInfo.first_party_info.name;
            lblFirstAddress.Text = lblFirstAddress.Text + reportInfo.first_party_info.address;
            lblFirstAge.Text = lblFirstAge.Text+ reportInfo.first_party_info.age;
            lblFirstContactNo.Text = lblFirstContactNo.Text + reportInfo.first_party_info.contact;

            lblSecondName.Text = lblSecondName.Text + reportInfo.second_party_info.name;
            lblSecondAddress.Text = lblSecondAddress.Text + reportInfo.second_party_info.address;
            lblSecondAge.Text = lblSecondAge.Text + reportInfo.second_party_info.age;   
            lblSecondContactNo.Text = lblSecondContactNo.Text+reportInfo.second_party_info.contact;

            if(reportInfo.firstHearing.hearingSchedule.ToShortDateString()!="01/01/0001")
            {

                lblFirstHearingDate.Text = lblFirstHearingDate.Text + reportInfo.firstHearing.hearingSchedule.ToLongDateString();
            }

            if (reportInfo.secondHearing.hearingSchedule.ToShortDateString() != "01/01/0001")
            {

                lblSecondHearingDate.Text = lblSecondHearingDate.Text + reportInfo.secondHearing.hearingSchedule.ToShortDateString();
            }
            if (reportInfo.thirdHearing.hearingSchedule.ToShortDateString() != "01/01/0001")
            {
                lblThirdHearingDate.Text = lblThirdHearingDate.Text + reportInfo.thirdHearing.hearingSchedule.ToShortDateString();
            }

            panelToPrint = panel1;
        }
    }
}
