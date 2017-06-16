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
using System.Text.RegularExpressions;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;



namespace Inventory_Management_Project
{
    public partial class InvoiceReport_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public InvoiceReport_frm()
        {
            InitializeComponent();
        }

        private void btn_NewInvoice_Click(object sender, EventArgs e)
        {
            Invoice_frm frm = new Invoice_frm();
            frm.Show();
        }

        private void InvoiceReport_frm_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from AddClient";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmb_ClientName.SelectedItem = "Select";
                    cmb_ClientName.Items.Add(reader["ClientName"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
        }

        private void btn_Search_Click(object sender, EventArgs e)  
        {
            string compare = txt_ClientName.Text;
            string compare1 = txt_InvoiceNumber.Text;
           

            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from Invoice_Table4 where ClientName='" + compare + "' and DocumentNo='" + compare1 + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void cmb_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compare = cmb_ClientName.Text;
           
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from Invoice_Table4 where ClientName='" + compare + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Want to RESET??", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txt_ClientName.Text = "";
            dataGridView1.DataSource = null;
            txt_InvoiceNumber.Text = "";
            txt_City.Text = "";
           
        }

        private void btn_Export_Click(object sender, EventArgs e)
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                // this.Hide();
                InvoiceReport_frm frm = new InvoiceReport_frm();
                // or simply use column name instead of index
                //dr.Cells["SubjectCode"].Value.ToString();
                //frm.Show();

                txt_Client_Name.Text = dr.Cells[1].Value.ToString();
                txt_Invoice_No.Text = dr.Cells[0].Value.ToString();
                cmb_Payment.Text = dr.Cells[15].Value.ToString();
                txt_Total_Amount.Text = dr.Cells[20].Value.ToString();
               value4 =Convert.ToDecimal (dr.Cells[16].Value.ToString());
                txt_Amount_Due.Text = dr.Cells[22].Value.ToString();
               
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        decimal value1 = 0, value2 = 0, value3 = 0, value4 = 0, value5 = 0;
        private void btn_Pay_Click(object sender, EventArgs e)
        {
           
            value1 = Convert.ToDecimal(txt_Amount_Due.Text);
            value2 = Convert.ToDecimal(txt_Amount_Paid.Text);
            lbl_Paid.Text = Convert.ToString(value4); 
            if (value1 < value2)
            {
                MessageBox.Show("Amount Paid is morethen Total Amount, Please Enter a Valid Amount!!", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                   
                    
                    string compare = txt_Invoice_No.Text;

                    value3 = (value1 - value2);
                    value5 = value4 + value2;
                    //value6 = value1 - value5;

                    txt_Amount_Due.Text = Convert.ToString(value3);
                    lbl_Paid.Text = Convert.ToString(value5); 

                    if (cmb_Payment.Text != "" || txt_Amount_Due.Text != "")
                    {
                        String query = "update Invoice_Table4 set PaymentType=@PaymentType,AmountPaid=@AmountPaid,AmountDue=@AmountDue where DocumentNo='" + compare + "'";

                        cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@PaymentType", cmb_Payment.Text.Trim());
                        cmd.Parameters.AddWithValue("@AmountPaid", value5);
                        cmd.Parameters.AddWithValue("@AmountDue", value3);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
              
                //gridview();
                con.Close();
            }

            refresh();
            btn_Pay.Enabled = false;
        }

        private void btn_ShowData_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            //con.Open();

            //string FromDate = txt_IssueDate1.Text;
            //string ToDate = txt_IssueDate2.Text;
            //SqlCommand cmd = new SqlCommand("Select IssueDate=@IssueDate from Invoice_Table4 where IssueDate", con);

            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    con.Close();
          

            //}
         
        }

        public void gridview()
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);

            con.Open();
            Reset();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from Invoice_Table4 ", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void Reset()
        {
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvoicePrint_frm frm = new InvoicePrint_frm();
            frm.Show();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    this.dataGridView1.Rows[e.RowIndex].Selected = true;
            //    this.rowIndex = e.RowIndex;
            //    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
            //    this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
            //    contextMenuStrip1.Show(Cursor.Position);
            //}
        }

        private void txt_ClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 95 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter Only Character");
                e.Handled = true;
            } 
        }

        private void txt_City_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 95 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter Only Character");
                e.Handled = true;
            } 
        }

        private void txt_InvoiceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;

            }

            else
            {

                MessageBox.Show("Please Enter Only Number!!");
                e.Handled = true;
            }
        }

        private void txt_Amount_Paid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;

            }

            else
            {

                MessageBox.Show("Please Enter Only Number!!");
                e.Handled = true;
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridViewRow dr = dataGridView1.SelectedRows[0];
            //    // this.Hide();
            //    InvoiceReport_frm frm = new InvoiceReport_frm();
            //    // or simply use column name instead of index
            //    //dr.Cells["SubjectCode"].Value.ToString();
            //    //frm.Show();

            //    txt_Client_Name.Text = dr.Cells[1].Value.ToString();
            //    txt_Invoice_No.Text = dr.Cells[0].Value.ToString();
            //    cmb_Payment.Text = dr.Cells[15].Value.ToString();
            //    txt_Total_Amount.Text = dr.Cells[20].Value.ToString();
            //    value4 = Convert.ToDecimal(dr.Cells[16].Value.ToString());
            //    txt_Amount_Due.Text = dr.Cells[22].Value.ToString();

            //}


            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    DataGridViewRow dr = dataGridView1.SelectedRows[0];
            //    // this.Hide();
            //    InvoiceReport_frm frm = new InvoiceReport_frm();
            //    // or simply use column name instead of index
            //    //dr.Cells["SubjectCode"].Value.ToString();
            //    //frm.Show();

            //    txt_Client_Name.Text = dr.Cells[1].Value.ToString();
            //    txt_Invoice_No.Text = dr.Cells[0].Value.ToString();
            //    cmb_Payment.Text = dr.Cells[15].Value.ToString();
            //    txt_Total_Amount.Text = dr.Cells[20].Value.ToString();
            //    value4 = Convert.ToDecimal(dr.Cells[16].Value.ToString());
            //    txt_Amount_Due.Text = dr.Cells[22].Value.ToString();

            //}


            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txt_Amount_Paid_TextChanged(object sender, EventArgs e)
        {
            if (txt_Amount_Paid.Text == "")
            {
                btn_Pay.Enabled = false;
            }
            else
            {
                btn_Pay.Enabled = true;
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            cmb_Payment.Text = "";
            txt_Amount_Paid.Text = "";
            lbl_Paid.Text = "";
            dataGridView1.DataSource = null;

        }

        private void refresh()
        {
            this.Refresh();
            cmb_Payment.Text = "";
            txt_Amount_Paid.Text = "";
            lbl_Paid.Text = "";
            dataGridView1.DataSource = null;
        }
    
    
    }
}
