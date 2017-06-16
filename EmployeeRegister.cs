using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Inventory_Management_Project
{
    public partial class EmployeeRegister : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
         string imgLocation1 = "";
        SqlDataReader reader;
        public EmployeeRegister()
        {
            InitializeComponent();
        }

        int number = 0;
        int value2;
        string number_String;

        private void EmployeeRegister_Load(object sender, EventArgs e)
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
                    cmb_StaffID.SelectedItem = "Select";
                    cmb_StaffID.Items.Add(reader["EmpID"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();

              
            try
            {
                String query = "select * from EmployeRegisterTable";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   number_String= reader["EmpID"].ToString();
                  
                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
            number = Convert.ToInt32(number_String);
            value2 = number + 1;
            txtStaffID.Text = Convert.ToString(value2);
        }

        public void Clear()
        {
            txtStaffName.Text = "";
            txt_Department.Text = "";
            txt_Designation.Text = "";
            txt_Experiance.Text = "";
            txtBasicSalary.Text = "";
            txtDateOfJoining.Text = "";
            txtEmail.Text = "";
            txtFatherName.Text = "";
            txtMobileNo.Text = "";
            txtmotherName.Text = "";
            txtPAddress.Text = "";
            txtQualifications.Text = "";
            txtTAddress.Text = "";
            cmbGender.Text = "";
            cmbstatus.Text = "";
            pictureBox_EmployeImage.Image = null;
        }

        private bool isvalidated()
        {
            if (txtStaffName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Employee Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStaffName.Focus();
                return false;
            }
            if (cmbGender.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Gender is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGender.Focus();
                return false;
            }
            if (cmbstatus.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Status is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbstatus.Focus();
                return false;
            }
            if (txtFatherName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Father Name  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFatherName.Focus();
                return false;
            }
            if (txtmotherName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mother Name  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmotherName.Focus();
                return false;
            }

            if (txtPAddress.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Permanent Address is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPAddress.Focus();
                return false;
            }
            if (txtMobileNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mobile No. is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
                return false;
            }
            if (txtDateOfJoining.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Date Of Joining is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDateOfJoining.Focus();
                return false;
            }
            if (txt_Experiance.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Experiance is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Experiance.Focus();
                return false;
            }
          
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {

                if (txtStaffID.Text != "" || txtStaffName.Text != "" || txt_Department.Text != "" || cmbGender.Text != "" || cmbstatus.Text != "" || DOB.Text != "" || txtFatherName.Text != "" || txtmotherName.Text != "" || txtPAddress.Text != "" || txtTAddress.Text != "" || txtMobileNo.Text != "" || txt_Department.Text != "" || txtDateOfJoining.Text != "" || txt_Experiance.Text != "" || txtEmail.Text != "" || txtBasicSalary.Text != "" || txt_Designation.Text != "" || txtQualifications.Text != "" || pictureBox_EmployeImage.Image != null)
                {
                    cmd = new SqlCommand("insert into EmployeRegisterTable (EmpID,EmployeName,Gender,Status,DOB,FatherName,MotherName,ContactNo,PermanentAddress,TemporaryAddress,Department,DateOfJoining,Experience,Email,BasicSallary,Designation,Qualification,EmployeImage) values(@EmpID,@EmployeName,@Gender,@Status,@DOB,@FatherName,@MotherName,@ContactNo,@PermanentAddress,@TemporaryAddress,@Department,@DateOfJoining,@Experience,@Email,@BasicSallary,@Designation,@Qualification,@EmployeImage)", con);
                    con.Open();

                    byte[] image = null;
                    FileStream streem = new FileStream(imgLocation1, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(streem);
                    image = brs.ReadBytes((int)streem.Length);

                    cmd.Parameters.AddWithValue("@EmpID", txtStaffID.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmployeName", txtStaffName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", cmbstatus.Text.ToString());
                    cmd.Parameters.AddWithValue("@DOB", DOB.Text.Trim());
                    cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text.Trim());
                    cmd.Parameters.AddWithValue("@MotherName", txtmotherName.Text.ToString());
                    cmd.Parameters.AddWithValue("@ContactNo", txtMobileNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@PermanentAddress", txtPAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@TemporaryAddress", txtTAddress.Text.ToString());
                    cmd.Parameters.AddWithValue("@Department", txt_Department.Text.ToString());
                    cmd.Parameters.AddWithValue("@DateOfJoining", txtDateOfJoining.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txt_Experiance.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@BasicSallary", txtBasicSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@Designation", txt_Designation.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualifications.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmployeImage", image);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Save Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = true;
                    btnupdate.Enabled = true;
                    //Print.Enabled = true;
                    btnSave.Enabled = false;

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
         }

        private void Browse_Click(object sender, EventArgs e)
        {
             OpenFileDialog opendailog = new OpenFileDialog();
            opendailog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            if (opendailog.ShowDialog() == DialogResult.OK)
            {
                imgLocation1 = opendailog.FileName.ToString();
                pictureBox_EmployeImage.ImageLocation = imgLocation1;
              

            }
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Clear();
            Delete.Enabled = false;
            btnupdate.Enabled = false;
            btnSave.Enabled = true;
            Browse.Enabled = true;
            

            try
            {
                String query = "select * from EmployeRegisterTable";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    number_String = reader["EmpID"].ToString();

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
            number = Convert.ToInt32(number_String);
            value2 = number + 1;
            txtStaffID.Text = Convert.ToString(value2);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
             try
            {


                string compare = cmb_StaffID.Text;
                con.Open();
                SqlDataAdapter sqldata = new SqlDataAdapter("delete from EmployeRegisterTable where EmpID='" + compare + "'", con);
                sqldata.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Delete Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Missing!!");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
              try
            {
                string compare = cmb_StaffID.Text;

                if (txtStaffName.Text != "" || cmbGender.Text != "" || cmbstatus.Text != "" || DOB.Text != "" || txtFatherName.Text != "" || txtmotherName.Text != "" || txtMobileNo.Text != "" || txtPAddress.Text != "" || txtTAddress.Text != "" || txt_Department.Text != "" || txtDateOfJoining.Text != "" || txt_Experiance.Text != "" || txtEmail.Text != "" || txtBasicSalary.Text != "" || txt_Designation.Text != "" || txtQualifications.Text != "" || pictureBox_EmployeImage.Image != null)
                {

                    String query = "update EmployeRegisterTable set EmployeName=@EmployeName,Gender=@Gender,Status=@Status,DOB=@DOB,FatherName=@FatherName,MotherName=@MotherName,PermanentAddress=@PermanentAddress,TemporaryAddress=@TemporaryAddress,ContactNo=@ContactNo,Email=@Email,BasicSallary=@BasicSallary,Department=@Department,DateOfJoining=@DateOfJoining,Experience=@Experience,Designation=@Designation,Qualification=@Qualification where EmpID='" + compare + "'";

                    cmd = new SqlCommand(query, con);
                    con.Open();
                        cmd.Parameters.AddWithValue("@EmployeName", txtStaffName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Gender", cmbGender.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", cmbstatus.Text.ToString());
                        cmd.Parameters.AddWithValue("@DOB", DOB.Text.Trim());
                        cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text.Trim());
                        cmd.Parameters.AddWithValue("@MotherName", txtmotherName.Text.ToString());
                        cmd.Parameters.AddWithValue("@ContactNo", txtMobileNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@PermanentAddress", txtPAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@TemporaryAddress", txtTAddress.Text.ToString());
                        cmd.Parameters.AddWithValue("@Department", txt_Department.Text.ToString());
                        cmd.Parameters.AddWithValue("@DateOfJoining", txtDateOfJoining.Text.Trim());
                        cmd.Parameters.AddWithValue("@Experience", txt_Experiance.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@BasicSallary", txtBasicSalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@Designation", txt_Designation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Qualification", txtQualifications.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Update Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Delete.Enabled = true;
                        btnupdate.Enabled = true;
                        btnSave.Enabled = false;
                    }
                 else
                {
                    MessageBox.Show("Please Provide Details!");
                }
                
            }
               catch
           
            {
                MessageBox.Show("Somthing Missing!!");
            }
            
                
          con.Close();
        }

        private void cmb_StaffID_SelectedIndexChanged(object sender, EventArgs e)
        {
              try
            {

                string compare = cmb_StaffID.Text;
                Browse.Enabled = false;
                Delete.Enabled = true;
                btnupdate.Enabled = true;
                btnSave.Enabled = false;
               

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                 //SqlCommand cmd;

                string query = "select EmpID,EmployeName,Gender,Status,DOB,FatherName,MotherName,PermanentAddress,TemporaryAddress,ContactNo,Department,DateOfJoining,Experience,Email,BasicSallary,Designation,Qualification,EmployeImage from EmployeRegisterTable where EmpID='" + compare + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    txtStaffID.Text = reader["EmpID"].ToString();
                    txtStaffName.Text = reader["EmployeName"].ToString();
                    cmbGender.Text = reader["Gender"].ToString();
                    cmbstatus.Text = reader["Status"].ToString();
                     DOB.Text = reader["DOB"].ToString();
                     txtFatherName.Text = reader["FatherName"].ToString();
                     txtmotherName.Text = reader["MotherName"].ToString();
                     txtPAddress.Text = reader["PermanentAddress"].ToString();
                     txtTAddress.Text = reader["TemporaryAddress"].ToString();
                     txtMobileNo.Text = reader["ContactNo"].ToString();
                     txt_Department.Text = reader["Department"].ToString();
                     txtDateOfJoining.Text = reader["DateOfJoining"].ToString();
                     txt_Experiance.Text = reader["Experience"].ToString();
                     txtEmail.Text = reader["Email"].ToString();
                    txtBasicSalary.Text = reader["BasicSallary"].ToString();
                    txt_Designation.Text = reader["Designation"].ToString();
                    txtQualifications.Text = reader["Qualification"].ToString();

                    byte[] image = (byte[])(reader["EmployeImage"]);

                    if (image == null)
                    {
                        pictureBox_EmployeImage.Image = null;

                    }
                    else
                    {
                        MemoryStream ms1 = new MemoryStream(image);
                        pictureBox_EmployeImage.Image = Image.FromStream(ms1);

                    }

                }

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Not Found!!");
            }
        }
        
    }
}
