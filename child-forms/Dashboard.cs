using cutcot_info_system.controllers;
using cutcot_info_system.models;
using cutcot_info_system.printable_form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.child_forms
{
    public partial class Dashboard : Form
    {
        Hearing[] hearings;
        DocumentRequest[] documentRequests;
        int selectedHearingIndex = -1;
        int selectedDocumentIndex = -1;
        public Dashboard()
        {
            InitializeComponent();
            HearingDAO hearingDAO = new HearingDAO();
            hearings = hearingDAO.getHearingsSoon();
            int i = 0;
            while (!(hearings[i] is null)&& i<30)
            {

                string text = hearings[i].hearingSchedule.ToShortDateString();
                text = text + " : " + hearings[i].remarks;
                listHearings.Items.Add(text);
                i++;
            }
            i = 0;

            DocumentRequestsDAO documentRequestsDAO = new DocumentRequestsDAO();
            documentRequests = documentRequestsDAO.getFirstDocumentRequests();

            while (!(documentRequests[i] is null) && i < 30)
            {


                string text = documentRequests[i].requestBy + " \t " + documentRequests[i].docType;
                listRequests.Items.Add(text);
                i++;
            }
        }


        private void listHearings_MouseDown(object sender, MouseEventArgs e)
        {
            int i = listHearings.SelectedIndex;
            if(i != selectedHearingIndex)
            {
                ReportInfoDAO reportInfoDAO = new ReportInfoDAO();

                ReportInfo report = reportInfoDAO.getReportViaHearing(hearings[i].Id + "");
                ViewReport viewReport = new ViewReport(report);
                viewReport.ShowDialog();

                selectedHearingIndex = i;
            }
            

        }

        private void listRequests_MouseClick(object sender, MouseEventArgs e)
        {
            int i = listRequests.SelectedIndex;

            if (i != selectedDocumentIndex)
            {


                DocumentRequest documentRequest = documentRequests[i];

                if(documentRequest.docType == "BUSINESS_CLEARANCE")
                {
                    BusinessClearanceDAO businessClearanceDAO = new BusinessClearanceDAO();
                    BusinessClearance businessClearance = businessClearanceDAO.getBusinessClearance(documentRequest.id + "");
                    BusinessClearanceForm businessClearanceForm = new BusinessClearanceForm(businessClearance);

                    businessClearanceForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    businessClearanceForm.ShowDialog();
                    businessClearanceForm.Dispose();
                }
                else if(documentRequest.docType == "WATER_CLEARANCE")
                {
                    WaterClearanceDAO waterClearanceDAO = new WaterClearanceDAO();
                    WaterClearance waterClearance = waterClearanceDAO.getWaterClearance(documentRequest.id + "");
                    WaterClearanceForm waterClearanceForm = new WaterClearanceForm(waterClearance);
                    waterClearanceForm.ControlBox = true;
                    waterClearanceForm.FormBorderStyle =  FormBorderStyle.FixedDialog;
                    waterClearanceForm.ShowDialog();
                    waterClearanceForm.Dispose();
                }
                else if (documentRequest.docType == "WIRING_CLEARANCE")
                {
                    WiringClearanceDAO wiringClearanceDAO = new WiringClearanceDAO();
                    WiringClearance wiringClearance = wiringClearanceDAO.GetWiringClearance(documentRequest.id + "");
                    WiringClearanceForm wiringClearanceForm = new WiringClearanceForm(wiringClearance);
                    wiringClearanceForm.ControlBox = true;
                    wiringClearanceForm.FormBorderStyle = FormBorderStyle.FixedDialog;  
                    wiringClearanceForm.ShowDialog();
                    wiringClearanceForm.Dispose();
                }
                selectedDocumentIndex = i;
            }

        }

        private void listHearings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
   
}
