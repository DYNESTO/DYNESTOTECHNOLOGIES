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
    public partial class AddProduct_frm :Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        public AddProduct_frm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool isvalidated()
        {
            if (txt_ProductName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ProductName.Focus();
                return false;
            }
            if (txt_Description.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Description is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Description.Focus();
                return false;
            }
            if (txt_UnitPrice.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Unit Price is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UnitPrice.Focus();
                return false;
            }
            if (cmb_UOM.Text.Trim() == string.Empty)
            {
                MessageBox.Show("UOM  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_UOM.Focus();
                return false;
            }
            if (cmb_Taxes.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Taxes  is required !! You can enter 0 when no any tax. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Taxes.Focus();
                return false;
            }


            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {

                if (txt_ProductName.Text != "" || txt_Description.Text != "" || txt_UnitPrice.Text != "" || cmb_UOM.Text != "" || cmb_Taxes.Text != "")
                {

                    cmd = new SqlCommand("insert into AddProduct_Table2(ProductName,Description,UnitPrice,UoM,Taxes) values(@ProductName,@Description,@UnitPrice,@UoM,@Taxes)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ProductName", txt_ProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txt_Description.Text.Trim());
                    cmd.Parameters.AddWithValue("@UnitPrice", txt_UnitPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@UoM", cmb_UOM.Text.ToString());
                    cmd.Parameters.AddWithValue("@Taxes", cmb_Taxes.Text.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Save Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
        }

        private void AddProduct_frm_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from Tax_Table10"; 

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmb_Taxes.SelectedItem = "Select";
                    cmb_Taxes.Items.Add(reader["TaxPercentage"].ToString());

                }
            }
            catch (SqlException ex)
            {

            }
            con.Close();
        }

        private void txt_UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
