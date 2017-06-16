﻿using System;
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
    public partial class NewDeliveryNote_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        private List<ProductClass> shoppingcart = new List<ProductClass>();
        public NewDeliveryNote_frm()
        {
            InitializeComponent();
        }


        int number = 0;
        int value2;
        string number_String;

        private void NewDeliveryNote_frm_Load(object sender, EventArgs e)
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
                String query = "select * from DeliveryNote_Table";

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
            txt_DocNumber.Text = Convert.ToString(value2);
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

        private void cmb_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = cmb_ClientName.Text;

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


        public void save()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert_DeliveryProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                string productname = row.Cells[0].Value.ToString();
                string description = row.Cells[1].Value.ToString();
                string UOM = row.Cells[2].Value.ToString();
                int QTY = Convert.ToInt32(row.Cells[3].Value.ToString());
                decimal price = Convert.ToDecimal(row.Cells[4].Value.ToString());
                decimal tax = Convert.ToDecimal(row.Cells[5].Value.ToString());

                cmd.Parameters.AddWithValue("@InvoiceNo", txt_DocNumber.Text.Trim());
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
                lbl_rs.Text = Convert.ToString(tax + totalamount);
                lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
                lbl_taxs.Text = Convert.ToString(tax);
            }
            else
            {
                decimal taxvalue = Convert.ToDecimal(cmb_Tax.Text);
                tax = ((totalamount * taxvalue) / 100);
                lbl_SubtotalAns.Text = Convert.ToString(totalamount);
                lbl_rs.Text = Convert.ToString(tax + totalamount);
                lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
                lbl_taxs.Text = Convert.ToString(tax);
            }
           
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Want to RESET??",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            cmb_ProductName.Text = "";
            dataGridView1.DataSource = null;
            cmb_ProductName.Focus();
            lbl_rs.Text = "";
            lbl_SubtotalAns.Text = "";
            lbl_taxs.Text = "";
            shoppingcart = null;
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txt_TotalDisc.Visible = true;
                lbl_Percentage.Visible = true;

            }

            else
            {
                txt_TotalDisc.Visible = false;
                lbl_Percentage.Visible = false;

            }
        }

        private void checkBox_AddShipCost_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_AddShipCost.Checked)
            {
                txt_AddShipCost.Visible = true;
                lbl_rupes.Visible = true;

            }

            else
            {
                txt_AddShipCost.Visible = false;
                lbl_rupes.Visible = false;

            }
        }

        private bool isvalidated()
        {
            if (cmb_ClientName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Client Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_ClientName.Focus();
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
                MessageBox.Show("Paid Amount  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_AmountPaid.Focus();
                return false;
            }
            
            return true;
        }


        decimal Value3=0, Value4=0, Value5=0;
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                Value3 = Convert.ToDecimal(lbl_rs.Text);
                Value4 = Convert.ToDecimal(txt_AmountPaid.Text);

                Value5 = Value3 - Value4;
                txt_AmountDue.Text = Convert.ToString(Value5);

                if (cmb_ClientName.Text != "" || txt_DocNumber.Text != "" || txt_PONumber.Text != "" || dateTimePicker1.Text != "" || dateTimePicker2.Text != "" || cmb_ProductName.Text != "" || txt_Description.Text != "" || cmb_UOM.Text != "" || txt_QTY.Text != "" || txt_UnitPrice.Text != "" || cmb_Tax.Text != "" || txt_TotalDisc.Text != "" || txt_AddShipCost.Text != "" || txt_NFC.Text != "" || txt_PrivateNote.Text != "" || lbl_SubtotalAns.Text != "" || lbl_rs.Text != "" || txt_AmountPaid.Text != "" || txt_AmountDue.Text != "")
                {

                    cmd = new SqlCommand("insert into DeliveryNote_Table(DocumentNo,ClientName,PONumber,IssueDate,ShippingDate,ProductName,Description,UOM,QTY,UnitPrice,Tax,TotalDiscount,ShippingCost,AmountPaid,NFC,PrivateNote,TotalAmount,SubTotal,AmountDue) values(@DocumentNo,@ClientName,@PONumber,@IssueDate,@ShippingDate,@ProductName,@Description,@UOM,@QTY,@UnitPrice,@Tax,@TotalDiscount,@ShippingCost,@AmountPaid,@NFC,@PrivateNote,@TotalAmount,@SubTotal,@AmountDue)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@DocumentNo", txt_DocNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClientName", cmb_ClientName.Text.Trim());
                    cmd.Parameters.AddWithValue("@PONumber", txt_PONumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShippingDate", dateTimePicker2.Text.Trim());
                    cmd.Parameters.AddWithValue("@ProductName", cmb_ProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txt_Description.Text.ToString());
                    cmd.Parameters.AddWithValue("@Tax", cmb_Tax.Text.ToString());
                    cmd.Parameters.AddWithValue("@UOM", cmb_UOM.Text.ToString());
                    cmd.Parameters.AddWithValue("@QTY", txt_QTY.Text.ToString());
                    cmd.Parameters.AddWithValue("@UnitPrice", txt_UnitPrice.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalDiscount", txt_TotalDisc.Text.ToString());
                    cmd.Parameters.AddWithValue("@ShippingCost", txt_AddShipCost.Text.ToString());
                    cmd.Parameters.AddWithValue("@NFC", txt_NFC.Text.ToString());
                    cmd.Parameters.AddWithValue("@PrivateNote", txt_PrivateNote.Text.ToString());
                    cmd.Parameters.AddWithValue("@SubTotal", lbl_SubtotalAns.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalAmount", lbl_rs.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountPaid", txt_AmountPaid.Text.ToString());
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

        private void btn_AddDis_Click(object sender, EventArgs e)
        {
            decimal disa, value, cal;
            disa = Convert.ToDecimal(txt_TotalDisc.Text);
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

            txt_TotalDisc.Text = "";
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

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            DeliveryPrint frm = new DeliveryPrint();
            frm.Show();
        }

        private void txt_DocNumber_KeyPress(object sender, KeyPressEventArgs e)
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
            lbl_SubtotalAns.Text = totalamount.ToString();
            lbl_taxs.Text = tax.ToString();
            tax = ((totalamount * taxvalue) / 100);
            lbl_rs.Text = Convert.ToString(totalamount + tax);
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}