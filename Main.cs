
using cutcot_info_system.child_forms;
using cutcot_info_system.forms;
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

namespace cutcot_info_system
{
    public partial class Main : Form
    {
        private Form activeForm;
        private Button activeButton;
        private String activeFormName;

        public Main()
        {
            InitializeComponent();
            pnlNavIcons.Visible = false;
            Dashboard dashboard = new Dashboard();
            OpenChildForm(dashboard, null, "Dashboard");
            this.Focus();
        }

        
       
        private void OpenChildForm(Form childForm, object sender, string formName)
        {
            if (activeForm != null&& formName != activeFormName)
            {
                activeForm.Close();
            }

            if (formName != activeFormName)
            {

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.pnlParent.Controls.Add(childForm);
                this.pnlParent.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }


            lblHeader.Text = formName;
            resetColors();

            if (activeFormName != formName)
            {
                if (formName == "Dashboard")
                {
                    btnDashboard.BackColor = Color.FromArgb(142, 167, 233);
                    btnMiniDashboard.BackColor = Color.FromArgb(142, 167, 233);
                }
                else if(formName == "Add new report") {
                    btnMiniAddNewReports.BackColor = Color.FromArgb(142, 167, 233);
                    btnAddNewReport.BackColor = Color.FromArgb(142, 167, 233);
                }
                else if (formName== "Reports")
                {
                    btnReports.BackColor = Color.FromArgb(142, 167, 233);
                    btnMiniReports.BackColor = Color.FromArgb(142, 167, 233); 

                }
                else if (formName== "Request Document")
                {
                    btnMiniDocHistory.BackColor = Color.FromArgb(142, 167, 233);
                    btnAddDoc.BackColor = Color.FromArgb(142, 167, 233);
                }
                else if (formName =="Document history")
                {
                    btnMiniDocHistory.BackColor = Color.FromArgb(142, 167, 233);
                    btnAddDoc.BackColor = Color.FromArgb(142, 167, 233);
                }
                else if (formName == "Document Queue")
                {
                    btnDocQueue.BackColor = Color.FromArgb(142, 167, 233);
                    btnMinDocQueue.BackColor = Color.FromArgb(142, 167, 233);
                }
                activeFormName = formName;

            }
            
        }

        private void resetColors()
        {
            btnMiniDashboard.BackColor = Color.FromArgb(114, 134, 211);
            btnDashboard.BackColor = Color.FromArgb(114, 134, 211);
            btnMiniAddNewReports.BackColor = Color.FromArgb(114, 134, 211);
            btnAddNewReport.BackColor = Color.FromArgb(114, 134, 211);
            btnMiniReports.BackColor = Color.FromArgb(114, 134, 211);
            btnReports.BackColor = Color.FromArgb(114, 134, 211);
            btnMinDocQueue.BackColor = Color.FromArgb(114, 134, 211);
            btnDocQueue.BackColor = Color.FromArgb(114, 134, 211);
            btnMiniDocHistory.BackColor = Color.FromArgb(114, 134, 211);
            btnAddDoc.BackColor = Color.FromArgb(114, 134, 211);
        }

        private void collapse()
        {
            btnCollapse.Image = global::cutcot_info_system.Properties.Resources.collapse2;
            pnlNavMain.Visible = false;
            pnlNavIcons.Visible = true;

        }
        private void expand()
        {
            btnCollapse.Image = global::cutcot_info_system.Properties.Resources.collapse;
            pnlNavMain.Visible = true;

            pnlNavIcons.Visible = false;
        }

        private void btnCollapse_Click_1(object sender, EventArgs e)
        {
            if (pnlNavMain.Visible)
            {
                collapse();
            }
            else
            {
                expand();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            OpenChildForm(dashboard,sender, "Dashboard");
            this.Focus();
        }

        private void btnMiniDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            OpenChildForm(dashboard, sender, "Dashboard");

            this.Focus();
        }

     

  
        private void btnAddNewReport_Click(object sender, EventArgs e)
        {
            AddNewReport addNewReport = new AddNewReport();
            OpenChildForm(addNewReport, sender,"Add new report");
            this.Focus();
        }

        private void btnMiniAddNewReports_Click(object sender, EventArgs e)
        {
            AddNewReport addNewReport = new AddNewReport();
            OpenChildForm(addNewReport, sender,"Add new report");
            this.Focus();
        }

       

        

       
        private void btnProcessDoc_Click(object sender, EventArgs e)
        {
            ProcessDocument processDocument = new ProcessDocument();
            OpenChildForm(processDocument, sender,"Process document");
            this.Focus();
        }

        private void btnMiniProcesssDoc_Click(object sender, EventArgs e)
        {
            ProcessDocument processDocument = new ProcessDocument();
            OpenChildForm(processDocument, sender,"Process document");
            this.Focus();
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            OpenChildForm(reports, sender,"Reports");

            this.Focus();
        }

        private void btnMiniReports_Click_1(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            OpenChildForm(reports, sender,"Reports");

            this.Focus();
        }

        private void btnDocQueue_Click_1(object sender, EventArgs e)
        {
            DocumentQueue documentQueue = new DocumentQueue();
            OpenChildForm(documentQueue, sender, "Document Queue");
            this.Focus();
        }

        private void btnMinDocQueue_Click_1(object sender, EventArgs e)
        {
            DocumentQueue documentQueue = new DocumentQueue();
            OpenChildForm(documentQueue, sender, "Document Queue");
            this.Focus();
        }

        private void btnAddDoc_Click_1(object sender, EventArgs e)
        {
            RequestDocument documentQueue = new RequestDocument();
            OpenChildForm(documentQueue, sender, "Request Document");
            this.Focus();
        }

        private void btnMiniDocHistory_Click_1(object sender, EventArgs e)
        {
            RequestDocument documentQueue = new RequestDocument();
            OpenChildForm(documentQueue, sender, "Request Document");
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            OpenChildForm(backup, sender, "Backup / Sync");
            this.Focus();
        }

        private void btnBackupMini_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            OpenChildForm(backup, sender, "Backup / Sync");
            this.Focus();
        }
    }
}
