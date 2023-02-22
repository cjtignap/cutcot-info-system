using cutcot_info_system.child_forms;
using cutcot_info_system.controllers;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using cutcot_info_system.printable_form;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiringClearance = cutcot_info_system.models.WiringClearance;

namespace cutcot_info_system.forms
{
    public partial class DocumentQueue : Form
    {
        public DocumentQueue()
        {
            InitializeComponent();

            pnlResults.Controls.Clear();

            DocumentRequestsDAO documentRequestsDAO= new DocumentRequestsDAO();
            MySqlDataReader reader = documentRequestsDAO.getDocumentRequests();

            while (reader.Read())
            {
                RequestSinglePanel rsp = new RequestSinglePanel(reader.GetString("id"), reader.GetString("document_type"), reader.GetString("requested_by"), reader.GetString("status"));


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

    class RequestSinglePanel : Panel
    {
        string requestNo;
        string document_type;
        public RequestSinglePanel(string requestNo, string document_type, string requested_by,string status)
        {
            this.requestNo = requestNo;
            this.document_type = document_type;
            this.Size = new Size(100, 40);
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(229, 224, 255);
            this.Padding = new Padding(10, 10, 10, 10);

            Label lblCaseNo = new Label();
            lblCaseNo.Text = requestNo;
            lblCaseNo.Dock = DockStyle.Left;
            lblCaseNo.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Panel spacer = new Panel();
            spacer.Size = new Size(40, 10);
            spacer.Dock = DockStyle.Left;

            Panel spacer1 = new Panel();
            spacer1.Size = new Size(40, 10);
            spacer1.Dock = DockStyle.Left;

            Label lblNature = new Label();
            lblNature.Text = document_type;
            lblNature.Dock = DockStyle.Left;
            lblNature.AutoSize = true;
            lblNature.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);



            Label lblDate = new Label();
            lblDate.Text = requested_by;
            lblDate.Dock = DockStyle.Left;
            lblDate.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Label lblStatus = new Label();
            lblStatus.Text =status;
            lblStatus.Dock = DockStyle.Left;
            lblStatus.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.Controls.Add(lblStatus);
            this.Controls.Add(spacer);
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
            if (document_type=="BUSINESS_CLEARANCE")
            {
                BusinessClearanceDAO businessClearanceDAO = new BusinessClearanceDAO();
                BusinessClearance businessClearance = businessClearanceDAO.getBusinessClearance(requestNo);
                BusinessClearanceForm businessClearanceForm = new BusinessClearanceForm(businessClearance);
                businessClearanceForm.ShowDialog();
                businessClearanceForm.Dispose();
            }
            else if (document_type == "WATER_CLEARANCE")
            {
                WaterClearanceDAO waterClearanceDAO= new WaterClearanceDAO();
                WaterClearance waterClearance = waterClearanceDAO.getWaterClearance(requestNo);
                WaterClearanceForm waterClearanceForm = new WaterClearanceForm(waterClearance);
                waterClearanceForm.ShowDialog();
                waterClearanceForm.Dispose();
            }
            else if (document_type == "WIRING_CLEARANCE")
            {
                WiringClearanceDAO wiringClearanceDAO = new WiringClearanceDAO();
                WiringClearance wiringClearance = wiringClearanceDAO.GetWiringClearance(requestNo);
                WiringClearanceForm wiringClearanceForm = new WiringClearanceForm(wiringClearance);
                wiringClearanceForm.ShowDialog();
                wiringClearanceForm.Dispose();
            }


        }

    }
}
