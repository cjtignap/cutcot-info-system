﻿using cutcot_info_system.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.printable_form
{
    public partial class WiringClearanceForm : Form
    {
        public WiringClearanceForm(WiringClearance wiringClearance)
        {
            InitializeComponent();

            lblAddress.Text = wiringClearance.address;
            lblName.Text = wiringClearance.name;
            lblDate.Text = wiringClearance.date;
            lblBirthdate.Text = wiringClearance.birthDate.ToLongDateString();

            lblAge.Text = wiringClearance.date;
            switch (wiringClearance.month)
            {
                case "1":
                    lblMonth.Text = "January";
                    break;
                case "2":
                    lblMonth.Text = "February";
                    break;
                case "3":
                    lblMonth.Text = "March";
                    break;
                case "4":
                    lblMonth.Text = "April";
                    break;
                case "5":
                    lblMonth.Text = "May";
                    break;
                case "6":
                    lblMonth.Text = "June";
                    break;
                case "7":
                    lblMonth.Text = "July";
                    break;
                case "8":
                    lblMonth.Text = "August";
                    break;
                case "9":
                    lblMonth.Text = "September";
                    break;
                case "10":
                    lblMonth.Text = "October";
                    break;
                case "11":
                    lblMonth.Text = "November";
                    break;
                case "12":
                    lblMonth.Text = "December";
                    break;
            }
        }
        public void prepareToPrint()
        {
            pictureBox1.BringToFront();
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
    
}
