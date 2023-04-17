using cutcot_info_system.custom_controls;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using cutcot_info_system.pop_ups;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.Globalization;
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

            String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = path + "/Cutcot Info System/backups/";
            System.IO.Directory.CreateDirectory(path);

            String path2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path2 = path2+ "/Cutcot Info System/temp/";
            System.IO.Directory.CreateDirectory(path2);

            DayOfWeek dayTarget = DateTime.Now.DayOfWeek;

            if (dayTarget == DayOfWeek.Sunday)
            {
                if (CheckForInternetConnection())
                {
                    try
                    {
                        exportDatabase();
                        uploadDatabase();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
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
        public void exportDatabase()
        {

            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                path = path + "/Cutcot Info System/backups/";

                string constring = @"server=" + ConnectMySql.serverAddress + ";userid=dbadmin;password=password;database=cutcot-info-system";
                string file = path + "backup.sql";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while exporting the database");
            }

        }

        public void uploadDatabase()
        {
            try
            {

                using (WebClient client = new())
                {
                    string serverAddress = "ftpupload.net";
                    client.Credentials = new NetworkCredential("b13_33989807", "HhRdWNI@!ka7O@v");
                    string ftpLink = "ftp://" + serverAddress + "/htdocs/backup.sql";

                    String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    path = path + "/Cutcot Info System/backups/backup.sql";

                    client.UploadFile(ftpLink, WebRequestMethods.Ftp.UploadFile, path);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while uploading the database");
            }
        }

        public static bool CheckForInternetConnection(int timeoutMs = 5000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
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

        private void Form1_Shown(object sender, EventArgs e)
        {
        }
    }
}