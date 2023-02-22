namespace cutcot_info_system.forms
{
    partial class RequestDocument
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.pnlInfoField = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans SemiBold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(58, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 32);
            this.label1.TabIndex = 43;
            this.label1.Text = "Document Type";
            // 
            // cmbDocType
            // 
            this.cmbDocType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDocType.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.ItemHeight = 22;
            this.cmbDocType.Items.AddRange(new object[] {
            "WATER CLEARANCE",
            "WIRING CLEARANCE",
            "BUSINESS CLEARANCE"});
            this.cmbDocType.Location = new System.Drawing.Point(58, 59);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(192, 30);
            this.cmbDocType.TabIndex = 59;
            this.cmbDocType.SelectedIndexChanged += new System.EventHandler(this.cmbDocType_SelectedIndexChanged);
            // 
            // pnlInfoField
            // 
            this.pnlInfoField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfoField.Location = new System.Drawing.Point(0, 94);
            this.pnlInfoField.Name = "pnlInfoField";
            this.pnlInfoField.Size = new System.Drawing.Size(1256, 564);
            this.pnlInfoField.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(211)))));
            this.label2.Location = new System.Drawing.Point(353, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 27);
            this.label2.TabIndex = 61;
            this.label2.Text = "Enter Details Below";
            // 
            // DocumentQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1256, 658);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlInfoField);
            this.Controls.Add(this.cmbDocType);
            this.Controls.Add(this.label1);
            this.Name = "DocumentQueue";
            this.Text = "DocumentQueue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbDocType;
        private Panel pnlInfoField;
        private Label label2;
    }
}