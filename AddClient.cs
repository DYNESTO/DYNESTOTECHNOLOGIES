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
    public partial class AddClient : Form
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        public AddClient()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        private void auto()
        {
            ClientID_txt.Text = "C-" + GetUniqueKey(3);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
        }

        private bool isvalidated()
        {
            if (ClientID_txt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ClientID is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClientID_txt.Focus();
                return false;
            }
            if (ClientNametxt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Client Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClientNametxt.Focus();
                return false;
            }
            if (ContactName_txt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Contact Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ContactName_txt.Focus();
                return false;
            }
            if (Phone_txt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Phone  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Phone_txt.Focus();
                return false;
            }
            if (txt_BillingAddress.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Billing Address  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_BillingAddress.Focus();
                return false;
            }
            if (City_txt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("City  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                City_txt.Focus();
                return false;
            }
            if (State_txt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("State  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                State_txt.Focus();
                return false;
            }
            if (PIN_txt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PIN Code  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PIN_txt.Focus();
                return false;
            }
            return true;
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            //auto();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    txt_ShippingAddress.Visible = true;
            //    txt_ShipCity.Visible = true;
            //    txt_ShipState.Visible = true;
            //    txt_Pin.Visible = true;
            //    txt_ShipCountry.Visible = true;
            //    lbl_ShipAddress.Visible = true;
            //    lbl_City.Visible = true;
            //    lbl_State.Visible = true;
            //    lbl_PINCode.Visible = true;
            //    lbl_Country.Visible = true;
            //}
           
            //else
            //{
            //    txt_ShippingAddress.Visible = false;
            //    txt_ShipCity.Visible = false;
            //    txt_ShipState.Visible = false;
            //    txt_Pin.Visible = false;
            //    txt_ShipCountry.Visible = false;
            //    lbl_ShipAddress.Visible = false;
            //    lbl_City.Visible = false;
            //    lbl_State.Visible = false;
            //    lbl_PINCode.Visible = false;
            //    lbl_Country.Visible = false;
            //}
        }

        private void AddClient_Load_1(object sender, EventArgs e)
        {
            auto();
        }

        private void checkBox_ShipAddress_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_ShipAddress.Checked)
            {
                ShipAddress_txt.Visible = true;
                ShipCity_txt.Visible = true;
                ShipState_txt.Visible = true;
                ShipPIN_txt.Visible = true;
                ShipCountry_txt.Visible = true;
                ShipAddress_lbl.Visible = true;
                ShipCity_lbl.Visible = true;
                ShipState_lbl.Visible = true;
                ShipPIN_lbl.Visible = true;
                ShipCountry_lbl.Visible = true;
            }

            else
            {
                ShipAddress_txt.Visible = false;
                ShipCity_txt.Visible = false;
                ShipState_txt.Visible = false;
                ShipPIN_txt.Visible = false;
                ShipCountry_txt.Visible = false;
                ShipAddress_lbl.Visible = false;
                ShipCity_lbl.Visible = false;
                ShipState_lbl.Visible = false;
                ShipPIN_lbl.Visible = false;
                ShipCountry_lbl.Visible = false;
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                if (ClientID_txt.Text != "" || ClientNametxt.Text != "" || ContactName_txt.Text != "" || Phone_txt.Text != "" || Email_txt.Text != "" || TIN_txt.Text != "" || PAN_txt.Text != "" || VATNo_txt.Text != "" || txt_BillingAddress.Text != "" || City_txt.Text != "" || State_txt.Text != "" || PIN_txt.Text != "" || Country_txt.Text != "" || PrivateClient_txt.Text != "" || OtherClient_txt.Text != "" || ServiceTax_txt.Text !="" || ShipAddress_txt.Text != "" || ShipCity_txt.Text != "" || ShipState_txt.Text != "" || ShipPIN_txt.Text != "" || ShipCountry_txt.Text != "")
                {

                    cmd = new SqlCommand("insert into AddClient(ClientID,ClientName,ContactName,Phone,Email,TIN,PAN,VATNo,BillingAddress,City,State,PINCode,Country,PrivateClient,OtherClient,ShippingAddress,ShipCity,ShipState,ShipPinCode,ShippingCountry,ServiceTaxNo) values(@ClientID,@ClientName,@ContactName,@Phone,@Email,@TIN,@PAN,@VATNo,@BillingAddress,@City,@State,@PINCode,@Country,@PrivateClient,@OtherClient,@ShippingAddress,@ShipCity,@ShipState,@ShipPinCode,@ShippingCountry,@ServiceTaxNo)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ClientID", ClientID_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClientName", ClientNametxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactName", ContactName_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", Phone_txt.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", Email_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@TIN", TIN_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@PAN", PAN_txt.Text.ToString());
                    cmd.Parameters.AddWithValue("@VATNo", VATNo_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@BillingAddress", txt_BillingAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", City_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@State", State_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@PINCode", PIN_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", Country_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@PrivateClient", PrivateClient_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@OtherClient", OtherClient_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShippingAddress", ShipAddress_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShipCity", ShipCity_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShipState", ShipState_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShipPinCode", ShipPIN_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ShippingCountry", ShipCountry_txt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ServiceTaxNo", ServiceTax_txt.Text.Trim());


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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            UpdateClientfrm frm = new UpdateClientfrm();
            frm.Show();
            this.Hide();
        }

        private void Phone_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
                lbl_Phonemsg.Text = "";
            }

            else
            {

                lbl_Phonemsg.Text = "Please Enter Only Number!!";

                e.Handled = true;
            }
        }

        private void City_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void State_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Country_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ClientNametxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ContactName_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ShipCity_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ShipState_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ShipCountry_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PIN_txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ShipPIN_txt_KeyPress(object sender, KeyPressEventArgs e)
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
