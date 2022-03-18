using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Small_Shop_Management_System
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BillService" in both code and config file together.
    public class BillService : IBillService
    {
        public DataSet GetBills()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CustomerName, MobileNumber, Date, TotalAmount FROM bills",
                @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            DataSet ds = new DataSet();
            da.Fill(ds, "bills");
            return ds;
        }

        public string GenerateBill(Bill bill)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO bills (CustomerName,MobileNumber,TotalAmount,Date) VALUES (@nm,@no,@amt,@dat)";
                SqlParameter p0 = new SqlParameter("@nm", bill.CustomerName);
                SqlParameter p1 = new SqlParameter("@no", bill.MobileNo);
                SqlParameter p2 = new SqlParameter("@amt", bill.TotalAmount);
                SqlParameter p3 = new SqlParameter("@dat", bill.Date);

                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (new Exception("Error on generating bill!!"));
            }
            finally
            {
                con.Close();
            }
            return "Bill Generated Successfully!!";
        }

    }
}
