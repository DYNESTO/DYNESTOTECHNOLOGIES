namespace Inventory_Management_Project
{
    partial class EmployeAttendance
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
            this.comboBox3_EmployeeName = new System.Windows.Forms.ComboBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.comboBox2_Year = new System.Windows.Forms.ComboBox();
            this.comboBox1_Month = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2_OUTTIME = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1_InTime = new System.Windows.Forms.DateTimePicker();
            this.radioButton2_Absent = new System.Windows.Forms.RadioButton();
            this.radioButton1_present = new System.Windows.Forms.RadioButton();
            this.txt4_Desigation = new System.Windows.Forms.TextBox();
            this.txt3_Department = new System.Windows.Forms.TextBox();
            this.txt2_EmployeeCode = new System.Windows.Forms.TextBox();
            this.txt1_AttendanceID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt3_ViewAll = new System.Windows.Forms.Button();
            this.bt2_Reset = new System.Windows.Forms.Button();
            this.bt1_Save = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox3_EmployeeName
            // 
            this.comboBox3_EmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3_EmployeeName.FormattingEnabled = true;
            this.comboBox3_EmployeeName.Location = new System.Drawing.Point(176, 149);
            this.comboBox3_EmployeeName.Name = "comboBox3_EmployeeName";
            this.comboBox3_EmployeeName.Size = new System.Drawing.Size(319, 21);
            this.comboBox3_EmployeeName.TabIndex = 16;
            this.comboBox3_EmployeeName.SelectedIndexChanged += new System.EventHandler(this.comboBox3_EmployeeName_SelectedIndexChanged);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(176, 110);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(178, 20);
            this.dateTimePicker3.TabIndex = 14;
            // 
            // comboBox2_Year
            // 
            this.comboBox2_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2_Year.FormattingEnabled = true;
            this.comboBox2_Year.Items.AddRange(new object[] {
            "2017\t",
            "2018",
            "2019",
            "2020"});
            this.comboBox2_Year.Location = new System.Drawing.Point(725, 110);
            this.comboBox2_Year.Name = "comboBox2_Year";
            this.comboBox2_Year.Size = new System.Drawing.Size(159, 21);
            this.comboBox2_Year.TabIndex = 34;
            // 
            // comboBox1_Month
            // 
            this.comboBox1_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_Month.FormattingEnabled = true;
            this.comboBox1_Month.Items.AddRange(new object[] {
            "January ",
            "February ",
            "March ",
            "April ",
            "May ",
            "June ",
            "July ",
            "August ",
            "September ",
            "October ",
            "November ",
            "December"});
            this.comboBox1_Month.Location = new System.Drawing.Point(725, 60);
            this.comboBox1_Month.Name = "comboBox1_Month";
            this.comboBox1_Month.Size = new System.Drawing.Size(159, 21);
            this.comboBox1_Month.TabIndex = 33;
            // 
            // dateTimePicker2_OUTTIME
            // 
            this.dateTimePicker2_OUTTIME.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2_OUTTIME.Location = new System.Drawing.Point(176, 381);
            this.dateTimePicker2_OUTTIME.Name = "dateTimePicker2_OUTTIME";
            this.dateTimePicker2_OUTTIME.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker2_OUTTIME.TabIndex = 30;
            // 
            // dateTimePicker1_InTime
            // 
            this.dateTimePicker1_InTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1_InTime.Location = new System.Drawing.Point(176, 344);
            this.dateTimePicker1_InTime.Name = "dateTimePicker1_InTime";
            this.dateTimePicker1_InTime.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker1_InTime.TabIndex = 28;
            // 
            // radioButton2_Absent
            // 
            this.radioButton2_Absent.AutoSize = true;
            this.radioButton2_Absent.Location = new System.Drawing.Point(355, 309);
            this.radioButton2_Absent.Name = "radioButton2_Absent";
            this.radioButton2_Absent.Size = new System.Drawing.Size(58, 17);
            this.radioButton2_Absent.TabIndex = 27;
            this.radioButton2_Absent.TabStop = true;
            this.radioButton2_Absent.Text = "Absent";
            this.radioButton2_Absent.UseVisualStyleBackColor = true;
            // 
            // radioButton1_present
            // 
            this.radioButton1_present.AutoSize = true;
            this.radioButton1_present.Location = new System.Drawing.Point(176, 307);
            this.radioButton1_present.Name = "radioButton1_present";
            this.radioButton1_present.Size = new System.Drawing.Size(61, 17);
            this.radioButton1_present.TabIndex = 24;
            this.radioButton1_present.TabStop = true;
            this.radioButton1_present.Text = "Present";
            this.radioButton1_present.UseVisualStyleBackColor = true;
            // 
            // txt4_Desigation
            // 
            this.txt4_Desigation.Location = new System.Drawing.Point(176, 267);
            this.txt4_Desigation.Name = "txt4_Desigation";
            this.txt4_Desigation.ReadOnly = true;
            this.txt4_Desigation.Size = new System.Drawing.Size(319, 20);
            this.txt4_Desigation.TabIndex = 22;
            // 
            // txt3_Department
            // 
            this.txt3_Department.Location = new System.Drawing.Point(176, 227);
            this.txt3_Department.Name = "txt3_Department";
            this.txt3_Department.ReadOnly = true;
            this.txt3_Department.Size = new System.Drawing.Size(319, 20);
            this.txt3_Department.TabIndex = 20;
            // 
            // txt2_EmployeeCode
            // 
            this.txt2_EmployeeCode.Location = new System.Drawing.Point(176, 187);
            this.txt2_EmployeeCode.Name = "txt2_EmployeeCode";
            this.txt2_EmployeeCode.ReadOnly = true;
            this.txt2_EmployeeCode.Size = new System.Drawing.Size(319, 20);
            this.txt2_EmployeeCode.TabIndex = 18;
            // 
            // txt1_AttendanceID
            // 
            this.txt1_AttendanceID.Location = new System.Drawing.Point(176, 64);
            this.txt1_AttendanceID.Name = "txt1_AttendanceID";
            this.txt1_AttendanceID.ReadOnly = true;
            this.txt1_AttendanceID.Size = new System.Drawing.Size(178, 20);
            this.txt1_AttendanceID.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(55, 387);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 32;
            this.label11.Text = "Out Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(55, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "In time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Designation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Department";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Employee Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Employee Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "EntryDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(605, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "AttendanceID";
            // 
            // bt3_ViewAll
            // 
            this.bt3_ViewAll.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3_ViewAll.Location = new System.Drawing.Point(817, 353);
            this.bt3_ViewAll.Name = "bt3_ViewAll";
            this.bt3_ViewAll.Size = new System.Drawing.Size(126, 33);
            this.bt3_ViewAll.TabIndex = 37;
            this.bt3_ViewAll.Text = "View Record";
            this.bt3_ViewAll.UseVisualStyleBackColor = true;
            this.bt3_ViewAll.Click += new System.EventHandler(this.bt3_ViewAll_Click);
            // 
            // bt2_Reset
            // 
            this.bt2_Reset.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2_Reset.Location = new System.Drawing.Point(817, 314);
            this.bt2_Reset.Name = "bt2_Reset";
            this.bt2_Reset.Size = new System.Drawing.Size(126, 33);
            this.bt2_Reset.TabIndex = 36;
            this.bt2_Reset.Text = "New";
            this.bt2_Reset.UseVisualStyleBackColor = true;
            this.bt2_Reset.Click += new System.EventHandler(this.bt2_Reset_Click);
            // 
            // bt1_Save
            // 
            this.bt1_Save.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1_Save.Location = new System.Drawing.Point(817, 275);
            this.bt1_Save.Name = "bt1_Save";
            this.bt1_Save.Size = new System.Drawing.Size(126, 33);
            this.bt1_Save.TabIndex = 35;
            this.bt1_Save.Text = "Save";
            this.bt1_Save.UseVisualStyleBackColor = true;
            this.bt1_Save.Click += new System.EventHandler(this.bt1_Save_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(0, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(998, 38);
            this.label12.TabIndex = 38;
            this.label12.Text = "Employee Attendance";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 461);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bt3_ViewAll);
            this.Controls.Add(this.bt2_Reset);
            this.Controls.Add(this.bt1_Save);
            this.Controls.Add(this.comboBox3_EmployeeName);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.comboBox2_Year);
            this.Controls.Add(this.comboBox1_Month);
            this.Controls.Add(this.dateTimePicker2_OUTTIME);
            this.Controls.Add(this.dateTimePicker1_InTime);
            this.Controls.Add(this.radioButton2_Absent);
            this.Controls.Add(this.radioButton1_present);
            this.Controls.Add(this.txt4_Desigation);
            this.Controls.Add(this.txt3_Department);
            this.Controls.Add(this.txt2_EmployeeCode);
            this.Controls.Add(this.txt1_AttendanceID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmployeAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeAttendance";
            this.Load += new System.EventHandler(this.EmployeAttendance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox3_EmployeeName;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.ComboBox comboBox2_Year;
        private System.Windows.Forms.ComboBox comboBox1_Month;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_OUTTIME;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_InTime;
        private System.Windows.Forms.RadioButton radioButton2_Absent;
        private System.Windows.Forms.RadioButton radioButton1_present;
        private System.Windows.Forms.TextBox txt4_Desigation;
        private System.Windows.Forms.TextBox txt3_Department;
        private System.Windows.Forms.TextBox txt2_EmployeeCode;
        private System.Windows.Forms.TextBox txt1_AttendanceID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt3_ViewAll;
        private System.Windows.Forms.Button bt2_Reset;
        private System.Windows.Forms.Button bt1_Save;
        private System.Windows.Forms.Label label12;
    }
}