namespace Inventory_Management_Project
{
    partial class DeliveryPrint
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
            this.btn_Show = new System.Windows.Forms.Button();
            this.txt_TaxInvoiceNo = new System.Windows.Forms.TextBox();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.cmb_ClientName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btn_Show
            // 
            this.btn_Show.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Show.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Show.Location = new System.Drawing.Point(685, 26);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(99, 31);
            this.btn_Show.TabIndex = 32;
            this.btn_Show.Text = "Show";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // txt_TaxInvoiceNo
            // 
            this.txt_TaxInvoiceNo.Location = new System.Drawing.Point(453, 56);
            this.txt_TaxInvoiceNo.Name = "txt_TaxInvoiceNo";
            this.txt_TaxInvoiceNo.Size = new System.Drawing.Size(198, 20);
            this.txt_TaxInvoiceNo.TabIndex = 31;
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Location = new System.Drawing.Point(453, 21);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(198, 20);
            this.txt_ClientName.TabIndex = 30;
            // 
            // cmb_ClientName
            // 
            this.cmb_ClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ClientName.FormattingEnabled = true;
            this.cmb_ClientName.Location = new System.Drawing.Point(126, 22);
            this.cmb_ClientName.Name = "cmb_ClientName";
            this.cmb_ClientName.Size = new System.Drawing.Size(208, 21);
            this.cmb_ClientName.TabIndex = 29;
            this.cmb_ClientName.SelectedIndexChanged += new System.EventHandler(this.cmb_ClientName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "TaxInvoice No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Client Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Delivery Note No.";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(11, 104);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(811, 447);
            this.crystalReportViewer1.TabIndex = 34;
            // 
            // DeliveryPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 566);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.txt_TaxInvoiceNo);
            this.Controls.Add(this.txt_ClientName);
            this.Controls.Add(this.cmb_ClientName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DeliveryPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryPrint";
            this.Load += new System.EventHandler(this.DeliveryPrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.TextBox txt_TaxInvoiceNo;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.ComboBox cmb_ClientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}