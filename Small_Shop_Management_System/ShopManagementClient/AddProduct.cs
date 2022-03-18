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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                ShopManagementClient.ProductServiceReference.ProductServiceClient sc = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
                ShopManagementClient.ProductServiceReference.Product p = new ProductServiceReference.Product();
                p.Name = name.Text;
                p.Category = category.Text;
                p.Price = int.Parse(price.Text);
                p.Quantity = int.Parse(quantity.Text);
                string msg = sc.AddProduct(p);
                MessageBox.Show(msg);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can not Add a Product");
            }
        }
    }
}
