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
    public partial class ShowBills : Form
    {
        public ShowBills()
        {
            InitializeComponent();
        }

        private void ShowBills_Load(object sender, EventArgs e)
        {
            ShopManagementClient.BillServiceReference.BillServiceClient sc = new ShopManagementClient.BillServiceReference.BillServiceClient("BasicHttpBinding_IBillService");
            DataSet ds = sc.GetBills();
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }
    }
}
