using cutcot_info_system.custom_controls;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.IO;

namespace cutcot_info_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = path + "/Cutcot Info System";
            System.IO.Directory.CreateDirectory(path);
        }

     

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control )
            {
                    MessageBox.Show("TO BE EDITED SOON");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();

            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}