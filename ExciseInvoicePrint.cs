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
using CrystalDecisions.Shared;

namespace Inventory_Management_Project
{
    public partial class ExciseInvoicePrint_frm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
        SqlCommand cmd;
        ReportDocument crypt = new ReportDocument();
        public ExciseInvoicePrint_frm()
        {
            InitializeComponent();
        }

        private void ExciseInvoicePrint_frm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                String query = "select * from ExciseInvoice_Table7";

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
                crypt.Load(@"D:\Cry\ExciseInvoice.rpt");
                crypt.SetDataSource(dt2);
                crystalReportViewer1.ReportSource = crypt;
                con2.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmb_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            //SqlDataAdapter adapt = new SqlDataAdapter("Select * from ExciseInvoice_Table7 where ClientName = '" + cmb_ClientName.Text + "'", con1);
            //DataSet dt = new DataSet();
            //adapt.Fill(dt, "ExciseInvoice_Table7");
            //crypt.Load(@"D:\Inventory_Management_Project\Inventory_Management_Project\ExciseInvoice.rpt");
            //crypt.SetDataSource(dt);
            //crystalReportViewer1.ReportSource = crypt;  

            setdata();
            Data();
            SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            SqlDataAdapter adapt4 = new SqlDataAdapter("Select * from ExciseInvoice_Table7 where DocumentNo = '" + cmb_ClientName.Text + "'", con4);
            DataSet dt4 = new DataSet();
            adapt4.Fill(dt4, "ExciseInvoice_Table7");
            crypt.Load(@"D:\Cry\ExciseInvoice.rpt");
            crypt.SetDataSource(dt4);
            crystalReportViewer1.ReportSource = crypt;         
        }

        public void Data()
        {

            SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
            con3.Open();
            SqlDataAdapter adapt3 = new SqlDataAdapter("Select * from ExciseInvoiceProduct_Table where InvoiceNo='" + cmb_ClientName.Text + "'", con3);
            DataSet dt3 = new DataSet();
            adapt3.Fill(dt3, "ExciseInvoiceProduct_Table");
            crypt.Load(@"D:\Cry\ExciseInvoice.rpt");
            crypt.SetDataSource(dt3);
            crystalReportViewer1.ReportSource = crypt;
            con3.Close();
        }

        public void setdata()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString);
                String query = "select * from ExciseInvoice_Table7 where DocumentNo='" + cmb_ClientName.Text + "'";

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
    }
}
