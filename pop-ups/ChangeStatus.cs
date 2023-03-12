using cutcot_info_system.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.pop_ups
{
    public partial class ChangeStatus : Form
    {
        string case_no;
        public string status;
        public ChangeStatus(string case_no)
        {
            InitializeComponent();
            this.case_no = case_no;
            //this.TopMost = true;
            cmbStatus.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pickedstatus = cmbStatus.SelectedItem.ToString();
            status = pickedstatus;
            ReportInfoDAO reportInfoDAO = new ReportInfoDAO();
            reportInfoDAO.updateStatus(case_no, status);
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void ChangeStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
