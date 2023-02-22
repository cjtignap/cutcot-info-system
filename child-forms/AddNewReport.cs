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
using System.IO;
using System.Reflection;

namespace cutcot_info_system.forms
{
    public partial class AddNewReport : Form
    {
        private ReportInfo reportInfo;
        private String selectedImage;
        private String generatedFileName;
        Stream selectedImageStream;
        public AddNewReport()
        {
            InitializeComponent();
            cmbBlotterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBlotterType.SelectedIndex = 0;
            cmbNature.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNature.SelectedIndex = 0;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;
            txtWarning.Visible = false;
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
                selectedImageStream=openFileDialog1.OpenFile();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void saveImage()
        {

            try
            {
                string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;

                using (Stream saveFile = File.Create(currentPath + generatedFileName))
                {
                    selectedImageStream.CopyTo(saveFile);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to save Image");
            }
        }
      
        

        private void AddNewReport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //basic validation
            if (string.IsNullOrEmpty(txtCaseNo.Text) ||
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
                    int pageNo = Int32.Parse(txtCaseNo.Text);
                    string selectedImage = this.selectedImage;
                    DateTime firstHearing = dateFirstHearing.Value.Date;
                    string reportStatus = cmbStatus.GetItemText(cmbStatus.SelectedIndex);

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
                    reportInfo = new ReportInfo(blotterType, natureOfDispute, pageNo, "0", generatedFileName, firstHearing, firstPartyInformation, secondPartyInformation, DateTime.Now);
                    ReportInfoDAO reportInfoDAO = new ReportInfoDAO();
                    reportInfoDAO.insert(reportInfo);
                    saveImage();
                }
                catch (Exception exc)
                {

                    MessageBox.Show("Make sure to enter valid numbers");
                }

            }
        }
    }
}
