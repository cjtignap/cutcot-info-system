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
    public partial class WiringClearanceInputFields : Form
    {
        public WiringClearanceInputFields()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;

            DocumentRequestsDAO documentRequestsDAO = new DocumentRequestsDAO();
            documentRequestsDAO.insert(new DocumentRequest(0, "WIRING_CLEARANCE", name, "UNFULFILLED"));

            int queue_no = documentRequestsDAO.getLastID();
            string address = txtAddress.Text;
            DateOnly birthdate = DateOnly.FromDateTime(dateBirthdate.Value.Date);
            string age = txtAge.Text;
            int month = DateTime.Now.Month;
            int date = DateTime.Now.Day;

            WiringClearance wiringClearance = new WiringClearance(name,age,birthdate,address,month+"",date+"", queue_no + "");
            WiringClearanceDAO wiringClearanceDAO = new WiringClearanceDAO();
            wiringClearanceDAO.insert(wiringClearance);

            MessageBox.Show("Wiring Clearance request success !");
            txtAddress.Text = "";
            txtAge.Text = "";
            txtName.Text = "";
        }
    }
}
