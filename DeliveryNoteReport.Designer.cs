namespace Inventory_Management_Project
{
    partial class DeliveryNoteReport_frm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Paid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.cmb_Payment = new System.Windows.Forms.ComboBox();
            this.txt_Amount_Due = new System.Windows.Forms.TextBox();
            this.txt_Amount_Paid = new System.Windows.Forms.TextBox();
            this.txt_Total_Amount = new System.Windows.Forms.TextBox();
            this.txt_Invoice_No = new System.Windows.Forms.TextBox();
            this.txt_Client_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_NewDeliveryNote = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Report = new System.Windows.Forms.Button();
            this.cmb_ClientName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.txt_InvoiceNumber = new System.Windows.Forms.TextBox();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_Export);
            this.panel2.Controls.Add(this.btn_NewDeliveryNote);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 514);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_Paid);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btn_Pay);
            this.panel3.Controls.Add(this.cmb_Payment);
            this.panel3.Controls.Add(this.txt_Amount_Due);
            this.panel3.Controls.Add(this.txt_Amount_Paid);
            this.panel3.Controls.Add(this.txt_Total_Amount);
            this.panel3.Controls.Add(this.txt_Invoice_No);
            this.panel3.Controls.Add(this.txt_Client_Name);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(136, 278);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(689, 209);
            this.panel3.TabIndex = 32;
            // 
            // lbl_Paid
            // 
            this.lbl_Paid.AutoSize = true;
            this.lbl_Paid.Location = new System.Drawing.Point(157, 149);
            this.lbl_Paid.Name = "lbl_Paid";
            this.lbl_Paid.Size = new System.Drawing.Size(0, 13);
            this.lbl_Paid.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Amount Paid";
            // 
            // btn_Pay
            // 
            this.btn_Pay.Enabled = false;
            this.btn_Pay.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pay.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Pay.Location = new System.Drawing.Point(300, 165);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(113, 28);
            this.btn_Pay.TabIndex = 24;
            this.btn_Pay.Text = "Pay";
            this.btn_Pay.UseVisualStyleBackColor = true;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // cmb_Payment
            // 
            this.cmb_Payment.FormattingEnabled = true;
            this.cmb_Payment.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Dimand Draft"});
            this.cmb_Payment.Location = new System.Drawing.Point(146, 61);
            this.cmb_Payment.Name = "cmb_Payment";
            this.cmb_Payment.Size = new System.Drawing.Size(153, 21);
            this.cmb_Payment.TabIndex = 23;
            // 
            // txt_Amount_Due
            // 
            this.txt_Amount_Due.Location = new System.Drawing.Point(410, 107);
            this.txt_Amount_Due.Name = "txt_Amount_Due";
            this.txt_Amount_Due.ReadOnly = true;
            this.txt_Amount_Due.Size = new System.Drawing.Size(153, 20);
            this.txt_Amount_Due.TabIndex = 22;
            // 
            // txt_Amount_Paid
            // 
            this.txt_Amount_Paid.Location = new System.Drawing.Point(146, 110);
            this.txt_Amount_Paid.Name = "txt_Amount_Paid";
            this.txt_Amount_Paid.Size = new System.Drawing.Size(153, 20);
            this.txt_Amount_Paid.TabIndex = 21;
            this.txt_Amount_Paid.TextChanged += new System.EventHandler(this.txt_Amount_Paid_TextChanged);
            this.txt_Amount_Paid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Amount_Paid_KeyPress);
            // 
            // txt_Total_Amount
            // 
            this.txt_Total_Amount.Location = new System.Drawing.Point(410, 58);
            this.txt_Total_Amount.Name = "txt_Total_Amount";
            this.txt_Total_Amount.ReadOnly = true;
            this.txt_Total_Amount.Size = new System.Drawing.Size(153, 20);
            this.txt_Total_Amount.TabIndex = 20;
            // 
            // txt_Invoice_No
            // 
            this.txt_Invoice_No.Location = new System.Drawing.Point(410, 14);
            this.txt_Invoice_No.Name = "txt_Invoice_No";
            this.txt_Invoice_No.ReadOnly = true;
            this.txt_Invoice_No.Size = new System.Drawing.Size(153, 20);
            this.txt_Invoice_No.TabIndex = 19;
            // 
            // txt_Client_Name
            // 
            this.txt_Client_Name.Location = new System.Drawing.Point(146, 15);
            this.txt_Client_Name.Name = "txt_Client_Name";
            this.txt_Client_Name.ReadOnly = true;
            this.txt_Client_Name.Size = new System.Drawing.Size(153, 20);
            this.txt_Client_Name.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(317, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Amount Due";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(317, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Total Amount";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(42, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Amount Paid";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(42, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "PaymentType";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(317, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 17);
            this.label16.TabIndex = 13;
            this.label16.Text = "Delivery No.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(42, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 17);
            this.label17.TabIndex = 12;
            this.label17.Text = "Client Name";
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Export.Location = new System.Drawing.Point(858, 13);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(102, 29);
            this.btn_Export.TabIndex = 21;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_NewDeliveryNote
            // 
            this.btn_NewDeliveryNote.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewDeliveryNote.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_NewDeliveryNote.Location = new System.Drawing.Point(693, 13);
            this.btn_NewDeliveryNote.Name = "btn_NewDeliveryNote";
            this.btn_NewDeliveryNote.Size = new System.Drawing.Size(147, 29);
            this.btn_NewDeliveryNote.TabIndex = 20;
            this.btn_NewDeliveryNote.Text = "New DeliveryNote";
            this.btn_NewDeliveryNote.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(942, 207);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.btn_Report);
            this.panel1.Controls.Add(this.cmb_ClientName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.btn_Reset);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.txt_City);
            this.panel1.Controls.Add(this.txt_InvoiceNumber);
            this.panel1.Controls.Add(this.txt_ClientName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 183);
            this.panel1.TabIndex = 2;
            // 
            // btn_Report
            // 
            this.btn_Report.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Report.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Report.Location = new System.Drawing.Point(778, 144);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(90, 27);
            this.btn_Report.TabIndex = 23;
            this.btn_Report.Text = "Report";
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // cmb_ClientName
            // 
            this.cmb_ClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ClientName.FormattingEnabled = true;
            this.cmb_ClientName.Location = new System.Drawing.Point(489, 95);
            this.cmb_ClientName.Name = "cmb_ClientName";
            this.cmb_ClientName.Size = new System.Drawing.Size(156, 21);
            this.cmb_ClientName.TabIndex = 22;
            this.cmb_ClientName.SelectedIndexChanged += new System.EventHandler(this.cmb_ClientName_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(405, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 17);
            this.label15.TabIndex = 21;
            this.label15.Text = "Client Name";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Reset.Location = new System.Drawing.Point(874, 144);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(90, 27);
            this.btn_Reset.TabIndex = 20;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Search.Location = new System.Drawing.Point(116, 118);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(87, 27);
            this.btn_Search.TabIndex = 19;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_City
            // 
            this.txt_City.Location = new System.Drawing.Point(116, 92);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(184, 20);
            this.txt_City.TabIndex = 11;
            this.txt_City.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_City_KeyPress);
            // 
            // txt_InvoiceNumber
            // 
            this.txt_InvoiceNumber.Location = new System.Drawing.Point(116, 56);
            this.txt_InvoiceNumber.Name = "txt_InvoiceNumber";
            this.txt_InvoiceNumber.Size = new System.Drawing.Size(184, 20);
            this.txt_InvoiceNumber.TabIndex = 10;
            this.txt_InvoiceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_InvoiceNumber_KeyPress);
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Location = new System.Drawing.Point(116, 20);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(184, 20);
            this.txt_ClientName.TabIndex = 9;
            this.txt_ClientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ClientName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Invoice Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Name";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_refresh.Location = new System.Drawing.Point(817, 85);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(90, 27);
            this.btn_refresh.TabIndex = 24;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // DeliveryNoteReport_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 737);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "DeliveryNoteReport_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryNoteReport";
            this.Load += new System.EventHandler(this.DeliveryNoteReport_frm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Pay;
        private System.Windows.Forms.ComboBox cmb_Payment;
        private System.Windows.Forms.TextBox txt_Amount_Due;
        private System.Windows.Forms.TextBox txt_Amount_Paid;
        private System.Windows.Forms.TextBox txt_Total_Amount;
        private System.Windows.Forms.TextBox txt_Invoice_No;
        private System.Windows.Forms.TextBox txt_Client_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_NewDeliveryNote;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_ClientName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.TextBox txt_InvoiceNumber;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Paid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Report;
        private System.Windows.Forms.Button btn_refresh;
    }
}