
using cutcot_info_system.child_forms;
using cutcot_info_system.forms;
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

        public Main()
        {
            InitializeComponent();
            pnlNavIcons.Visible = false;
        }

        
       
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlParent.Controls.Add(childForm);
            this.pnlParent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
            OpenChildForm(dashboard);
        }

        private void btnMiniDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            OpenChildForm(dashboard);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            OpenChildForm(reports);
        }

        private void btnMiniReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            OpenChildForm(reports);
        }

        private void btnAddNewReport_Click(object sender, EventArgs e)
        {
            AddNewReport addNewReport = new AddNewReport();
            OpenChildForm(addNewReport);
        }

        private void btnMiniAddNewReports_Click(object sender, EventArgs e)
        {
            AddNewReport addNewReport = new AddNewReport();
            OpenChildForm(addNewReport);
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            DocumentHistory documentHistory = new DocumentHistory();
            OpenChildForm(documentHistory);
        }

        private void btnMiniDocHistory_Click(object sender, EventArgs e)
        {
            DocumentHistory documentHistory = new DocumentHistory();
            OpenChildForm(documentHistory);
        }

        private void btnDocQueue_Click(object sender, EventArgs e)
        {
            DocumentQueue documentQueue = new DocumentQueue();
            OpenChildForm(documentQueue);
        }

        private void btnMinDocQueue_Click(object sender, EventArgs e)
        {
            DocumentQueue documentQueue = new DocumentQueue();
            OpenChildForm(documentQueue);
        }

        private void btnProcessDoc_Click(object sender, EventArgs e)
        {
            ProcessDocument processDocument = new ProcessDocument();
            OpenChildForm(processDocument);
        }

        private void btnMiniProcesssDoc_Click(object sender, EventArgs e)
        {
            ProcessDocument processDocument = new ProcessDocument();
            OpenChildForm(processDocument);
        }
    }
}
