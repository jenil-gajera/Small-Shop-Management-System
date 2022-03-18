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
    public partial class DeleteProduct : Form
    {
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void DeleteProduct_Load(object sender, EventArgs e)
        {
            ShopManagementClient.ProductServiceReference.ProductServiceClient sc = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            DataSet ds = sc.GetProducts();
            DataTable dt = ds.Tables[0];
            listBox1.DataSource = dt.DefaultView;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
            sc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedValue.ToString()==null)
            {
                MessageBox.Show("Product Not Selected");
                return;
            }
            int id = int.Parse(listBox1.SelectedValue.ToString());
            ShopManagementClient.ProductServiceReference.ProductServiceClient sc = new ShopManagementClient.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
            try
            {
                string msg = sc.DeleteProduct(id);
                MessageBox.Show(msg);
                this.OnLoad(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can Not Delete This Product");
            }
            finally
            {
                sc.Close();
            }
        }
    }
}
