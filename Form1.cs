using cutcot_info_system.custom_controls;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using cutcot_info_system.pop_ups;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;

namespace cutcot_info_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.ActiveControl = this.txtUsesrname;
            
        }

     

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemSemicolon && e.Modifiers == Keys.Control )
            {
                    MessageBox.Show("TO BE EDITED SOON");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            login();
            
        }

        public void login()
        {
            string userName = txtUsesrname.Text.Trim();
            string password = txtPassword.Text;
            //031418003
            if (userName == "barangaycutcot03" && password == "fightcutcot03")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            AboutUs about = new();
            about.ShowDialog();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}