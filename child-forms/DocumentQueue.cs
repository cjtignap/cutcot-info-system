using cutcot_info_system.child_forms;
using cutcot_info_system.controllers;
using cutcot_info_system.models;
using cutcot_info_system.mysql_things;
using cutcot_info_system.printable_form;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
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
                RequestSinglePanel rsp = new RequestSinglePanel(reader.GetString("id"), 
                    reader.GetString("document_type"), reader.GetString("requested_by"), reader.GetString("status"));

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
            this.Size = new Size(500,50);
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(229, 224, 255);
            this.Padding = new Padding(10, 10, 10, 10);

            Label lblCaseNo = new Label();
            lblCaseNo.Text = requestNo;
            lblCaseNo.Dock = DockStyle.Left;
            lblCaseNo.AutoSize = false;
            lblCaseNo.Size = new Size(25, 20);
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
            lblNature.AutoSize = false;
            lblNature.Size = new Size(170,20);
            lblNature.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);



            Label lblDate = new Label();
            lblDate.Text = requested_by;
            lblDate.Dock = DockStyle.Left;
            lblDate.AutoSize = false;
            lblDate.Size = new Size(225, 20);
            lblDate.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Label lblStatus = new Label();
            lblStatus.Text =status;
            lblStatus.Dock = DockStyle.Left;
            lblStatus.AutoSize = false;
            lblStatus.Size = new Size(150,20);
            lblStatus.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Button btnPrint = new Button();
            btnPrint.Text = "Print";
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Dock = DockStyle.Left;

            Button btnRemove = new Button();
            btnRemove.Text = "Remove";
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Dock = DockStyle.Left;

            Button btnView = new Button();
            btnView.Text = "View";
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Dock = DockStyle.Left;

            this.Controls.Add(btnView);
            this.Controls.Add(lblStatus);
            this.Controls.Add(spacer);
            this.Controls.Add(lblDate);
            this.Controls.Add(spacer);
            this.Controls.Add(lblNature);
            this.Controls.Add(spacer1);
            this.Controls.Add(lblCaseNo);
            this.Controls.Add(btnPrint);
            this.Controls.Add(btnRemove);

           
            btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;

            btnRemove.MouseDown += handleDelete;
            btnPrint.MouseDown += handlePrint;
            btnView.MouseDown += handleClick;
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

        private void handleDelete(object sender,EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to remove this document request?", "Confirm delete", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                DocumentRequestsDAO documentRequestsDAO = new DocumentRequestsDAO();
                Boolean deleteResult = documentRequestsDAO.deleteRequest(requestNo);
                if (deleteResult == true)
                {
                    this.Visible = false;
                }
            }
        }
        private void handlePrint(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDocument printDocument1 = new PrintDocument();
            printPreviewDialog1.SetBounds(100, 100, 400, 518);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += printDocument1_PrintPage;


            if (document_type == "BUSINESS_CLEARANCE")
            {
                BusinessClearanceDAO businessClearanceDAO = new BusinessClearanceDAO();
                BusinessClearance businessClearance = businessClearanceDAO.getBusinessClearance(requestNo);
                BusinessClearanceForm businessClearanceForm = new BusinessClearanceForm(businessClearance);
                businessClearanceForm.Show();
                businessClearanceForm.prepareToPrint();

                captureFromScreen(businessClearanceForm);

                printPreviewDialog1.ShowDialog();
                businessClearanceForm.Hide();
                businessClearanceForm.Dispose();
            }
            else if (document_type == "WATER_CLEARANCE")
            {
                WaterClearanceDAO waterClearanceDAO = new WaterClearanceDAO();
                WaterClearance waterClearance = waterClearanceDAO.getWaterClearance(requestNo);
                WaterClearanceForm waterClearanceForm = new WaterClearanceForm(waterClearance);
                waterClearanceForm.Show();
                waterClearanceForm.prepareToPrint();

                captureFromScreen(waterClearanceForm);

                printPreviewDialog1.ShowDialog();
                waterClearanceForm.Hide();
                waterClearanceForm.Dispose();

            }
            else if (document_type == "WIRING_CLEARANCE")
            {
                WiringClearanceDAO wiringClearanceDAO = new WiringClearanceDAO();
                WiringClearance wiringClearance = wiringClearanceDAO.GetWiringClearance(requestNo);
                WiringClearanceForm wiringClearanceForm = new WiringClearanceForm(wiringClearance);
                wiringClearanceForm.Show();
                wiringClearanceForm.prepareToPrint();

                captureFromScreen(wiringClearanceForm);

                printPreviewDialog1.ShowDialog();
                wiringClearanceForm.Hide();
                wiringClearanceForm.Dispose();

            }

        }

        private void captureFromScreen(Form formToPrint)
        {

             original = new Bitmap(formToPrint.Width, formToPrint.Height);
             formToPrint.DrawToBitmap(original, new Rectangle(0, 0, formToPrint.Width, formToPrint.Height));
             bitMaptoPrint = new Bitmap(original,new Size(816, 1056));
        }
        Bitmap original;
        Bitmap bitMaptoPrint;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle m = new Rectangle(0, 0, 816, 1056);
            e.Graphics.DrawImage(bitMaptoPrint, m);
        }

    }
}
