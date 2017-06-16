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
using System.Data.SqlServerCe;

namespace Inventory_Management_Project
{
    public partial class Invoice_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
    
        private List<ProductClass> shoppingcart = new List<ProductClass>();
        public Invoice_frm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

                    lbl_ShipDis.Text = reader["ShipCity"].ToString();
                    lbl_ClientDis.Text = reader["City"].ToString();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

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

        private void checkBox_AddPayment_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_AddPayment.Checked)
            {
                cmb_PayType.Visible = true;
                txt_AmountPaid.Visible = true;
                txt_Notes.Visible = true;
                lbl_PayType.Visible = true;
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
                lbl_PayType.Visible = false;
                lbl_AmountPaid.Visible = false;
                lbl_Notes.Visible = false;
                lbl_AmountDue.Visible = false;
                txt_AmountDue.Visible = false;
            }
        }

        int number = 0;
        int value2;
        string number_String;

        private void Invoice_frm_Load(object sender, EventArgs e)
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
                String query = "select * from Invoice_Table4";

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
            productClassBindingSource1.DataSource=new List<ProductClass>();
            con.Close();
            number = Convert.ToInt32(number_String);
            value2 = number + 1;
            txt_DocumentNum.Text = Convert.ToString(value2);
        }

        private void checkBox_SecondNum_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_SecondNum.Checked)
            {
                txt_SecondNumber.Visible = true;
            }

            else
            {
                txt_SecondNumber.Visible = false;
            }
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

                if (cmb_Client.Text != "" || txt_DocumentNum.Text != "" || txt_PONumber.Text != "" || txt_SecondNumber.Text != "" || dateTimePicker1.Text != "" || cmb_PaymentTerm.Text != "" || dateTimePicker2.Text != "" || cmb_ProductService.Text != "" || txt_Description.Text != "" || cmb_UOM.Text != "" || txt_QTY.Text != "" || txt_UnitPrice.Text != "" || cmb_Tax.Text != "" || txt_TotalDiscount.Text != "" || txt_ShipCost.Text != "" || cmb_PayType.Text != "" || txt_AmountPaid.Text != "" || txt_Notes.Text != "" || txt_NFC.Text != "" || txt_PrivateNotes.Text != "" || lbl_SubtotalAns.Text != "" || lbl_rs.Text != "" || txt_AmountDue.Text !="")
                {

                    cmd = new SqlCommand("insert into Invoice_Table4(DocumentNo,ClientName,PONumber,SecondNumber,IssueDate,PaymentTerm,DueDate,ProductName,Description,UOM,QTY,UnitPrice,Tax,TotalDiscount,ShippingCost,PaymentType,AmountPaid,Notes,NFC,PrivateNote,TotalAmount,SubTotal,AmountDue) values(@DocumentNo,@ClientName,@PONumber,@SecondNumber,@IssueDate,@PaymentTerm,@DueDate,@ProductName,@Description,@UOM,@QTY,@UnitPrice,@Tax,@TotalDiscount,@ShippingCost,@PaymentType,@AmountPaid,@Notes,@NFC,@PrivateNote,@TotalAmount,@SubTotal,@AmountDue)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@DocumentNo", txt_DocumentNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClientName", cmb_Client.Text.Trim());
                    cmd.Parameters.AddWithValue("@PONumber", txt_PONumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@SecondNumber", txt_SecondNumber.Text.ToString());
                    cmd.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Text.Trim());
                    cmd.Parameters.AddWithValue("@PaymentTerm", cmb_PaymentTerm.Text.Trim());
                    cmd.Parameters.AddWithValue("@DueDate", dateTimePicker2.Text.ToString());
                    cmd.Parameters.AddWithValue("@ProductName", cmb_ProductService.Text.ToString());
                    cmd.Parameters.AddWithValue("@Description", txt_Description.Text.ToString());
                    cmd.Parameters.AddWithValue("@UOM", cmb_UOM.Text.ToString());
                    cmd.Parameters.AddWithValue("@QTY", txt_QTY.Text.ToString());
                    cmd.Parameters.AddWithValue("@UnitPrice", txt_UnitPrice.Text.ToString());
                    cmd.Parameters.AddWithValue("@Tax", cmb_Tax.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalDiscount", txt_TotalDiscount.Text.ToString());
                    cmd.Parameters.AddWithValue("@ShippingCost", txt_ShipCost.Text.ToString());
                    cmd.Parameters.AddWithValue("@PaymentType", cmb_PayType.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountPaid", txt_AmountPaid.Text.ToString());
                    cmd.Parameters.AddWithValue("@Notes", txt_Notes.Text.ToString());
                    cmd.Parameters.AddWithValue("@NFC", txt_NFC.Text.ToString());
                    cmd.Parameters.AddWithValue("@PrivateNote", txt_PrivateNotes.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalAmount", lbl_rs.Text.ToString());
                    cmd.Parameters.AddWithValue("@SubTotal", lbl_SubtotalAns.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountDue", txt_AmountDue.Text.ToString());
                    

                    cmd.ExecuteNonQuery();
                   
                    MessageBox.Show("Data Save Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clear();
                    //btn_Preview.Enabled = true;
                    //btn_Save.Enabled = false;
                    
                    con.Close();
                   
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }

               
            }
            save();
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

        public void save()
        {
            //if (txt_DocumentNum.Text != "" || cmb_ProductService.Text != "" || txt_Description.Text != "" || cmb_UOM.Text != "" || txt_QTY.Text != "" || txt_UnitPrice.Text != "" || cmb_Tax.Text != "")
            //{

            //    cmd = new SqlCommand("insert into InvoiceProduct_Table(InvoiceNo,ProductName,Description,UOM,QTY,UnitPrice,Tax) values(@InvoiceNo,@ProductName,@Description,@UOM,@QTY,@UnitPrice,@Tax)", con);
            //    con.Open();

            //    cmd.Parameters.AddWithValue("@InvoiceNo", txt_DocumentNum.Text.Trim());
            //    cmd.Parameters.AddWithValue("@ProductName", cmb_ProductService.Text.ToString());
            //    cmd.Parameters.AddWithValue("@Description", txt_Description.Text.ToString());
            //    cmd.Parameters.AddWithValue("@UOM", cmb_UOM.Text.ToString());
            //    cmd.Parameters.AddWithValue("@QTY", txt_QTY.Text.ToString());
            //    cmd.Parameters.AddWithValue("@UnitPrice", txt_UnitPrice.Text.ToString());
            //    cmd.Parameters.AddWithValue("@Tax", cmb_Tax.Text.ToString());

            //    cmd.ExecuteNonQuery();
            //    //clear();
            //    con.Close();
            //}
            //else
            //{
            //    //MessageBox.Show("Please Provide Details!");
            //}
          
               //DataGridViewRow dr;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert_all_row_gridview";
                cmd.CommandType = CommandType.StoredProcedure;

                string productname = row.Cells[0].Value.ToString();
                string description = row.Cells[1].Value.ToString();
                string UOM = row.Cells[2].Value.ToString();
                int QTY =Convert.ToInt32( row.Cells[3].Value.ToString());
                decimal price = Convert.ToDecimal(row.Cells[4].Value.ToString());
                decimal tax = Convert.ToDecimal(row.Cells[5].Value.ToString());

                cmd.Parameters.AddWithValue("@InvoiceNo", txt_DocumentNum.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductName",productname);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@UOM", UOM);
                cmd.Parameters.AddWithValue("@QTY", QTY);
                cmd.Parameters.AddWithValue("@UnitPrice", price);
                cmd.Parameters.AddWithValue("@Tax", tax);

                cmd.ExecuteNonQuery();

                con.Close();

            }
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
        ProductClass cartitem;
        decimal tax;
        private void btn_Add_Click(object sender, EventArgs e) 
        {
           int add = 0;
           int  total = 1;

            cartitem = new ProductClass()
           {
               ProductService = cmb_ProductService.Text,
               Description= txt_Description.Text.Trim(),
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
          
            if(cmb_Tax.Items.Equals("0"))
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

          


        //   int Row = 0;


        //   if (cmb_ProductService.Text != "" & txt_Description.Text != "" & cmb_UOM.Text != "" & txt_QTY.Text != "" & txt_UnitPrice.Text != "" & cmb_Tax.Text != "" & txt_TotalDiscount.Text != "")
        //    {
				
        //        //
        //        // Add new row to DataGridView where the values
        //                        // are to be entered
        //        //
        //        dataGridView1.Rows.Add();
				
        //        Row = dataGridView1.Rows.Count - 2;
				
        //        //
        //        // Store values from text boxes to DataGridView
        //        //
        //        dataGridView1[0, Row].Value = cmb_ProductService.Text;
        //        dataGridView1[1, Row].Value = txt_Description.Text;
        //        dataGridView1[2, Row].Value = cmb_UOM.Text;
        //        dataGridView1[3, Row].Value = txt_UnitPrice.Text;
        //        dataGridView1[4, Row].Value = txt_QTY.Text;
        //        dataGridView1[5, Row].Value = "";
        //        dataGridView1[6, Row].Value = txt_TotalDiscount.Text;
        //        dataGridView1[7, Row].Value = cmb_Tax.Text;
        //        dataGridView1.Refresh();
        //    }
			
        //    //
        //    // If all text boxes are not filled in
        //    //
        //    else
        //    {
        //        MessageBox.Show("You did not entered values to all text boxes",
        //        "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        //    }
		
        

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Want to RESET??", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            
            cmb_ProductService.Text = "";
            dataGridView1.DataSource = null;
            cmb_ProductService.Focus();
            shoppingcart = null;
            txt_Description.Text = "";
            cmb_UOM.Text = "";
            txt_QTY.Text = "";
            txt_UnitPrice.Text = "";
            cmb_Tax.Text = "";

        }
       decimal allToal;
       decimal discount1, total1;
       decimal value1 = 0;
       
        private void txt_TotalDiscount_TextChanged(object sender, EventArgs e)
        {
           // decimal to; 
            if (txt_TotalDiscount.Text == "")
            {
             //   discount1 = value1;
             //   to = Convert.ToDecimal(lbl_rs.Text);
             //   //discount = Convert.ToDecimal(txt_TotalDiscount.Text.Trim());
             //   total1 = ((to * discount1) / 100);
             //   lbl_rs.Text = Convert.ToString(total1 + totalamount);
             //   lbl_discounts.Text = "";
             //   allToal = Convert.ToDecimal(lbl_rs.Text);
             //   lbl_Discount.Text = "Discount" + "(" + Convert.ToString(discount) + "%" + ")";
             //   lbl_discounts.Text = Convert.ToString(total);
             }
            else
            {
                //discount = Convert.ToDecimal(txt_TotalDiscount.Text.Trim());
                //to = Convert.ToDecimal(lbl_rs.Text);
                //total1 = ((to * discount1) / 100);
                //lbl_rs.Text = Convert.ToString(total1 + totalamount);
                //lbl_Discount.Text = "Discount" + "(" + Convert.ToString(txt_TotalDiscount.Text.Trim()) + "%" + ")";
                //lbl_discounts.Text = Convert.ToString(total);
            }
            if (txt_TotalDiscount.Text=="")
            {
                  btn_AddDis.Enabled = false;
            }
            else
            {
                btn_AddDis.Enabled = true;
            }
          
          
        }
        decimal discount, total;
        decimal value = 0;
        decimal toshipping1;
        private int rowIndex;
        private void txt_ShipCost_TextChanged(object sender, EventArgs e)
        {
           //int r = 0;

            if (txt_ShipCost.Text== "")
            {
                //discount = Convert.ToDecimal(lbl_rs.Text);
                ////discount = Convert.ToDecimal(txt_TotalDiscount.Text.Trim());
                //lbl_shipping.Text = "";
                //decimal toshipping =0;
                //lbl_rs.Text = Convert.ToString(discount-toshipping);
                //lbl_Shiping.Text = "Shipping & Packging" + "(" + Convert.ToString(toshipping) + "%" + ")";
                //lbl_shipping.Text = Convert.ToString(toshipping);
            }
            else
            {
                
                //discount = Convert.ToDecimal(lbl_rs.Text);
                //toshipping1 = Convert.ToDecimal(txt_ShipCost.Text.Trim());
                //lbl_rs.Text = Convert.ToString(toshipping1+discount);
                //lbl_shipping.Text = "Shipping & Packging" + "(" + Convert.ToString(txt_ShipCost.Text.Trim()) + "%" + ")";
                //lbl_shipping.Text = Convert.ToString(toshipping1);
                
            }

            if (txt_ShipCost.Text == "")
            {
                btn_AddShipCost.Enabled = false;
            }
            else
            {
                btn_AddShipCost.Enabled = true;
            }
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
          
            InvoicePrint_frm frm = new InvoicePrint_frm();
            frm.Show();
            //btn_Preview.Enabled = false;
            //btn_Save.Enabled = true;
            
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
            totalamountshipping = Convert.ToDecimal(txt_ShipCost.Text);
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

            txt_ShipCost.Text = "";
            btn_AddShipCost.Enabled = false;
        }

        private void txt_DocumentNum_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = txt_DocumentNum.Text;


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                // SqlCommand cmd;

                string query = "select ClientName,PONumber,SecondNumber,PaymentTerm,ProductName,TotalDiscount,ShippingCost,PaymentType,Notes,AmountPaid,AmountDue,SubTotal,TotalAmount  from Invoice_Table4 where DocumentNo='" + compare + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cmb_Client.Text = reader["ClientName"].ToString();
                    txt_PONumber.Text = reader["PONumber"].ToString();
                    txt_SecondNumber.Text = reader["SecondNumber"].ToString();
                    //dateTimePicker1.Text = reader["IssueDate"].ToString();
                    cmb_PaymentTerm.Text = reader["PaymentTerm"].ToString();
                    //dateTimePicker2.Text = reader["DueDate"].ToString();
                    cmb_ProductService.Text = reader["ProductName"].ToString();
                    txt_TotalDiscount.Text = reader["TotalDiscount"].ToString();
                    txt_ShipCost.Text = reader["ShippingCost"].ToString();
                    cmb_PayType.Text = reader["PaymentType"].ToString();
                    txt_Notes.Text = reader["Notes"].ToString();
                    txt_AmountPaid.Text = reader["AmountPaid"].ToString();
                    txt_AmountDue.Text = reader["AmountDue"].ToString();
                    lbl_SubtotalAns.Text = reader["SubTotal"].ToString();
                    lbl_rs.Text = reader["TotalAmount"].ToString();
                   
               }

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Not Found!!");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string compare = txt_DocumentNum.Text;



                if (cmb_Client.Text != "" || txt_TotalDiscount.Text != "" || txt_ShipCost.Text != "" || cmb_PayType.Text != "" || txt_Notes.Text != "" || txt_AmountPaid.Text != "" || txt_AmountDue.Text != "" || lbl_rs.Text != "")
                {

                    String query = "update Invoice_Table4 set ClientName=@ClientName,TotalDiscount=@TotalDiscount,ShippingCost=@ShippingCost,PaymentType=@PaymentType,Notes=@Notes,AmountPaid=@AmountPaid,AmountDue=@AmountDue,TotalAmount=@TotalAmount where DocumentNo='" + compare + "'";

                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ClientName", cmb_Client.Text.Trim());
                    cmd.Parameters.AddWithValue("@TotalDiscount", txt_TotalDiscount.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShippingCost", txt_ShipCost.Text.ToString());
                    cmd.Parameters.AddWithValue("@PaymentType", cmb_PayType.Text.Trim());
                    cmd.Parameters.AddWithValue("@Notes", txt_Notes.Text.Trim());
                    cmd.Parameters.AddWithValue("@AmountPaid", txt_AmountPaid.Text.ToString());
                    cmd.Parameters.AddWithValue("@AmountDue", txt_AmountDue.Text.Trim());
                    cmd.Parameters.AddWithValue("@TotalAmount", lbl_rs.Text.Trim());
                  
                  

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


                string compare = txt_DocumentNum.Text;
                con.Open();
                SqlDataAdapter sqldata = new SqlDataAdapter("delete from Invoice_Table4  where DocumentNo='" + compare + "'", con);
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

        private void btn_DeleteRow_Click(object sender, EventArgs e)
        {
            //int rowIndex = dataGridView1.CurrentCell.RowIndex;
            //dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void txt_QTY_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_QTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
                lbl_Qty.Text = "";
            }

            else
            {

                lbl_Qty.Text = "Please Enter Only Number!!";

                e.Handled = true;
            }
        }

        private void txt_AmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
                lbl_PaidAmountMsg.Text = "";
            }

            else
            {

                lbl_PaidAmountMsg.Text = "Please Enter Only Number!!";

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

          
           //if (cmb_Tax.Items.Equals("0"))
           // {
           //     tax = 0;
           //     lbl_SubtotalAns.Text = Convert.ToString(totalamount);
           //     lbl_rs.Text = Convert.ToString(tax + totalamount);
           //     lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
           //     lbl_taxs.Text = Convert.ToString(tax);
           // }
           // else
           // {
           //     decimal taxvalue = Convert.ToDecimal(cmb_Tax.Text);
           //     tax = ((totalamount * taxvalue) / 100);
           //     lbl_SubtotalAns.Text = Convert.ToString(totalamount);
           //     lbl_rs.Text = Convert.ToString(tax + totalamount);
           //     lbl_Tax.Text = "Tax" + "(" + Convert.ToDecimal(cmb_Tax.Text) + "%" + ")";
           //     lbl_taxs.Text = Convert.ToString(tax);
           // }

            
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
