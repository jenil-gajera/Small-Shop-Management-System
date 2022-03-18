using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagementHost
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
        }

        ServiceHost sh1 = null, sh2 = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            sh1 = new ServiceHost(typeof(Small_Shop_Management_System.ProductService));
            sh1.Open();

            sh2 = new ServiceHost(typeof(Small_Shop_Management_System.BillService));
            sh2.Open();

            label1.Text = "ProductManagement Service is Running";
            label2.Text = "BillManagement Service is Running";

        }
    }
}
