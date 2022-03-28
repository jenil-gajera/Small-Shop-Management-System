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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            ShopManagementClient.ProductServiceReference.ProductServiceClient sc = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            DataSet ds = sc.GetProducts();
            DataTable dt = ds.Tables[0];
            listBox1.DataSource = dt.DefaultView;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
            sc.Close();

            ShopManagementClient.ProductServiceReference.ProductServiceClient proxy = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            ShopManagementClient.ProductServiceReference.Product product = proxy.GetProduct(int.Parse(listBox1.SelectedValue.ToString()));
            name.Text = product.Name.ToString();
            category.Text = product.Category;
            price.Text = product.Price.ToString();
            quantity.Text = product.Quantity.ToString();
        }

        private void update_Click(object sender, EventArgs e)
        {
            ShopManagementClient.ProductServiceReference.ProductServiceClient sc = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            try
            {
                if(listBox1.SelectedValue.ToString() != null)
                {
                    int id = int.Parse(listBox1.SelectedValue.ToString());
                    ShopManagementClient.ProductServiceReference.Product p = new ProductServiceReference.Product();
                    
                    p.Id = id;
                    p.Name = name.Text;
                    p.Category = category.Text;
                    p.Price = int.Parse(price.Text);
                    p.Quantity = int.Parse(quantity.Text);
                    string msg = sc.UpdateProduct(p);
                    MessageBox.Show(msg);
                    this.OnLoad(e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }

        private void listBox1_click(object sender, EventArgs e)
        {
            ShopManagementClient.ProductServiceReference.ProductServiceClient proxy = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            ShopManagementClient.ProductServiceReference.Product product = proxy.GetProduct(int.Parse(listBox1.SelectedValue.ToString()));
            name.Text = product.Name.ToString();
            category.Text = product.Category;
            price.Text = product.Price.ToString();
            quantity.Text = product.Quantity.ToString();
        }
    }
}
