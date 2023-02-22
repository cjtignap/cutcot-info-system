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

namespace cutcot_info_system.info_fields
{
    public partial class BusinessClearanceInputFields : Form
    {
        public BusinessClearanceInputFields()
        {
            InitializeComponent();
        }

        private void cmbBlotterType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string owner = txtOwner.Text;

            DocumentRequestsDAO documentRequestsDAO= new DocumentRequestsDAO();
            documentRequestsDAO.insert(new DocumentRequest(0, "BUSINESS_CLEARANCE", owner,"UNFULFILLED"));

            int queue_no = documentRequestsDAO.getLastID();


            string name = txtOwner.Text;
            string business = txtBusinessName.Text;
            string addresss = txtAddress.Text;
            int month = DateTime.Now.Month;
            int date = DateTime.Now.Day;
            BusinessClearance businessClearance = new BusinessClearance(name,business,addresss,month+"",date+"",queue_no+"");
            BusinessClearanceDAO businessClearanceDAO = new BusinessClearanceDAO();
            businessClearanceDAO.insert(businessClearance);
            MessageBox.Show("Business Clearance request success!");
        }
    }
}
