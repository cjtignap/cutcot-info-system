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
        public ViewHearing(Hearing firstHearing, Hearing secondHearing, Hearing thirdHearing)
        {
            InitializeComponent();
            this.TopMost = true;
            this.firstHearing = firstHearing;
            this.secondHearing = secondHearing;
            this.thirdHearing = thirdHearing;
            hideLabels();
            if(!Equals(firstHearing,"0")&& !Equals(secondHearing, "0")&& !Equals(thirdHearing, "0"))
            {
                button3.Enabled = false;
            }

            loadHearings();
        }
        private void loadHearings()
        {
            HearingDAO hearingDAO = new HearingDAO();
            if(!(firstHearing is null))
            {

                lbl1stRem.Visible = true;
                lbl1stSched.Visible = true;
                lbl1stRem.Text ="Remarks : "+ firstHearing.remarks;
                lbl1stSched.Text = "1st : " + firstHearing.hearingSchedule.ToLongDateString();
            }

            if(!(secondHearing is null))
            {
                lbl2ndRem.Visible = true;
                lbl2ndSched.Visible = true;
                lbl2ndRem.Text = "Remarks : "+secondHearing.remarks;
                lbl2ndSched.Text = "2nd : "+secondHearing.hearingSchedule.ToLongDateString();
            }

            if (!(thirdHearing is null))
            {
                lbl3rdRem.Visible = true;
                lbl3rdSched.Visible = true;
            
                lbl3rdRem.Text = "Remarks : "+thirdHearing.remarks;
                lbl3rdSched.Text ="3rd : "+ thirdHearing.hearingSchedule.ToLongDateString();
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
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
