using cutcot_info_system.controllers;
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

namespace cutcot_info_system.child_forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            HearingDAO hearingDAO = new HearingDAO();
            Hearing[] hearings = hearingDAO.getHearingsSoon();
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
            DocumentRequest[] documentRequests = documentRequestsDAO.getFirstDocumentRequests();

            while (!(documentRequests[i] is null) && i < 30)
            {


                string text = documentRequests[i].requestBy + " \t " + documentRequests[i].docType;
                listRequests.Items.Add(text);
                i++;
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
        }
    }
   
}
