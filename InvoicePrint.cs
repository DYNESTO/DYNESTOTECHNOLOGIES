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
using CrystalDecisions.CrystalReports.Engine;


namespace Inventory_Management_Project
{
    public partial class InvoicePrint_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;

        ReportDocument crypt = new ReportDocument();
       
        public InvoicePrint_frm()
        {
            InitializeComponent();
        }

        private void InvoicePrint_Load(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                String query = "select * from Invoice_Table4";

                SqlCommand cmd1 = new SqlCommand(query, con1);
                SqlDataReader reader;
                con1.Open();
                reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    cmb_ClientName.SelectedItem = "Select";
                    cmb_ClientName.Items.Add(reader["DocumentNo"].ToString());

                }
                con1.Close();
            }
            catch (Exception ex)
            {

            }
            try
            {
                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);

                SqlDataAdapter adapt2 = new SqlDataAdapter("Select * from CompanyDetail_Table3", con2);
                DataSet dt2 = new DataSet();
                adapt2.Fill(dt2, "CompanyDetail_Table3");
                crypt.Load(@"D:\Cry\InvoiceReport.rpt");
                crypt.SetDataSource(dt2);
                crystalReportViewer1.ReportSource = crypt;
                con2.Close();
            }
            catch (Exception ex)
            {

            }

          
         }

        private void btn_Show_Click(object sender, EventArgs e)
        {


            //SqlConnection con3= new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            //con3.Open();
            //SqlDataAdapter adapt3 = new SqlDataAdapter("Select * from InvoiceProduct_Table", con3);
            //DataSet dt3 = new DataSet();
            //adapt3.Fill(dt3, "InvoiceProduct_Table");
            //crypt.Load(@"D:\Inventory_Management_Project\Inventory_Management_Project\InvoiceReport.rpt");
            //crypt.SetDataSource(dt3);
            //crystalReportViewer1.ReportSource = crypt;
            //con3.Close();

                //SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                //con2.Open();
                //SqlDataAdapter adapt2 = new SqlDataAdapter("Select * from Invoice_Table4 where DocumentNo='" + txt_InvoiceNo.Text + "'", con3);
                //DataSet dt2 = new DataSet();
                //adapt1.Fill(dt2, "InvoiceProduct_Table");
                //crypt.Load(@"D:\Inventory_Management_Project\Inventory_Management_Project\InvoiceReport.rpt");
                //crypt.SetDataSource(dt2);
                //crystalReportViewer1.ReportSource = crypt;
                //con2.Close();
                  
                
        
        }
      
        private void cmb_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            setdata();
            Data();
            SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            SqlDataAdapter adapt4 = new SqlDataAdapter("Select * from Invoice_Table4 where DocumentNo = '" + cmb_ClientName.Text + "'", con4);
            DataSet dt4 = new DataSet();
            adapt4.Fill(dt4, "Invoice_Table4");
            crypt.Load(@"D:\Cry\InvoiceReport.rpt");
            crypt.SetDataSource(dt4);
            crystalReportViewer1.ReportSource = crypt;
            
        }

        public void setdata()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                String query = "select * from Invoice_Table4 where DocumentNo='" + cmb_ClientName.Text + "'";

                SqlCommand cmd1 = new SqlCommand(query, con1);
                SqlDataReader reader;
                con1.Open();
                reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    txt_ClientName.Text = reader["ClientName"].ToString();


                }
                con1.Close();
            }
            catch (Exception ex)
            {

            }
        }


        public void Data()
        {

            SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            con3.Open();
            SqlDataAdapter adapt3 = new SqlDataAdapter("Select * from InvoiceProduct_Table where InvoiceNo='" + cmb_ClientName.Text + "'", con3);
            DataSet dt3 = new DataSet();
            adapt3.Fill(dt3, "InvoiceProduct_Table");
            crypt.Load(@"D:\Cry\InvoiceReport.rpt");
            crypt.SetDataSource(dt3);
            crystalReportViewer1.ReportSource = crypt;
            con3.Close();
        }
        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            //SqlConnection con11 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            //con11.Open();
            //SqlDataAdapter adapt = new SqlDataAdapter("Select * from InvoiceProduct_Table", con11);
            //DataSet dt = new DataSet();
            //adapt.Fill(dt, "InvoiceProduct_Table");
            //crypt.Load(@"D:\Inventory_Management_Project\Inventory_Management_Project\InvoiceReport.rpt");
            //crypt.SetDataSource(dt);
            //crystalReportViewer1.ReportSource = crypt;
            //con11.Close();
        }
     
      
    }
}
 