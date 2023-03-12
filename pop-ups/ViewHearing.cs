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
    public partial class ViewHearing : Form
    {

        private Hearing firstHearing;
        private Hearing secondHearing;
        private Hearing thirdHearing;

        private int index = 0;
        string report_id;
        public ViewHearing(Hearing firstHearing, Hearing secondHearing, Hearing thirdHearing,string report_id)
        {
            InitializeComponent();
            //this.TopMost = true;
            this.firstHearing = firstHearing;
            this.secondHearing = secondHearing;
            this.thirdHearing = thirdHearing;
            this.report_id = report_id;
            hideLabels();
            if(firstHearing.Id !=  0&&secondHearing.Id !=0 && thirdHearing.Id !=0)
            {
                button3.Enabled = false;
            }

            loadHearings();
        }
        private void loadHearings()
        {
            HearingDAO hearingDAO = new HearingDAO();
            if(firstHearing.Id != 0)
            {

                lbl1stRem.Visible = true;
                lbl1stSched.Visible = true;
                btn1.Visible = true;
                lbl1stRem.Text ="Remarks : "+ firstHearing.remarks;
                lbl1stSched.Text = "1st : " + firstHearing.hearingSchedule.ToLongDateString();
                index = 1;
            }

            if(secondHearing.Id != 0)
            {
                lbl2ndRem.Visible = true;
                lbl2ndSched.Visible = true;
                btn2.Visible = true;
                lbl2ndRem.Text = "Remarks : "+secondHearing.remarks;
                lbl2ndSched.Text = "2nd : "+secondHearing.hearingSchedule.ToLongDateString();
                index = 2;
            }

            if (thirdHearing.Id != 0)
            {
                lbl3rdRem.Visible = true;
                lbl3rdSched.Visible = true;
                btn3.Visible = true;
                lbl3rdRem.Text = "Remarks : "+thirdHearing.remarks;
                lbl3rdSched.Text ="3rd : "+ thirdHearing.hearingSchedule.ToLongDateString();
                index = 3;
            }

        }

        private void hideLabels()
        {
            lbl1stRem.Visible = false;
            lbl1stSched.Visible = false;
            lbl2ndRem.Visible = false;
            lbl2ndSched.Visible = false;
            lbl3rdRem.Visible = false;
            lbl3rdSched.Visible = false;
            btn1.Visible = false;
            btn2.Visible = false;
            btn3.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (AddHearing addHearing = new AddHearing())
            {
                var result = addHearing.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ReportInfoDAO reportInfoDAO = new ReportInfoDAO();
                    Hearing hearing = addHearing.hearing;
                    if (firstHearing.Id == 0)
                    {
                        firstHearing = hearing;
                        reportInfoDAO.linkHearingSchedule(report_id, "first_hearing", firstHearing.Id + "");
                    }
                    else if (secondHearing.Id == 0)
                    {
                        secondHearing = hearing;
                        reportInfoDAO.linkHearingSchedule(report_id, "second_hearing", secondHearing.Id + "");
                    }
                    else if (thirdHearing.Id == 0)
                    {
                        thirdHearing = hearing;
                        reportInfoDAO.linkHearingSchedule(report_id, "third_hearing", thirdHearing.Id + "");
                        button3.Enabled = false;
                    }
                    loadHearings();
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
            using (EditHearing editHearing = new EditHearing(firstHearing))
            {
                var result = editHearing.ShowDialog();
                if(result == DialogResult.OK)
                {
                    lbl1stSched.Text ="1st : "+ editHearing.hearing.hearingSchedule.ToLongDateString();
                    lbl1stRem.Text = editHearing.hearing.remarks;
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            using (EditHearing editHearing = new EditHearing(secondHearing))
            {
                var result = editHearing.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lbl2ndSched.Text = "2nd : "+editHearing.hearing.hearingSchedule.ToLongDateString();
                    lbl2ndRem.Text = editHearing.hearing.remarks;
                }
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            using (EditHearing editHearing = new EditHearing(thirdHearing))
            {
                var result = editHearing.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lbl3rdSched.Text = "3rd : "+editHearing.hearing.hearingSchedule.ToLongDateString();
                    lbl3rdRem.Text = editHearing.hearing.remarks;
                }
            }
        }
    }
}
