using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    class ExiceClass
    {
        public string ProductService { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public int Quantity { get; set; }
        public decimal Unitprice { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ExiceDuty { get; set; }
    }
}
