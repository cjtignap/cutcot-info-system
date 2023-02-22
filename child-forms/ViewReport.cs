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

namespace cutcot_info_system.child_forms
{
    public partial class ViewReport : Form
    {
        public ViewReport(ReportInfo reportInfo)
        {
            InitializeComponent();
            this.TopMost = true;
            
            txtBlotterType.Text = reportInfo.report_type;
            txtStatus.Text = "tbd";
            txtCase.Text = reportInfo.case_no;
            txtPage.Text = reportInfo.page_no+"";
            txtDateSaved.Text = reportInfo.date + "";
            txtNature.Text = reportInfo.nature_of_dispute;
            txtName1st.Text = reportInfo.first_party_info.name;
            txtName2nd.Text = reportInfo.second_party_info.name;
            txtPhone1st.Text = reportInfo.first_party_info.contact;
            txtPhone2nd.Text = reportInfo.second_party_info.contact;
            txtAge1st.Text = reportInfo.first_party_info.age + "";
            txtAge2nd.Text = reportInfo.second_party_info.age + "";
            txtAddress1st.Text = reportInfo.first_party_info.address;
            txtAddress2nd.Text = reportInfo.second_party_info.address;

            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            pictureBox.Image = Image.FromFile(currentPath + "/" + reportInfo.record_photo);

        }
    }
}
