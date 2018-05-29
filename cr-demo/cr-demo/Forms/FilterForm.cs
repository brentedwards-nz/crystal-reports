using cr_demo.Data;
using cr_demo.Forms;
using cr_demo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cr_demo
{
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            this.dteFrom.Value = new DateTime(1998, 1, 1);
            this.dteTo.Value = new DateTime(1998, 6, 1);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using(var context = new NorthWindDb())
            {
                var result = context.Orders
                            .Where(o => o.OrderDate >= this.dteFrom.Value && o.OrderDate <= this.dteTo.Value)
                            .Select(s => new OrderModel {
                                OrderId = s.OrderID,
                                ContactName = s.Customer.ContactName,
                                Address = s.Customer.Address,
                                City = s.Customer.City,
                                PostCode = s.Customer.PostalCode,
                                Phone = s.Customer.Phone,
                                Date = s.OrderDate
                            });
                this.orderModelBindingSource.DataSource = result.ToList();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OrderModel orderModel = this.orderModelBindingSource.Current as OrderModel;
            if(orderModel != null)
            {
                using (var context = new NorthWindDb())
                {
                    var orderDetail = context.Order_Details.Where(o => o.OrderID == orderModel.OrderId).Select(o => new OrderDetailModel {
                        OrderId = o.OrderID,
                        ProductName = o.Product.ProductName,
                        Discount = o.Discount,
                        Quantity = o.Quantity,
                        UnitPrice = o.UnitPrice,
                        Total = 1
                    }).ToList();

                    using (var frm = new PrintForm(orderModel, orderDetail))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }
    }
}
