namespace cutcot_info_system.pop_ups
{
    partial class EditHearing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateHearing = new System.Windows.Forms.DateTimePicker();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(211)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Open Sans SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(361, 239);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 30);
            this.btnAdd.TabIndex = 68;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel12.Controls.Add(this.txtRemarks);
            this.panel12.Location = new System.Drawing.Point(80, 137);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(10, 5, 5, 10);
            this.panel12.Size = new System.Drawing.Size(340, 97);
            this.panel12.TabIndex = 67;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRemarks.Location = new System.Drawing.Point(10, 5);
            this.txtRemarks.Multiline = false;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightMargin = 10;
            this.txtRemarks.Size = new System.Drawing.Size(325, 82);
            this.txtRemarks.TabIndex = 1;
            this.txtRemarks.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(178, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 27);
            this.label2.TabIndex = 66;
            this.label2.Text = "Edit Hearing Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(80, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 65;
            this.label1.Text = "Remarks";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Open Sans SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(80, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 22);
            this.label16.TabIndex = 64;
            this.label16.Text = "Hearing Schedule";
            // 
            // dateHearing
            // 
            this.dateHearing.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.dateHearing.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.dateHearing.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateHearing.Location = new System.Drawing.Point(80, 84);
            this.dateHearing.Name = "dateHearing";
            this.dateHearing.Size = new System.Drawing.Size(288, 25);
            this.dateHearing.TabIndex = 63;
            // 
            // EditHearing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(500, 287);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dateHearing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditHearing";
            this.Text = "Hearings";
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAdd;
        private Panel panel12;
        private RichTextBox txtRemarks;
        private Label label2;
        private Label label1;
        private Label label16;
        private DateTimePicker dateHearing;
    }
}