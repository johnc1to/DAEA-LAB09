using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice_detail
    {
        public int Detail_id { get; set; }
        public int Invoice_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set;}
        public double Price { get; set;}
        public double Subtotal { get; set;}
    }
}
