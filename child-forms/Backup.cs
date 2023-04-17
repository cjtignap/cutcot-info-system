using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
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

namespace cutcot_info_system.child_forms
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
            lblBackupText.Visible = false;
            lblSyncText.Visible = false;
        }

        public void exportDatabase()
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

        public void uploadDatabase()
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

        public void downloadDatabase()
        {
           

                using (WebClient client = new())
                {
                    string serverAddress = "ftpupload.net";
                    client.Credentials = new NetworkCredential("b13_33989807", "HhRdWNI@!ka7O@v");
                    string ftpLink = "ftp://" + serverAddress + "/htdocs/backup.sql";


                    String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    path = path + "/Cutcot Info System/temp/backup.sql";



                    client.DownloadFile(ftpLink, @path);


                }
            
        }
        public void importDatabase()
        {

            

                String path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                String file = path + "/Cutcot Info System/temp/backup.sql";


                string constring = @"server=" + ConnectMySql.serverAddress + ";userid=dbadmin;password=password;database=cutcot-info-system";

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                        }
                    }
                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblSyncText.Visible = false;
            lblBackupText.Visible = true;
            lblBackupText.Text = "Checking your internet connection...";
            lblBackupText.ForeColor = Color.FromArgb(0, 123, 255);
            if (Form1.CheckForInternetConnection())
            {
                try
                {

                    lblBackupText.Text = "Exporting database....";
                    exportDatabase();
                    lblBackupText.Text = "Uploading database.....";
                    uploadDatabase();
                    lblBackupText.Text = "Succesfully created a backup.";
                    lblBackupText.ForeColor = Color.FromArgb(40, 167, 69);
                }
                catch(Exception ex)
                {
                    lblBackupText.Text = "Error exporting/uploading database!";
                    lblBackupText.ForeColor = Color.FromArgb(220, 53, 69);
                }
                
            }
            else
            {
                lblBackupText.Text = "No internet connection!";
                lblBackupText.ForeColor = Color.FromArgb(220, 53, 69);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblBackupText.Visible = false;
            lblSyncText.Visible = true;
            lblSyncText.Text = "Checking your internet connection...";
            lblSyncText.ForeColor = Color.FromArgb(0, 123, 255);
            if (Form1.CheckForInternetConnection())
            {
                try
                {

                    lblSyncText.Text = "Downloading database....";
                    downloadDatabase();
                    lblSyncText.Text = "Syncing database.....";
                    importDatabase();

                    lblSyncText.Text = "Database synced sucesfully.";
                    lblSyncText.ForeColor = Color.FromArgb(40, 167, 69);
                }
                catch(Exception ex)
                {
                    lblSyncText.Text = "Error downloading/syncing database!";
                    lblSyncText.ForeColor = Color.FromArgb(220, 53, 69);
                }
            }
            else
            {

                lblSyncText.Text = "No internet connection!";
                lblSyncText.ForeColor = Color.FromArgb(220, 53, 69);
            }
        }

        private void Backup_Load(object sender, EventArgs e)
        {
        }
    }
}
