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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace cutcot_info_system.forms
{
    public partial class Reports : Form
    {

       
       
        public Reports()
        {
            InitializeComponent();
            cmbNature.SelectedIndex = 0;
            cmbNature.DropDownStyle = ComboBoxStyle.DropDownList;

            displayReports();
        }


        public void displayReports()
        {
            string searchType = cmbNature.SelectedItem.ToString();
            pnlResults.Controls.Clear();
            string query = txtQuery.Text;

            switch (searchType)
            {
                case "name":
                    break;
                case "case no":
                    searchType = "case_no";
                    break;
                case "status":
                    break;
                case "page":
                    break;
                case "nature":
                    break;
                case "type":
                    break;
                default:
                    break;

            }


            ReportInfoDAO reportInfoDAO = new();
            MySqlDataReader reader = reportInfoDAO.getReports(query, searchType);


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

            resultSinglePanel rsp1 = new resultSinglePanel("Case #", "Nature of dispute", "Date");
            rsp1.Enabled = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            pnlResults.Controls.Add(rsp1);


            ConnectMySql.getMySqlConnection().Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            displayReports();
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

            var result =  viewReport.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.Visible = false;
            }

            viewReport.Dispose();
        }

    }
    
}
