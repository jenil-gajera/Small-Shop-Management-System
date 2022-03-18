using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagementClient
{
    public partial class ShowProducts : Form
    {
        public ShowProducts()
        {
            InitializeComponent();
        }

        private void ShowProducts_Load(object sender, EventArgs e)
        {
            ShopManagementClient.ProductServiceReference.ProductServiceClient sc = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            DataSet ds = sc.GetProducts();
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }
    }
}
