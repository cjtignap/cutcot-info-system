using cutcot_info_system.models;
using cutcot_info_system.pop_ups;
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
        Image reportImage;

        Hearing firstHearing;
        Hearing secondHearing;
        Hearing thirdHearing;
        string report_id;
        public ViewReport(ReportInfo reportInfo)
        {
            InitializeComponent();
            this.TopMost = true;

            String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String currentPath = path + "/Cutcot Info System/reports";
            report_id = reportInfo.case_no;
            reportImage = Image.FromFile(currentPath + "/" + reportInfo.record_photo);
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
            pictureBox.Image = reportImage;
            firstHearing = reportInfo.firstHearing;
            secondHearing = reportInfo.secondHearing;
            thirdHearing = reportInfo.thirdHearing;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            ImageViewer imageViewer = new ImageViewer(reportImage);
            imageViewer.ShowDialog();
            imageViewer.Dispose();
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewHearing viewHearing = new ViewHearing(firstHearing,secondHearing,thirdHearing,report_id);
            viewHearing.ShowDialog();
        }
    }
}
