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
    public partial class GenerateBill : Form
    {
        public GenerateBill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ShopManagementClient.BillServiceReference.BillServiceClient sc = new ShopManagementClient.BillServiceReference.BillServiceClient("BasicHttpBinding_IBillService");
                ShopManagementClient.BillServiceReference.Bill p = new BillServiceReference.Bill();
                p.CustomerName = cname.Text;
                p.MobileNo = long.Parse(mobileno.Text);
                p.Date = date.Value;
                p.TotalAmount = int.Parse(totalamt.Text);
                string msg = sc.GenerateBill(p);
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not Generate a Bill");
            }
        }
    }
}
