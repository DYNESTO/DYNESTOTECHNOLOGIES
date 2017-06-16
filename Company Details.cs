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
    public partial class CompanyDetails_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        string imgLocation1 = "";
        public CompanyDetails_frm()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {

                if (txt_CompanyName.Text != "" || txt_Country.Text != "" || txt_Address.Text != "" || txt_City.Text != "" || txt_State.Text != "" || txt_Phone.Text != "" || txt_Email.Text != "" || txt_Website.Text != "" || txt_Tin.Text != "" || txt_TaxNo.Text != "" || txt_AdditionalDetail.Text != "" || txt_PAN.Text != "" || txt_PINCode.Text != "" || txt_Currency.Text != "" || pictureBox_Logo.Image != null)
                {

                    cmd = new SqlCommand("insert into CompanyDetail_Table3(CompanyName,Country,Address,City,State,CompanyPhone,Email,Website,TIN,ServiceTaxNo,AdditionalDetail,PAN,PINCode,Currency,Logo) values(@CompanyName,@Country,@Address,@City,@State,@CompanyPhone,@Email,@Website,@TIN,@ServiceTaxNo,@AdditionalDetail,@PAN,@PINCode,@Currency,@Logo)", con);
                    con.Open();

                    byte[] image = null;
                    FileStream streem = new FileStream(imgLocation1, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(streem);
                    image = brs.ReadBytes((int)streem.Length);

                    cmd.Parameters.AddWithValue("@CompanyName", txt_CompanyName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", txt_Country.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", txt_City.Text.ToString());
                    cmd.Parameters.AddWithValue("@State", txt_State.Text.Trim());
                    cmd.Parameters.AddWithValue("@CompanyPhone", txt_Phone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txt_Email.Text.ToString());
                    cmd.Parameters.AddWithValue("@Website", txt_Website.Text.ToString());
                    cmd.Parameters.AddWithValue("@TIN", txt_Tin.Text.ToString());
                    cmd.Parameters.AddWithValue("@ServiceTaxNo", txt_TaxNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@AdditionalDetail", txt_AdditionalDetail.Text.ToString());
                    cmd.Parameters.AddWithValue("@PAN", txt_PAN.Text.ToString());
                    cmd.Parameters.AddWithValue("@PINCode", txt_PINCode.Text.ToString());
                    cmd.Parameters.AddWithValue("@Currency", txt_Currency.Text.ToString());
                    cmd.Parameters.AddWithValue("@Logo", image);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Save Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
        }

        private bool isvalidated()
        {
            if (txt_CompanyName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Company Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_CompanyName.Focus();
                return false;
            }
            if (txt_Country.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Country is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Country.Focus();
                return false;
            }
            if (txt_Address.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Address is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Address.Focus();
                return false;
            }
            if (txt_City.Text.Trim() == string.Empty)
            {
                MessageBox.Show("City  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_City.Focus();
                return false;
            }
            if (txt_State.Text.Trim() == string.Empty)
            {
                MessageBox.Show("State  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_State.Focus();
                return false;
            }

            if (txt_PINCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PIN Code  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PINCode.Focus();
                return false;
            }
            if (pictureBox_Logo.Image == null)
            {
                MessageBox.Show("Company Logo is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendailog = new OpenFileDialog();
            opendailog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            if (opendailog.ShowDialog() == DialogResult.OK)
            {
                imgLocation1 = opendailog.FileName.ToString();
                pictureBox_Logo.ImageLocation = imgLocation1;
            }
        }

        public void clear()
        {
            txt_AdditionalDetail.Text = "";
            txt_Address.Text = "";
            txt_City.Text = "";
            txt_CompanyName.Text = "";
            txt_Country.Text = "";
            txt_Currency.Text = "";
            txt_Email.Text = "";
            txt_PAN.Text = "";
            txt_Phone.Text = "";
            txt_PINCode.Text = "";
            txt_State.Text = "";
            txt_TaxNo.Text = "";
            txt_Tin.Text = "";
            txt_Website.Text = "";
            pictureBox_Logo.Image = null;
            
        }

        private void btn_Update_Click(object sender, EventArgs e) 
        {
            try
            {
                string compare = txt_CompanyName.Text;

                byte[] img = null;
                FileStream fs = new FileStream(imgLocation1, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);


                if (txt_Country.Text != "" || txt_Address.Text != "" || txt_City.Text != "" || txt_State.Text != "" || txt_Phone.Text != "" || txt_Email.Text != "" || txt_Website.Text != "" || txt_AdditionalDetail.Text != "" || txt_PAN.Text != "" || txt_PINCode.Text != "" || txt_Currency.Text != "" || pictureBox_Logo.Image !=null)
                {

                    String query = "update CompanyDetail_Table3 set Country=@Country,Address=@Address,City=@City,State=@State,CompanyPhone=@CompanyPhone,Email=@Email,Website=@Website,AdditionalDetail=@AdditionalDetail,PAN=@PAN,PINCode=@PINCode,Currency=@Currency,Logo=@Logo where CompanyName='" + compare + "'";

                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Country", txt_Country.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txt_Address.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", txt_City.Text.ToString());
                    cmd.Parameters.AddWithValue("@State", txt_State.Text.Trim());
                    cmd.Parameters.AddWithValue("@CompanyPhone", txt_Phone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txt_Email.Text.ToString());
                    cmd.Parameters.AddWithValue("@Website", txt_Website.Text.Trim());
                    cmd.Parameters.AddWithValue("@AdditionalDetail", txt_AdditionalDetail.Text.Trim());
                    cmd.Parameters.AddWithValue("@PAN", txt_PAN.Text.Trim());
                    cmd.Parameters.AddWithValue("@PINCode", txt_PINCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Currency", txt_Currency.Text.Trim());
                    cmd.Parameters.AddWithValue("@Logo", img);
                   
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


                string compare = txt_CompanyName.Text;
                con.Open();
                SqlDataAdapter sqldata = new SqlDataAdapter("delete from CompanyDetail_Table3  where CompanyName='" + compare + "'", con);
                sqldata.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Delete Successfuly", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Missing!!");
            }
        }

        private void txt_CompanyName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string compare = txt_CompanyName.Text; 
               

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
               // SqlCommand cmd;

                string query = "select Country,Address,City,State,CompanyPhone,Email,Website,TIN,ServiceTaxNo,AdditionalDetail,PAN,PINCode,Currency,Logo   from CompanyDetail_Table3 where CompanyName='" + compare + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    txt_Country.Text = reader["Country"].ToString();
                    txt_Address.Text = reader["Address"].ToString();
                    txt_City.Text = reader["City"].ToString();
                    txt_State.Text = reader["State"].ToString();
                    txt_Phone.Text = reader["CompanyPhone"].ToString();
                    txt_Email.Text = reader["Email"].ToString();
                    txt_Website.Text = reader["Website"].ToString();
                    txt_Tin.Text = reader["TIN"].ToString();
                    txt_TaxNo.Text = reader["ServiceTaxNo"].ToString();
                    txt_AdditionalDetail.Text = reader["AdditionalDetail"].ToString();
                    txt_PAN.Text = reader["PAN"].ToString();
                    txt_PINCode.Text = reader["PINCode"].ToString();
                    txt_Currency.Text = reader["Currency"].ToString();
                   
                  
                    byte[] image = (byte[])(reader["Logo"]);

                    if (image == null)
                    {
                        pictureBox_Logo.Image = null;

                    }
                    else
                    {
                        MemoryStream ms1 = new MemoryStream(image);
                        pictureBox_Logo.Image = Image.FromStream(ms1);

                    }


                }

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Not Found!!");
            }
        }

        private void CompanyDetails_frm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            pictureBox_Logo.Image = null;
        }

        private void txt_Country_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_State_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
              
            }

            else
            {

                MessageBox.Show ("Please Enter Only Number!!");
                e.Handled = true;
            }
        }

        private void txt_PINCode_KeyPress(object sender, KeyPressEventArgs e)
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
