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
    public partial class NewProformaInvoice_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
       
        private List<ProductClass> shoppingcart = new List<ProductClass>();
        public NewProformaInvoice_frm()
        {
            InitializeComponent();
        }

        int number = 0;
        int value2;
        string number_String;

        private void NewProformaInvoice_frm_Load(object sender, EventArgs e)
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
                    cmb_ProductName.SelectedItem = "Select";
                    cmb_ProductName.Items.Add(reader["ProductName"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();

            try
            {
                String query = "select * from ProformaInvoice_Table8";

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
            txt_DocumentNo.Text = Convert.ToString(value2);
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
                    lbl_City.Text = reader["City"].ToString();
                    lbl_State.Text = reader["State"].ToString();
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
                cmb_PayType.Visible = true;
                txt_AmountPaid.Visible = true;
                txt_Notes.Visible = true;
                lbl_PaymentType.Visible = true;
                lbl_AmountPaid.Visible = true;
                lbl_Notes.Visible = true;
                lbl_AmountDue.Visible = true;
                txt_AmountDue.Visible = true;
            }

            else
            {
                cmb_PayType.Visible = false;
                txt_AmountPaid.Visible = false;
                txt_Notes.Visible = false;
                lbl_PaymentType.Visible = false;
                lbl_AmountPaid.Visible = false;
                lbl_Notes.Visible = false;
                lbl_AmountDue.Visible = false;
                txt_AmountDue.Visible = false;
            }
        }

        private void checkBox_TotalDisc_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_TotalDisc.Checked)
            {
                txt_TotalDisc.Visible = true;
                lbl_TotalPerc.Visible = true;
              
            }

            else
            {
                txt_TotalDisc.Visible = false;
                lbl_TotalPerc.Visible = false;
              
            }
        }

        private void checkBox_ShipCost_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_ShipCost.Checked)
            {
                txt_ShipCost.Visible = true;
                lbl_Rs.Visible = true;

            }

            else
            {
                txt_ShipCost.Visible = false;
                lbl_Rs.Visible = false;

            }
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

        private void cmb_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = cmb_ProductName.Text;

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

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Want to RESET??", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            cmb_ProductName.Text = "";
            dataGridView1.DataMember = null;
            cmb_ProductName.Focus();
            shoppingcart = null;
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
            if (cmb_ProductName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_ProductName.Focus();
                return false;
            }
            if (txt_QTY.Text.Trim() == string.Empty)
            {
                MessageBox.Show("QTY  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_QTY.Focus();
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

        public void save()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert_ProformaProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                string productname = row.Cells[0].Value.ToString();
                string description = row.Cells[1].Value.ToString();
                string UOM = row.Cells[2].Value.ToString();
                int QTY = Convert.ToInt32(row.Cells[3].Value.ToString());
                decimal price = Convert.ToDecimal(row.Cells[4].Value.ToString());
                decimal tax = Convert.ToDecimal(row.Cells[5].Value.ToString());

                cmd.Parameters.AddWithValue("@InvoiceNo", txt_DocumentNo.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductName", productname);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@UOM", UOM);
                cmd.Parameters.AddWithValue("@QTY", QTY);
                cmd.Parameters.AddWithValue("@UnitPrice", price);
                cmd.Parameters.AddWithValue("@Tax", tax);

                cmd.ExecuteNonQuery();

                con.Close();

            }
        }

        decimal Value3=0, Value4=0, Value5=0;
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {

                Value3 = Convert.ToDecimal(lbl_rs1.Text);
                Value4 = Convert.ToDecimal(txt_AmountPaid.Text);
                Value5 = Value3 - Value4;
                txt_AmountDue.Text = Convert.ToString(Value5);

                if (cmb_Client.Text != "" || txt_DocumentNo.Text != "" || txt_PONumber.Text != "" || dateTimePicker1.Text != "" || dateTimePicker2.Text != "" || cmb_ProductName.Text != "" || txt_Description.Text != "" || cmb_UOM.Text != "" || txt_QTY.Text != "" || txt_UnitPrice.Text != "" || cmb_Tax.Text != "" || txt_TotalDisc.Text != "" || txt_ShipCost.Text != "" || cmb_PayType.Text != "" || txt_AmountPaid.Text != "" || txt_Notes.Text != "" || txt_NFC.Text != "" || txt_PrivateNote.Text != "" || lbl_SubtotalAns.Text != "" || lbl_rs1.Text != "" || txt_AmountDue.Text !="")
                {

                    cmd = new SqlCommand("insert into ProformaInvoice_Table8(DocumentNo,ClientName,PONumber,IssueDate,ValidDate,ProductName,Description,UOM,QTY,UnitPrice,Tax,TotalDiscount,ShippingCost,PaymentType,AmountPaid,Notes,NFC,PrivateNote,TotalAmount,SubTotal,AmountDue) values(@DocumentNo,@ClientName,@PONumber,@IssueDate,@ValidDate,@ProductName,@Description,@UOM,@QTY,@UnitPrice,@Tax,@TotalDiscount,@ShippingCost,@PaymentType,@AmountPaid,@Notes,@NFC,@PrivateNote,@TotalAmount,@SubTotal,@AmountDue)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@DocumentNo", txt_DocumentNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClientName", cmb_Client.Text.Trim());
                    cmd.Parameters.AddWithValue("@PONumber", txt_PONumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Text.Trim());
                    cmd.Parameters.AddWithValue("@ValidDate", dateTimePicker2.Text.ToString());
                    cmd.Parameters.AddWithValue("@ProductName", cmb_ProductName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Description", txt_Description.Text.ToString());
                    cmd.Parameters.AddWithValue("@UOM", cmb_UOM.Text.ToString());
                    cmd.Parameters.AddWithValue("@QTY", txt_QTY.Text.ToString());
                    cmd.Parameters.AddWithValue("@UnitPrice", txt_UnitPrice.Text.ToString());
                    cmd.Parameters.AddWithValue("@Tax", cmb_Tax.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalDiscount", txt_TotalDisc.Text.ToString());
                    cmd.Parameters.AddWithValue("@ShippingCost", txt_ShipCost.Text.ToString());
                    cmd.Parameters.AddWithValue("@PaymentType", cmb_PayType.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountPaid", txt_AmountPaid.Text.ToString());
                    cmd.Parameters.AddWithValue("@Notes", txt_Notes.Text.ToString());
                    cmd.Parameters.AddWithValue("@NFC", txt_NFC.Text.ToString());
                    cmd.Parameters.AddWithValue("@PrivateNote", txt_PrivateNote.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalAmount", lbl_rs1.Text.ToString());
                    cmd.Parameters.AddWithValue("@SubTotal", lbl_SubtotalAns.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountDue", txt_AmountDue.Text.ToString());


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

        decimal totalamount;
        ProductClass cartitem;
        decimal tax;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int add = 0;
            int total = 1;
            cartitem = new ProductClass()
            {
                ProductService = cmb_ProductName.Text,
                Description = txt_Description.Text.Trim(),
                UoM = cmb_UOM.Text,
                Quantity = Convert.ToInt32(txt_QTY.Text.Trim()),
                Unitprice = Convert.ToDecimal(txt_UnitPrice.Text.Trim()),
                Tax = Convert.ToDecimal(cmb_Tax.Text),
                TotalPrice = Convert.ToInt32(txt_QTY.Text.Trim()) * Convert.ToDecimal(txt_UnitPrice.Text.Trim())

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
                lbl_rs1.Text = Convert.ToString(tax + totalamount);
                lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
                lbl_taxs.Text = Convert.ToString(tax);
            }
            else
            {
                decimal taxvalue = Convert.ToDecimal(cmb_Tax.Text);
                tax = ((totalamount * taxvalue) / 100);
                lbl_SubtotalAns.Text = Convert.ToString(totalamount);
                lbl_rs1.Text = Convert.ToString(tax + totalamount);
                lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
                lbl_taxs.Text = Convert.ToString(tax);
            }
          
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            ProformaPrint frm = new ProformaPrint();
            frm.Show();
        }

        private void btn_AddDis_Click(object sender, EventArgs e)
        {
            decimal disa, value, cal;
            disa = Convert.ToDecimal(txt_TotalDisc.Text);
            value = Convert.ToDecimal(lbl_rs1.Text);
            DialogResult dailog = MessageBox.Show("Are Sure Want to Add" + " " + disa + "%" + " " + " Discount in TotalAmount ?", "Exit", MessageBoxButtons.YesNo);
            if (dailog == DialogResult.Yes)
            {

                cal = (value * disa) / 100;
                lbl_rs1.Text = Convert.ToString(value - cal);
                lbl_discounts.Text = Convert.ToString(disa) + "%";

            }
            else if (dailog == DialogResult.No)
            {

            }

            txt_TotalDisc.Text = "";
            btn_AddDis.Enabled = false;
        }

        private void btn_AddShipCost_Click(object sender, EventArgs e)
        {
            decimal totalamountshipping, totalamountrs, AddShiping;
            totalamountshipping = Convert.ToDecimal(txt_ShipCost.Text);
            totalamountrs = Convert.ToDecimal(lbl_rs1.Text);
            DialogResult dailog = MessageBox.Show("Are Sure Want to Add" + " " + totalamountshipping + "Rs" + "" + "ShippingCharg in TotalAmount ?", "Exit", MessageBoxButtons.YesNo);
            if (dailog == DialogResult.Yes)
            {

                AddShiping = (totalamountrs + totalamountshipping);
                lbl_rs1.Text = Convert.ToString(AddShiping);
                lbl_shipping.Text = Convert.ToString(totalamountshipping);

            }
            else if (dailog == DialogResult.No)
            {

            }

            txt_ShipCost.Text = "";
            btn_AddShipCost.Enabled = false;
        }

        private void txt_DocumentNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = txt_DocumentNo.Text;


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                // SqlCommand cmd;

                string query = "select ClientName,PONumber,ProductName,TotalDiscount,ShippingCost,PaymentType,Notes,AmountPaid,AmountDue,SubTotal,TotalAmount  from ProformaInvoice_Table8 where DocumentNo='" + compare + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cmb_Client.Text = reader["ClientName"].ToString();
                    txt_PONumber.Text = reader["PONumber"].ToString();
                    //dateTimePicker1.Text = reader["IssueDate"].ToString();
                    //dateTimePicker2.Text = reader["DueDate"].ToString();
                    cmb_ProductName.Text = reader["ProductName"].ToString();
                    txt_TotalDisc.Text = reader["TotalDiscount"].ToString();
                    txt_ShipCost.Text = reader["ShippingCost"].ToString();
                    cmb_PayType.Text = reader["PaymentType"].ToString();
                    txt_Notes.Text = reader["Notes"].ToString();
                    txt_AmountPaid.Text = reader["AmountPaid"].ToString();
                    txt_AmountDue.Text = reader["AmountDue"].ToString();
                    lbl_SubtotalAns.Text = reader["SubTotal"].ToString();
                    lbl_rs1.Text = reader["TotalAmount"].ToString();

                }

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Not Found!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string compare = txt_DocumentNo.Text;



                if (cmb_Client.Text != "" || txt_TotalDisc.Text != "" || txt_ShipCost.Text != "" || cmb_PayType.Text != "" || txt_Notes.Text != "" || txt_AmountPaid.Text != "" || txt_AmountDue.Text != "" || lbl_rs1.Text != "")
                {

                    String query = "update ProformaInvoice_Table8 set ClientName=@ClientName,TotalDiscount=@TotalDiscount,ShippingCost=@ShippingCost,PaymentType=@PaymentType,Notes=@Notes,AmountPaid=@AmountPaid,AmountDue=@AmountDue,TotalAmount=@TotalAmount where DocumentNo='" + compare + "'";

                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ClientName", cmb_Client.Text.Trim());
                    cmd.Parameters.AddWithValue("@TotalDiscount", txt_TotalDisc.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShippingCost", txt_ShipCost.Text.ToString());
                    cmd.Parameters.AddWithValue("@PaymentType", cmb_PayType.Text.Trim());
                    cmd.Parameters.AddWithValue("@Notes", txt_Notes.Text.Trim());
                    cmd.Parameters.AddWithValue("@AmountPaid", txt_AmountPaid.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountDue", txt_AmountDue.Text.Trim());
                    cmd.Parameters.AddWithValue("@TotalAmount", lbl_rs1.Text.Trim());



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Update Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {


                string compare = txt_DocumentNo.Text;
                con.Open();
                SqlDataAdapter sqldata = new SqlDataAdapter("delete from ProformaInvoice_Table8  where DocumentNo='" + compare + "'", con);
                sqldata.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Delete Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Missing!!");
            }
        }

        private void txt_DocumentNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_QTY_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_TotalDisc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_ShipCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_TotalDisc_TextChanged(object sender, EventArgs e)
        {
            if (txt_TotalDisc.Text == "")
            {
                btn_AddDis.Enabled = false;
            }
            else
            {
                btn_AddDis.Enabled = true;
            }
        }

        private void txt_ShipCost_TextChanged(object sender, EventArgs e)
        {
            if (txt_ShipCost.Text == "")
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
            lbl_SubtotalAns.Text = totalamount.ToString();
            lbl_taxs.Text = tax.ToString();
            tax = ((totalamount * taxvalue) / 100);
            lbl_rs1.Text = Convert.ToString(totalamount + tax);
            lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
            lbl_taxs.Text = Convert.ToString(tax);
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
