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

namespace cutcot_info_system.pop_ups
{
    public partial class EditHearing : Form
    {
        public Hearing hearing;
        public EditHearing(Hearing hearing)
        {
            InitializeComponent();
            this.hearing = hearing;
            //this.TopMost = true;
            txtRemarks.Text = hearing.remarks;
            dateHearing.Value = hearing.hearingSchedule.ToDateTime(TimeOnly.Parse("10:00 PM"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            hearing.remarks = txtRemarks.Text;
            hearing.hearingSchedule = DateOnly.FromDateTime(dateHearing.Value);

            HearingDAO hearingDAO = new HearingDAO();
            hearingDAO.updateHearing(hearing);

            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }
    }
}
