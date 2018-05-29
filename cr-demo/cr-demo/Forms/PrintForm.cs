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

namespace cr_demo.Forms
{
    public partial class PrintForm : Form
    {
        List<OrderDetailModel> _orderDetailModel;
        OrderModel _orderModel;


        public PrintForm(OrderModel orderModel, List<OrderDetailModel> orderDetails)
        {
            InitializeComponent();

            this._orderModel = orderModel;
            this._orderDetailModel = orderDetails;
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            this.orderDetails1.SetDataSource(_orderDetailModel);
            this.orderDetails1.SetParameterValue("pOrderId", _orderModel.OrderId);
            this.orderDetails1.SetParameterValue("pContactName", _orderModel.ContactName);
            this.orderDetails1.SetParameterValue("pAddress", _orderModel.Address);
            this.orderDetails1.SetParameterValue("pCity", _orderModel.City);
            this.orderDetails1.SetParameterValue("pPostCode", _orderModel.PostCode);
            this.orderDetails1.SetParameterValue("pDate", _orderModel.Date);
            crystalReportViewer1.ReportSource = orderDetails1;
            crystalReportViewer1.Refresh();
        }
    }
}
