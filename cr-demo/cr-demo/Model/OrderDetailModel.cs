using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr_demo.Model
{
    public class OrderDetailModel
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public decimal UnitPrice { get; set; }

        public float Total { get; set; }
    }
}
