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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    { 
        public DataSet GetProducts()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name, Category, Price, Quantity FROM products",
                @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            DataSet ds = new DataSet();
            da.Fill(ds, "products");
            return ds;
        }  

        public Product GetProduct(int id)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT Id, Name, Category, Price, Quantity FROM products WHERE Id = @id";
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product product = new Product();
            while(reader.Read())
            {
                product.Id = reader.GetInt32(0);
                product.Name = reader.GetString(1);
                product.Category = reader.GetString(2);
                product.Price = reader.GetInt32(3);
                product.Quantity = reader.GetInt32(4);
            }
            reader.Close();
            cnn.Close();
            return product;
        }
        public string AddProduct(Product product)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO products (Name,Category,Price,Quantity) VALUES (@nm,@cat,@prc,@qty)";
                SqlParameter p0 = new SqlParameter("@nm", product.Name);
                SqlParameter p1 = new SqlParameter("@cat", product.Category);
                SqlParameter p2 = new SqlParameter("@prc", product.Price);
                SqlParameter p3 = new SqlParameter("@qty", product.Quantity);

                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw (new Exception("Error on adding product!!"));
            }
            finally
            {
                con.Close();
            }
            return "Product Added Successfully!!";
        }

        public string UpdateProduct(Product product)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            string sqlStatement = "UPDATE products SET Name=@nm,Category=@cat,Price=@prc,Quantity=@qty WHERE Id=@id";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, con);
                
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@nm", product.Name);
                cmd.Parameters.AddWithValue("@cat", product.Category);
                cmd.Parameters.AddWithValue("@prc", product.Price);
                cmd.Parameters.AddWithValue("@qty", product.Quantity);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
            return "Product Updated Successfully!!";
        }

        public String DeleteProduct(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = myshop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            string sqlStatement = "DELETE FROM products WHERE Id= @id";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlStatement, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Error on deleting product");
            }
            finally
            {
                con.Close();
            }
            return "Product Deleted Successfully";
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
