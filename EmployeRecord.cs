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
using Excel = Microsoft.Office.Interop.Excel;

namespace Inventory_Management_Project
{
    public partial class EmployeRecord_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public EmployeRecord_frm()
        {
            InitializeComponent();
        }

        private void EmployeRecord_frm_Load(object sender, EventArgs e)
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
                    cmbDepartmentname.SelectedItem = "Select";
                    cmbDepartmentname.Items.Add(reader["EmpID"].ToString());

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
                    CmbEmployeeName.SelectedItem = "Select";
                    CmbEmployeeName.Items.Add(reader["EmployeName"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
        }

        private void cmbDepartmentname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compare = cmbDepartmentname.Text;

            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from EmployeRegisterTable where EmpID='" + compare + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void CmbEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compare = CmbEmployeeName.Text;

            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from EmployeRegisterTable where EmployeName='" + compare + "'", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            string compare = txtEmployeeName.Text;

            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from EmployeRegisterTable where EmployeName='" + compare + "'", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbDepartmentname.Text = "";
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = null;
            cmbDepartmentname.Focus();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CmbEmployeeName.Text = "";
            txtEmployeeName.Text = "";
            dataGridView2.DataSource = "";
            dataGridView2.DataSource = null;
            CmbEmployeeName.Focus();
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from EmployeRegisterTable ", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
