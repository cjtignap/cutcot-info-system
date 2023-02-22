using cutcot_info_system.child_forms;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.forms
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void cmbNature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlResults.Controls.Clear();
            string query = txtQuery.Text;
            ReportInfoDAO reportInfoDAO = new();
            MySqlDataReader reader = reportInfoDAO.getReportsByName(query);
            
            

            while (reader.Read())
            {

                resultSinglePanel rsp = new resultSinglePanel(reader.GetString("case_no"), reader.GetString("nature_of_dispute"), reader.GetString("date"));
                
                pnlResults.Controls.Add(rsp);

                Panel spacer = new Panel();
                spacer.Size = new Size(100, 10);
                spacer.Dock = DockStyle.Top;
                pnlResults.Controls.Add(spacer);
                
            }
            reader.Close();
            ConnectMySql.getMySqlConnection().Close();
        }

       
    }
     class resultSinglePanel : Panel{
        string caseNo;
        public resultSinglePanel(string caseNo,string nature,string date)
        {
            this.caseNo = caseNo;
            this.Size = new Size(1000, 40);
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(229, 224, 255);
            this.Padding = new Padding(10, 10, 10, 10);

            Label lblCaseNo = new Label();
            lblCaseNo.Text = caseNo;
            lblCaseNo.Dock = DockStyle.Left;
            lblCaseNo.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Panel spacer = new Panel();
            spacer.Size = new Size(40, 10);
            spacer.Dock = DockStyle.Left;

            Panel spacer1 = new Panel();
            spacer1.Size = new Size(40, 10);
            spacer1.Dock = DockStyle.Left;

            Label lblNature = new Label();
            lblNature.Text = nature;
            lblNature.Dock = DockStyle.Left;
            lblNature.AutoSize = true;
            lblNature.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
           


            Label lblDate = new Label();
            lblDate.Text = date;
            lblDate.Dock = DockStyle.Left;
            lblDate.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Controls.Add(lblDate);
            this.Controls.Add(spacer);
            this.Controls.Add(lblNature);
            this.Controls.Add(spacer1);
            this.Controls.Add(lblCaseNo);

            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MouseDown += handleClick;
        }
        ViewReport viewReport;
        private void handleClick(object sender, EventArgs e)
        {
            ReportInfoDAO reportInfoDAO = new ReportInfoDAO();
            ReportInfo reportInfo = reportInfoDAO.getReport(caseNo);

            
            viewReport = new(reportInfo);
            viewReport.ShowDialog();

            viewReport.Dispose();
        }

    }
    
}
