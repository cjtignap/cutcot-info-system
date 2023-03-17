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
    public partial class WaterClearanceInputFields : Form
    {
        public WaterClearanceInputFields()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;

            DocumentRequestsDAO documentRequestsDAO = new DocumentRequestsDAO();
            documentRequestsDAO.insert(new DocumentRequest(0, "WATER_CLEARANCE", name, "UNFULFILLED"));

            int queue_no = documentRequestsDAO.getLastID();
            string address = txtAddress.Text;
            DateOnly birthdate =   DateOnly.FromDateTime(dateBirthdate.Value.Date);
            string age = txtAge.Text;
            int month = DateTime.Now.Month;
            int date = DateTime.Now.Day;

            WaterClearance waterClearance = new WaterClearance(name,age,birthdate,address,date+"",month+"", queue_no+"");
            WaterClearanceDAO waterClearanceDAO = new WaterClearanceDAO();
            waterClearanceDAO.insert(waterClearance);

            MessageBox.Show("Water Clearance request success !");

            txtAddress.Text = "";
            txtAge.Text = "";
            txtName.Text = "";
        }
    }
}
