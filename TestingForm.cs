using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system
{
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();

            
        }
        string selectedImage;
        string fullFilePath;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedImage = openFileDialog1.FileName;

                label1.Text = selectedImage;
                fullFilePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName) + "/" + openFileDialog1.FileName;

                // MessageBox.Show("Selected image : " + selectedImage);
                // MessageBox.Show("Full file image : " + fullFilePath);


                saveImage(new Random().Next(1000)+"");
            }


        }
        private void saveImage(string image)
        {
            try
            {
                using (WebClient client = new())
                {
                    client.Credentials = new NetworkCredential("dbadmin", "password");
                    string ftpLink = "ftp://192.168.1.2/images/"+image+".png";

                    //Stream imageStream = client.OpenRead(ftpLink);
                    //Image image = System.Drawing.Image.FromStream(imageStream);

                    //pictureBox1.Image = image;

                    string imageLink = @"C:\Users\User\Downloads\Group 1.jpg";

                    client.UploadFile(ftpLink, WebRequestMethods.Ftp.UploadFile, selectedImage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
