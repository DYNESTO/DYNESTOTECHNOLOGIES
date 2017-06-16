namespace Inventory_Management_Project
{
    partial class ClientReports_frm
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
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_NewClient = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ShowAll = new System.Windows.Forms.Button();
            this.cmb_ClientName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.txt_ContactName = new System.Windows.Forms.TextBox();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
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
            this.panel2.Controls.Add(this.btn_Export);
            this.panel2.Controls.Add(this.btn_NewClient);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 334);
            this.panel2.TabIndex = 3;
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Export.Location = new System.Drawing.Point(858, 13);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(102, 29);
            this.btn_Export.TabIndex = 21;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_NewClient
            // 
            this.btn_NewClient.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewClient.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_NewClient.Location = new System.Drawing.Point(722, 13);
            this.btn_NewClient.Name = "btn_NewClient";
            this.btn_NewClient.Size = new System.Drawing.Size(118, 29);
            this.btn_NewClient.TabIndex = 20;
            this.btn_NewClient.Text = "New Client";
            this.btn_NewClient.UseVisualStyleBackColor = true;
            this.btn_NewClient.Click += new System.EventHandler(this.btn_NewClient_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(942, 228);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_ShowAll);
            this.panel1.Controls.Add(this.cmb_ClientName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txt_City);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_Reset);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.txt_Phone);
            this.panel1.Controls.Add(this.txt_ContactName);
            this.panel1.Controls.Add(this.txt_ClientName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 151);
            this.panel1.TabIndex = 2;
            // 
            // btn_ShowAll
            // 
            this.btn_ShowAll.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowAll.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_ShowAll.Location = new System.Drawing.Point(835, 88);
            this.btn_ShowAll.Name = "btn_ShowAll";
            this.btn_ShowAll.Size = new System.Drawing.Size(95, 30);
            this.btn_ShowAll.TabIndex = 25;
            this.btn_ShowAll.Text = "Show All";
            this.btn_ShowAll.UseVisualStyleBackColor = true;
            this.btn_ShowAll.Click += new System.EventHandler(this.btn_ShowAll_Click);
            // 
            // cmb_ClientName
            // 
            this.cmb_ClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ClientName.FormattingEnabled = true;
            this.cmb_ClientName.Location = new System.Drawing.Point(752, 20);
            this.cmb_ClientName.Name = "cmb_ClientName";
            this.cmb_ClientName.Size = new System.Drawing.Size(156, 21);
            this.cmb_ClientName.TabIndex = 24;
            this.cmb_ClientName.SelectedIndexChanged += new System.EventHandler(this.cmb_ClientName_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(664, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 17);
            this.label15.TabIndex = 23;
            this.label15.Text = "Client Name";
            // 
            // txt_City
            // 
            this.txt_City.Location = new System.Drawing.Point(387, 17);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(191, 20);
            this.txt_City.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "City";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Reset.Location = new System.Drawing.Point(734, 88);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(95, 30);
            this.btn_Reset.TabIndex = 20;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Search.Location = new System.Drawing.Point(386, 102);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(95, 30);
            this.btn_Search.TabIndex = 19;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(387, 57);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(189, 20);
            this.txt_Phone.TabIndex = 13;
            // 
            // txt_ContactName
            // 
            this.txt_ContactName.Location = new System.Drawing.Point(123, 56);
            this.txt_ContactName.Name = "txt_ContactName";
            this.txt_ContactName.Size = new System.Drawing.Size(184, 20);
            this.txt_ContactName.TabIndex = 10;
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Location = new System.Drawing.Point(123, 20);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(184, 20);
            this.txt_ClientName.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(333, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contact Name";
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
            // ClientReports_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 565);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ClientReports_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientReports";
            this.Load += new System.EventHandler(this.ClientReports_frm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_NewClient;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.TextBox txt_ContactName;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_ClientName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_ShowAll;
    }
}