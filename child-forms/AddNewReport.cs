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
using System.IO;
using System.Reflection;
using cutcot_info_system.pop_ups;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using cutcot_info_system.mysql_things;

namespace cutcot_info_system.forms
{
    public partial class AddNewReport : Form
    {
        private ReportInfo reportInfo;
        private String selectedImage;
        private String generatedFileName;
        Stream selectedImageStream;
        private Hearing firstHearing;
        private Hearing secondHearing;
        private Hearing thirdHearing;
        private String hearingText;
        public AddNewReport()
        {
            InitializeComponent();
            initialSetup();
        }

        public void initialSetup()
        {
            cmbBlotterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBlotterType.SelectedIndex = 0;
            cmbNature.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNature.SelectedIndex = 0;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;
            txtWarning.Visible = false;
            hearingText = "No hearing";
            lblHearings.Text = hearingText;
            lblError2.Visible = false;
            lblError3.Visible = false;
        }


        private string generateFileName()
        {
            Random random = new Random();
            int x = random.Next(1000000);
            int y = random.Next(1000000);
            string fileExtension = selectedImage.Substring(selectedImage.LastIndexOf('.'));
            generatedFileName= x + "-" + y+fileExtension;
            return generatedFileName;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 selectedImage = openFileDialog1.FileName;
               
                lblSelectedImage.Text = selectedImage;
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void saveImage()
        {

            try
            {

                using (WebClient client = new())
                {
                    string serverAddress = ConnectMySql.serverAddress;
                    client.Credentials = new NetworkCredential("dbadmin", "password");
                    string ftpLink = "ftp://"+ serverAddress + "/images/" +generatedFileName;

                    client.UploadFile(ftpLink, WebRequestMethods.Ftp.UploadFile,selectedImage);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Problem Uploading Image");
            }
        }
      
        

        private void AddNewReport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //basic validation
            if (string.IsNullOrEmpty(txtPageNo.Text) ||
                string.IsNullOrEmpty(selectedImage) ||
                string.IsNullOrEmpty(txtName1st.Text) ||
                string.IsNullOrEmpty(txtAge1st.Text) ||
                string.IsNullOrEmpty(txtAddress1st.Text) ||
                string.IsNullOrEmpty(txtPhone1st.Text) ||
                string.IsNullOrEmpty(txtName2nd.Text) ||
                string.IsNullOrEmpty(txtAge2nd.Text) ||
                string.IsNullOrEmpty(txtAddress2nd.Text) ||
                string.IsNullOrEmpty(txtPhone2nd.Text)
                )
            {
                txtWarning.Visible = true;

            }
            else
            {


                txtWarning.Visible = false;
                try
                {
                    string blotterType = cmbBlotterType.SelectedItem.ToString();
                    string natureOfDispute = cmbNature.SelectedItem.ToString();
                    int pageNo = Int32.Parse(txtPageNo.Text);
                    string selectedImage = this.selectedImage;
                    string reportStatus = cmbStatus.SelectedItem.ToString();

                    string name1st = txtName1st.Text;
                    int age1st = Int32.Parse(txtAge1st.Text);
                    string address1st = txtAddress1st.Text;
                    string contact1st = txtPhone1st.Text;

                    string name2nd = txtName2nd.Text;
                    int age2nd = Int32.Parse(txtAge2nd.Text);
                    string address2nd = txtAddress2nd.Text;
                    string contact2nd = txtPhone2nd.Text;

                    PartyInformation firstPartyInformation = new PartyInformation(name1st, address1st, contact1st, age1st);
                    PartyInformation secondPartyInformation = new PartyInformation(name2nd, address2nd, contact2nd, age2nd);


                    generateFileName();
                    reportInfo = new ReportInfo(blotterType, natureOfDispute, pageNo, "0", generatedFileName,firstHearing,secondHearing,thirdHearing, firstPartyInformation, secondPartyInformation, DateTime.Now, reportStatus);
                    ReportInfoDAO reportInfoDAO = new ReportInfoDAO();
                    reportInfoDAO.insert(reportInfo);
                    saveImage();

                    clearForm();
                }
                catch (Exception exc)
                {

                    MessageBox.Show("Make sure to enter valid numbers");
                }

            }
        }
        private void clearForm()
        {
            txtPageNo.Text = "";
            lblHearings.Text = "";
            lblSelectedImage.Text = "";

            txtAge1st.Clear();
            txtAge2nd.Clear();
            txtAddress1st.Clear();
            txtAddress2nd.Clear();
            txtAge1st.Clear();
            txtAge2nd.Clear();
            txtPhone1st.Clear();
            txtPhone2nd.Clear();

            selectedImage = "";
            firstHearing = null;
            secondHearing = null;
            thirdHearing = null;


            lblError2.Visible = false;
            lblError3.Visible = false;
            txtWarning.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (AddHearing addHearing = new AddHearing())
            {
                var result = addHearing.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Hearing hearing = addHearing.hearing;
                    if(firstHearing is null)
                    {
                        firstHearing = hearing;

                        hearingText = "First hearing : "+firstHearing.hearingSchedule.ToLongDateString();
                        lblHearings.Text = hearingText; 
                    }
                    else if(secondHearing is null)
                    {
                        secondHearing = hearing;
                        hearingText+="\nSecond hearing : "+ secondHearing.hearingSchedule.ToLongDateString();
                        lblHearings.Text=hearingText;
                    }
                    else if(thirdHearing is null)
                    {
                        thirdHearing = hearing;
                        hearingText += "\nThird hearing : " + thirdHearing.hearingSchedule.ToLongDateString();
                        lblHearings.Text = hearingText;
                        button3.Enabled = false;
                    }
                }
            }
        }

        private void txtAge1st_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAge1st.Text);
                lblError2.Visible = false;
            }
            catch (Exception ex)
            {
                lblError2.Visible = true;
            }
        }

        private void txtAge2nd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAge2nd.Text);
                lblError3.Visible = false;
            }
            catch (Exception ex)
            {
                lblError3.Visible = true;
            }
        }

        
    }
}
