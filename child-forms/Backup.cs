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

                    MessageBox.Show("Succesfully backed up");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while uploading the database");
            }
        }

        public void downloadDatabase()
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void importDatabase()
        {

            try
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
                            MessageBox.Show("Database Succesfully Synced");
                        }
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportDatabase();
            uploadDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            downloadDatabase();
            importDatabase();
        }
    }
}
