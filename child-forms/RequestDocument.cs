using cutcot_info_system.info_fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.forms
{
    public partial class RequestDocument : Form
    {
        public RequestDocument()
        {
            InitializeComponent();
        }


        private String activeFormName;

        private Form activeForm;
        private void OpenChildForm(Form childForm, object sender)
        {


            if (activeForm != null)
            {
                activeForm.Close();
            }

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.pnlInfoField.Controls.Add(childForm);
                this.pnlInfoField.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();

        }

        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string documentType = cmbDocType.SelectedItem.ToString();

            if(documentType == "WATER CLEARANCE")
            {
                WaterClearanceInputFields wcif = new WaterClearanceInputFields();
                OpenChildForm(wcif,sender);
            }
            else if(documentType=="WIRING CLEARANCE")
            {
                WiringClearanceInputFields wcfi = new WiringClearanceInputFields();
                OpenChildForm(wcfi,sender);
            }
            else if (documentType == "BUSINESS CLEARANCE")
            {
                BusinessClearanceInputFields bcif = new BusinessClearanceInputFields();
                OpenChildForm(bcif, sender);
            }
        }
    }


}
