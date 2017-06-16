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


namespace Inventory_Management_Project
{
    public partial class NewExciseInvoice_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
       
        private List<ExiceClass> shoppingcart = new List<ExiceClass>();
        public NewExciseInvoice_frm()
        {
            InitializeComponent();
        }

        private void btn_AddClient_Click(object sender, EventArgs e)
        {
            AddClient frm = new AddClient();
            frm.Show();
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            AddProduct_frm frm = new AddProduct_frm();
            frm.Show();
        }

        private void cmb_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = cmb_Client.Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                // SqlCommand cmd;

                string query = "select City,State,Phone,ShipCity  from AddClient where ClientName='" + compare + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    lbl_ShipCity.Text = reader["ShipCity"].ToString();
                    lbl_ClientCity.Text = reader["City"].ToString();
                    lbl_ClientState.Text = reader["State"].ToString();
                    lbl_PhoneNo.Text = reader["Phone"].ToString();

                }

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Not Found!!");
            }
        }

      

        private void checkBox_AddPayment_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_AddPayment.Checked)
            {
                cmb_PaymentType.Visible = true;
                txt_AmountPaid.Visible = true;
                txt_Notes.Visible = true;
                lbl_PayType.Visible = true;
                lbl_AmountPaid.Visible = true;
                lbl_Notes.Visible = true;
                txt_AmountDue.Visible = true;
                lbl_AmountDue.Visible = true;
            }

            else
            {
                cmb_PaymentType.Visible = false;
                txt_AmountPaid.Visible = false;
                txt_Notes.Visible = false;
                lbl_PayType.Visible = false;
                lbl_AmountPaid.Visible = false;
                lbl_Notes.Visible = false;
                txt_AmountDue.Visible = false;
                lbl_AmountDue.Visible = false;
            }
        }

        private void checkBox_SecondNum_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_SecondNum.Checked)
            {
                txt_SecondNum.Visible = true;
            }

            else
            {
                txt_SecondNum.Visible = false;  
            }
        }

        private void checkBox_CESS_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_CESS.Checked)
            {
                txt_Cess.Visible = true;
                lbl_ChessPercent.Visible = true;
            }

            else
            {
                txt_Cess.Visible = false;
                lbl_ChessPercent.Visible = false;
            }
        }

        int number = 0;
        int value2;
        string number_String;

        private void NewExciseInvoice_frm_Load(object sender, EventArgs e)
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
                    cmb_Client.SelectedItem = "Select";
                    cmb_Client.Items.Add(reader["ClientName"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();

            try
            {
                String query = "select * from Tax_Table10";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmb_Tax.SelectedItem = "Select";
                    cmb_Tax.Items.Add(reader["TaxPercentage"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();

            try
            {
                String query = "select * from AddProduct_Table2";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmb_ProductService.SelectedItem = "Select";
                    cmb_ProductService.Items.Add(reader["ProductName"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();

            try
            {
                String query = "select * from ExciseInvoice_Table7";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    number_String = reader["DocumentNo"].ToString();

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
            number = Convert.ToInt32(number_String);
            value2 = number + 1;
            txt_DocumentNum.Text = Convert.ToString(value2);
        }

        private void cmb_ProductService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = cmb_ProductService.Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                // SqlCommand cmd;

                string query = "select Description,UnitPrice,UoM,Taxes  from AddProduct_Table2 where ProductName='" + compare + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    txt_Description.Text = reader["Description"].ToString();
                    txt_UnitPrice.Text = reader["UnitPrice"].ToString();
                    cmb_UOM.Text = reader["UoM"].ToString();
                    cmb_Tax.Text = reader["Taxes"].ToString();

                }

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Not Found!!");
            }
        }

        decimal totalamount;
        ExiceClass cartitem;
        decimal tax;
        decimal excise;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int add = 0;
            int total = 1;
            cartitem = new ExiceClass()
            {
                ProductService = cmb_ProductService.Text,
                Description = txt_Description.Text.Trim(),
                UoM = cmb_UOM.Text,
                Quantity = Convert.ToInt32(txt_Qty.Text.Trim()),
                Unitprice = Convert.ToDecimal(txt_UnitPrice.Text.Trim()),
                Tax = Convert.ToDecimal(cmb_Tax.Text),
                TotalPrice = Convert.ToInt32(txt_Qty.Text.Trim()) * Convert.ToDecimal(txt_UnitPrice.Text.Trim()),
                ExiceDuty = Convert.ToDecimal(txt_ExciseDuty.Text.Trim()),

            };

            shoppingcart.Add(cartitem);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = shoppingcart;
            //productClassBindingSource1.Add(shoppingcart);
            totalamount = shoppingcart.Sum(x => x.TotalPrice);

            if (cmb_Tax.Items.Equals("0"))
            {
                tax = 0;
                lbl_SubtotalAns.Text = Convert.ToString(totalamount);
                lbl_rs.Text = Convert.ToString(tax + totalamount + excise);
                lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
                lbl_taxs.Text = Convert.ToString(tax);
              

            }
            else
            {
                decimal taxvalue = Convert.ToDecimal(cmb_Tax.Text);
                tax = ((totalamount * taxvalue) / 100);
                lbl_SubtotalAns.Text = Convert.ToString(totalamount);
                lbl_rs.Text = Convert.ToString(tax + totalamount + excise);
                lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
                lbl_taxs.Text = Convert.ToString(tax);
            }


            if (txt_ExciseDuty.Text.Equals("0"))
            {
                excise = 0;
                lbl_SubtotalAns.Text = Convert.ToString(totalamount);
                lbl_rs.Text = Convert.ToString(tax + totalamount+excise);
                lbl_Excise.Text = "ExiceDuty" + "(" + Convert.ToDecimal(txt_ExciseDuty.Text) + "%" + ")";
                lbl_Excise.Text = Convert.ToString(excise);


            }
            else
            {
                decimal excisevalue = Convert.ToDecimal(txt_ExciseDuty.Text);
                excise = ((totalamount * excisevalue) / 100);
                lbl_SubtotalAns.Text = Convert.ToString(totalamount);
                lbl_rs.Text = Convert.ToString(excise + totalamount + tax);
                lbl_Excise.Text = "ExiceDuty" + "(" + Convert.ToDecimal(txt_ExciseDuty.Text) + "%" + ")";
                lbl_Excise.Text = Convert.ToString(excise);
            }
           
            
            
        }

        private bool isvalidated()
        {
            if (cmb_Client.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Client Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Client.Focus();
                return false;
            }
            if (txt_PONumber.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PO Number is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PONumber.Focus();
                return false;
            }
            if (cmb_ProductService.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_ProductService.Focus();
                return false;
            }
            if (txt_Qty.Text.Trim() == string.Empty)
            {
                MessageBox.Show("QTY  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Qty.Focus();
                return false;
            }
            if (txt_AmountPaid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Amount Paid  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_AmountPaid.Focus();
                return false;
            }


            return true;
        }

        decimal Value3 = 0, Value4 = 0, Value5 = 0;
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                Value3 = Convert.ToDecimal(lbl_rs.Text);
                Value4 = Convert.ToDecimal(txt_AmountPaid.Text);

                Value5 = Value3 - Value4;
                txt_AmountDue.Text = Convert.ToString(Value5);

                if (cmb_Client.Text != "" || txt_DocumentNum.Text != "" || txt_PONumber.Text != "" || txt_SecondNum.Text != "" || dateTimePicker1.Text != "" || cmb_PaymentTerm.Text != "" || dateTimePicker2.Text != "" || cmb_ProductService.Text != "" || txt_Description.Text != "" || cmb_UOM.Text != "" || txt_Qty.Text != "" || txt_UnitPrice.Text != "" || cmb_Tax.Text != "" || txt_TotalDiscount.Text != "" || txt_AddShipCost.Text != "" || cmb_PaymentType.Text != "" || txt_AmountPaid.Text != "" || txt_Notes.Text != "" || txt_NoteforClient.Text != "" || txt_PrivateNote.Text != "" || lbl_SubtotalAns.Text != "" || lbl_rs.Text != "" || txt_AmountDue.Text != "")
                {

                    cmd = new SqlCommand("insert into ExciseInvoice_Table7(DocumentNo,ClientName,PONumber,SecondNumber,IssueDate,PaymentTerm,DueDate,ProductName,Description,UOM,QTY,UnitPrice,Tax,TotalDiscount,ShippingCost,PaymentType,AmountPaid,Notes,NFC,PrivateNote,ExciseDuty,Cess,SubTotal,TotalAmount,AmountDue) values(@DocumentNo,@ClientName,@PONumber,@SecondNumber,@IssueDate,@PaymentTerm,@DueDate,@ProductName,@Description,@UOM,@QTY,@UnitPrice,@Tax,@TotalDiscount,@ShippingCost,@PaymentType,@AmountPaid,@Notes,@NFC,@PrivateNote,@ExciseDuty,@Cess,@SubTotal,@TotalAmount,@AmountDue)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@DocumentNo", txt_DocumentNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClientName", cmb_Client.Text.Trim());
                    cmd.Parameters.AddWithValue("@PONumber", txt_PONumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@SecondNumber", txt_SecondNum.Text.ToString());
                    cmd.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Text.Trim());
                    cmd.Parameters.AddWithValue("@PaymentTerm", cmb_PaymentTerm.Text.Trim());
                    cmd.Parameters.AddWithValue("@DueDate", dateTimePicker2.Text.ToString());
                    cmd.Parameters.AddWithValue("@ProductName", cmb_ProductService.Text.ToString());
                    cmd.Parameters.AddWithValue("@Description", txt_Description.Text.ToString());
                    cmd.Parameters.AddWithValue("@UOM", cmb_UOM.Text.ToString());
                    cmd.Parameters.AddWithValue("@QTY", txt_Qty.Text.ToString());
                    cmd.Parameters.AddWithValue("@UnitPrice", txt_UnitPrice.Text.ToString());
                    cmd.Parameters.AddWithValue("@Tax", cmb_Tax.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalDiscount", txt_TotalDiscount.Text.ToString());
                    cmd.Parameters.AddWithValue("@ShippingCost", txt_AddShipCost.Text.ToString());
                    cmd.Parameters.AddWithValue("@PaymentType", cmb_PaymentType.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountPaid", txt_AmountPaid.Text.ToString());
                    cmd.Parameters.AddWithValue("@Notes", txt_Notes.Text.ToString());
                    cmd.Parameters.AddWithValue("@NFC", txt_NoteforClient.Text.ToString());
                    cmd.Parameters.AddWithValue("@PrivateNote", txt_PrivateNote.Text.ToString());
                    cmd.Parameters.AddWithValue("@ExciseDuty", txt_ExciseDuty.Text.ToString());
                    cmd.Parameters.AddWithValue("@SubTotal", lbl_SubtotalAns.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalAmount", lbl_rs.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountDue", txt_AmountDue.Text.ToString());
                    cmd.Parameters.AddWithValue("@Cess", txt_Cess.Text.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Save Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clear();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            save();
        }

        public void save()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert_ExciseProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                string productname = row.Cells[0].Value.ToString();
                string description = row.Cells[1].Value.ToString();
                string UOM = row.Cells[2].Value.ToString();
                int QTY = Convert.ToInt32(row.Cells[3].Value.ToString());
                decimal price = Convert.ToDecimal(row.Cells[4].Value.ToString());
                decimal tax = Convert.ToDecimal(row.Cells[5].Value.ToString());
                decimal excise = Convert.ToDecimal(row.Cells[6].Value.ToString());

                cmd.Parameters.AddWithValue("@InvoiceNo", txt_DocumentNum.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductName", productname);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@UOM", UOM);
                cmd.Parameters.AddWithValue("@QTY", QTY);
                cmd.Parameters.AddWithValue("@UnitPrice", price);
                cmd.Parameters.AddWithValue("@Tax", tax);
                cmd.Parameters.AddWithValue("@ExciseDuty", excise);

                cmd.ExecuteNonQuery();

                con.Close();

            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Want to RESET??",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            cmb_ProductService.Text = "";
            dataGridView1.DataMember = null;
            cmb_ProductService.Focus();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name=="Delet")
            {
                if(MessageBox.Show("You Want to Delete this Record?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    exiceClassBindingSource.RemoveCurrent();
                }
            }
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            ExciseInvoicePrint_frm frm = new ExciseInvoicePrint_frm();
            frm.Show();
        }

        private void btn_AddDis_Click(object sender, EventArgs e)
        {
            decimal disa, value, cal;
            disa = Convert.ToDecimal(txt_TotalDiscount.Text);
            value = Convert.ToDecimal(lbl_rs.Text);
            DialogResult dailog = MessageBox.Show("Are Sure Want to Add" + " " + disa + "%" + " " + " Discount in TotalAmount ?", "Exit", MessageBoxButtons.YesNo);
            if (dailog == DialogResult.Yes)
            {

                cal = (value * disa) / 100;
                lbl_rs.Text = Convert.ToString(value - cal);
                lbl_discounts.Text = Convert.ToString(disa) + "%";

            }
            else if (dailog == DialogResult.No)
            {

            }

            txt_TotalDiscount.Text = "";
            btn_AddDis.Enabled = false;

        }

        private void btn_AddShipCost_Click(object sender, EventArgs e)
        {
            decimal totalamountshipping, totalamountrs, AddShiping;
            totalamountshipping = Convert.ToDecimal(txt_AddShipCost.Text);
            totalamountrs = Convert.ToDecimal(lbl_rs.Text);
            DialogResult dailog = MessageBox.Show("Are Sure Want to Add" + " " + totalamountshipping + "Rs" + "" + "ShippingCharg in TotalAmount ?", "Exit", MessageBoxButtons.YesNo);
            if (dailog == DialogResult.Yes)
            {

                AddShiping = (totalamountrs + totalamountshipping);
                lbl_rs.Text = Convert.ToString(AddShiping);
                lbl_shipping.Text = Convert.ToString(totalamountshipping);

            }
            else if (dailog == DialogResult.No)
            {

            }

            txt_AddShipCost.Text = "";
            btn_AddShipCost.Enabled = false;
        }

        private void txt_DocumentNum_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_ExciseDuty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_TotalDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_AddShipCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_AmountPaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_TotalDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txt_TotalDiscount.Text == "")
            {
                btn_AddDis.Enabled = false;
            }
            else
            {
                btn_AddDis.Enabled = true;
            }
        }

        private void txt_AddShipCost_TextChanged(object sender, EventArgs e)
        {
            if (txt_AddShipCost.Text == "")
            {
                btn_AddShipCost.Enabled = false;
            }
            else
            {
                btn_AddShipCost.Enabled = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            shoppingcart.RemoveAt(index);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = shoppingcart;

            decimal totalamount = shoppingcart.Sum(x => x.TotalPrice);
            decimal taxvalue = shoppingcart.Sum(x => x.Tax);
            decimal excisevalue = shoppingcart.Sum(x => x.ExiceDuty);
            lbl_SubtotalAns.Text = totalamount.ToString();
            lbl_taxs.Text = tax.ToString();
            tax = ((totalamount * taxvalue) / 100);
            lbl_Excise.Text = excise.ToString();
            excise = ((totalamount * excisevalue) / 100);
            lbl_rs.Text = Convert.ToString(totalamount + tax + excise);
            lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
            lbl_taxs.Text = Convert.ToString(tax);
            lbl_Excise.Text = Convert.ToString(excise);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
            }
        }
    }
}
