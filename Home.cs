using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_Project
{
    public partial class Home : Form
    {
        private string appPassword;
        private string globalPath;

        public Home()
        {
            InitializeComponent();
        }

        public Home(string appPassword, string globalPath)
        {
            // TODO: Complete member initialization
            this.appPassword = appPassword;
            this.globalPath = globalPath;
        }

        private void quotationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuotationReport_frm frm = new QuotationReport_frm();
            frm.Show();
        }

        private void standardInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice_frm frm = new Invoice_frm();
            frm.Show();
        }

        private void taxInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxInvoice_frm frm = new TaxInvoice_frm();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invoice_frm frm = new Invoice_frm();
            frm.Show();
        }

        private void retailInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetailInvoice_frm frm = new RetailInvoice_frm(); 
            frm.Show();
        }

        private void exciseInvoiceToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            NewExciseInvoice_frm frm = new NewExciseInvoice_frm(); 
            frm.Show();
        }

        private void proformaInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProformaInvoice_frm frm = new NewProformaInvoice_frm();
            frm.Show();
        }

        private void quotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewQuotation_frm frm = new NewQuotation_frm();
            frm.Show();
        }

        private void deliveryNoteChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDeliveryNote_frm frm = new NewDeliveryNote_frm();
            frm.Show();
        }

        private void companyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyDetails_frm frm = new CompanyDetails_frm();
            frm.Show();
        }

        private void taxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taxes_frm frm = new Taxes_frm();
            frm.Show();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceReport_frm frm = new InvoiceReport_frm();
            frm.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientReports_frm frm = new ClientReports_frm();
            frm.Show();
        }

        private void productsServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_frm frm = new Product_frm();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TaxInvoice_frm frm = new TaxInvoice_frm();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewQuotation_frm frm = new NewQuotation_frm();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewProformaInvoice_frm frm = new NewProformaInvoice_frm(); 
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RetailInvoice_frm frm = new RetailInvoice_frm();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewExciseInvoice_frm frm = new NewExciseInvoice_frm();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewDeliveryNote_frm frm = new NewDeliveryNote_frm();
            frm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void exciseInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExciseInvoiceReport frm = new ExciseInvoiceReport();
            frm.Show();
        }

        private void proformaInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProformaReport frm = new ProformaReport();
            frm.Show();
        }

        private void retailInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RetailInvoiceReport_frm frm = new RetailInvoiceReport_frm();
            frm.Show();
        }

        private void taxInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaxInvoiceReport_frm frm = new TaxInvoiceReport_frm();
            frm.Show();
        }

        private void deliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryNoteReport_frm frm = new DeliveryNoteReport_frm();
            frm.Show();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void msOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void msExcellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("Winexcel.exe");
        }

        private void employeeRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeRegister frm = new EmployeeRegister();
            frm.Show();
        }

        private void employeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeRecord_frm frm = new EmployeRecord_frm();
            frm.Show();
        }

        private void employeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeAttendance frm = new EmployeAttendance();
            frm.Show();
        }

        private void attendanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceRecord frm = new AttendanceRecord();
            frm.Show();
        }
    }
}
