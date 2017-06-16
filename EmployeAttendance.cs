using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Configuration;


namespace Inventory_Management_Project
{
    public partial class EmployeAttendance : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public EmployeAttendance()
        {
            InitializeComponent();
        }

        private bool isvalidated()
        {
            if (comboBox3_EmployeeName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Employee Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3_EmployeeName.Focus();
                return false;
            }
            if (comboBox1_Month.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Month Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1_Month.Focus();
                return false;
            }
            if (comboBox2_Year.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Year is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2_Year.Focus();
                return false;
            }

            return true;
        }

        private void bt1_Save_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {

                string gender = "";
                if (radioButton1_present.Checked == true)
                {
                    gender = "Present";
                }
                else if (radioButton2_Absent.Checked == true)
                {
                    gender = "Absent";
                }

                SqlCommand cmd = new SqlCommand("insert into Attendance(ID,Month,Year,EntryDate,EmloyeeName,EmployeeCode,Department,Designation,Status,InTime,OutTime) values(@ID,@Month,@Year,@EntryDate,@EmloyeeName,@EmployeeCode,@Department,@Designation,@Status,@InTime,@OutTime)", con);

                con.Open();
                cmd.Parameters.AddWithValue("@ID", txt1_AttendanceID.Text.Trim());
                cmd.Parameters.AddWithValue("@Month", comboBox1_Month.Text.Trim());
                cmd.Parameters.AddWithValue("@Year", comboBox2_Year.Text.Trim());
                cmd.Parameters.AddWithValue("@EntryDate", dateTimePicker3.Text.ToString());
                cmd.Parameters.AddWithValue("@EmloyeeName", comboBox3_EmployeeName.Text.Trim());
                cmd.Parameters.AddWithValue("@EmployeeCode", txt2_EmployeeCode.Text.Trim());
                cmd.Parameters.AddWithValue("@Department", txt3_Department.Text.ToString());
                cmd.Parameters.AddWithValue("@Designation", txt4_Desigation.Text.Trim());
                cmd.Parameters.AddWithValue("@Status", gender);
                cmd.Parameters.AddWithValue("@InTime", dateTimePicker1_InTime.Text.ToString());
                cmd.Parameters.AddWithValue("@OutTime", dateTimePicker2_OUTTIME.Text.ToString());



                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Save Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
                con.Close();
            }
        }

        int number = 0;
        int value2;
        string number_String;

        private void EmployeAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from EmployeRegisterTable";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox3_EmployeeName.SelectedItem = "Select";
                    comboBox3_EmployeeName.Items.Add(reader["EmployeName"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();

            try
            {
                String query = "select * from Attendance";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    number_String = reader["ID"].ToString();

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
            number = Convert.ToInt32(number_String);
            value2 = number + 1;
            txt1_AttendanceID.Text = Convert.ToString(value2);
        }

        public void clear()
        {
            txt2_EmployeeCode.Text = "";
            txt3_Department.Text = "";
            txt4_Desigation.Text = "";
            comboBox3_EmployeeName.Text = "";
            comboBox1_Month.Text = "";
            comboBox2_Year.Text = "";

        }

        private void comboBox3_EmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compare = comboBox3_EmployeeName.Text;
            try
            {
                String query = "select * from EmployeRegisterTable where EmployeName='" + compare + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txt2_EmployeeCode.Text = reader["EmpID"].ToString();
                    txt3_Department.Text = reader["Department"].ToString();
                    txt4_Desigation.Text = reader["Designation"].ToString();

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
        }

        private void bt2_Reset_Click(object sender, EventArgs e)
        {
            clear();

            try
            {
                String query = "select * from Attendance";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    number_String = reader["ID"].ToString();

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
            number = Convert.ToInt32(number_String);
            value2 = number + 1;
            txt1_AttendanceID.Text = Convert.ToString(value2);
        }

        private void bt3_ViewAll_Click(object sender, EventArgs e)
        {
            AttendanceRecord frm = new AttendanceRecord();
            frm.Show();
        }
    }
}
