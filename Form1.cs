using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;

namespace cutcot_info_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
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
    }
}