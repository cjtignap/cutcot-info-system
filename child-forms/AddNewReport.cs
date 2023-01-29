using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.forms
{
    public partial class AddNewReport : Form
    {
        private String selectedImage;
        public AddNewReport()
        {
            InitializeComponent();
            cmbBlotterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBlotterType.SelectedIndex = 0;
            cmbNature.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNature.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedImage = openFileDialog1.FileName;
                lblSelectedImage.Text = selectedImage;
            }
        }
    }
}
