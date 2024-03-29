﻿using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using cutcot_info_system.pop_ups;
using cutcot_info_system.printable_form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.child_forms
{
    public partial class ViewReport : Form
    {
        Image reportImage;

        Hearing firstHearing;
        Hearing secondHearing;
        Hearing thirdHearing;
        string report_id;

        ReportInfo reportInfo;
        public ViewReport(ReportInfo reportInfo)
        {
            InitializeComponent();

            this.reportInfo = reportInfo;
            //this.TopMost = true;

            
            report_id = reportInfo.case_no;
            txtBlotterType.Text = reportInfo.report_type;
            txtStatus.Text = reportInfo.status;
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


            loadImage();

            
            firstHearing = reportInfo.firstHearing;
            secondHearing = reportInfo.secondHearing;
            thirdHearing = reportInfo.thirdHearing;

            this.ActiveControl = null;


        }
        private void loadImage()
        {

            try
            {
                using (WebClient client = new())
                {
                    string serverAddress = ConnectMySql.serverAddress;
                    client.Credentials = new NetworkCredential("dbadmin", "password");
                    string ftpLink = "ftp://"+ serverAddress + "/images/"+reportInfo.record_photo;

                    Stream imageStream = client.OpenRead(ftpLink);
                    reportImage = System.Drawing.Image.FromStream(imageStream);
                    pictureBox.Image = reportImage;
                }
            }
            catch (System.Net.WebException e)
            {
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if(reportImage != null)
            {

                ImageViewer imageViewer = new ImageViewer(reportImage);
                imageViewer.ShowDialog();
                imageViewer.Dispose();
            }
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewHearing viewHearing = new ViewHearing(firstHearing,secondHearing,thirdHearing,report_id);
            viewHearing.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            using (ChangeStatus changeStatus = new ChangeStatus(report_id))
            {
                var result = changeStatus.ShowDialog();
                if(result == DialogResult.OK)
                {
                    txtStatus.Text = changeStatus.status;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            

         

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDocument printDocument1 = new PrintDocument();
            printPreviewDialog1.SetBounds(100, 100, 400, 518);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += printDocument1_PrintPage;

            BlotterReport blotterReport = new BlotterReport(reportInfo);
            blotterReport.Show();

            captureFromScreen(blotterReport.panelToPrint);

            blotterReport.Hide();
            printPreviewDialog1.ShowDialog();


        }
        private void captureFromScreen(Panel formToPrint)
        {

            original = new Bitmap(formToPrint.Width, formToPrint.Height);
            formToPrint.DrawToBitmap(original, new Rectangle(0, 0, formToPrint.Width, formToPrint.Height ));
            bitMaptoPrint = original;
        }
        Bitmap original;
        Bitmap bitMaptoPrint;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle m = new Rectangle(0, 0, 816, 1056);
            e.Graphics.DrawImage(original, m);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(214, 34, 46);
            button3.ForeColor = Color.FromArgb(246, 248, 250);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(214, 34, 46);
            button3.BackColor = Color.FromArgb(246, 248, 250);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this report", "Confirm delete", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                ReportInfoDAO report = new ReportInfoDAO();
                report.deleteReport(report_id);
                MessageBox.Show("Record sucesfully deleted.");
                this.DialogResult = DialogResult.OK;
                this.Close();
                this.Dispose();
            }
        }
    }
}
