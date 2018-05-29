using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr_demo.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public DateTime? Date { get; set; }
    }
}
