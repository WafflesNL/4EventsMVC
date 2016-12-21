using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetProduct
    {
        /// <summary>
        /// Get all Products that are linked with a event
        /// </summary>
        /// <param name="EventID">EventID int</param>
        /// <returns>A list of Products that is linked with the event</returns>
        public static List<Copy> GetProductforEvent()
        {
            List<Copy> CopyList = new List<Copy>();

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Copy";
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int Productid = Convert.ToInt32(reader["Productid"]);
                        int Serialnumber = Convert.ToInt32(reader["Serialnumber"].ToString());
                        string Barcode = (reader["barcode"].ToString());

                        // id brand serie typenummer prijs
                        Copy Product = new Copy(ID, Serialnumber, Barcode);
                        CopyList.Add(Product);
                    }
                    return CopyList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());

                }
                finally
                {
                    DatabaseAcces.CloseConnection();
                }
            }
            return CopyList;
        }

        public static List<Copy> GetProductforAccount(string barcode)
        {
            List<Copy> CopyList = new List<Copy>();

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Copy WHERE barcode = @barcode";

                    cmd.Parameters.Add(new SqlParameter("barcode", barcode));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int Productid = Convert.ToInt32(reader["Productid"]);
                        int Serialnumber = Convert.ToInt32(reader["Serialnumber"].ToString());
                        string Barcode = (reader["barcode"].ToString());

                        // id brand serie typenummer prijs
                        Copy Product = new Copy(ID, Serialnumber, Barcode);
                        CopyList.Add(Product);
                    }
                    return CopyList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());

                }
                finally
                {
                    DatabaseAcces.CloseConnection();
                }
            }
            return CopyList;
        }

        /// <summary>
        /// Gets all Products that haven't been linked to an event yet
        /// </summary>     
        /// <returns>A list of Products</returns>
        public static List<Product> GetProductAvailable()
        {
            List<Product> CopyList = new List<Product>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand("GetMaterial");
                    cmd.Connection = DatabaseAcces.connect;              
                    cmd.CommandType = CommandType.StoredProcedure;
                    //   cmd.CommandText = "SELECT * FROM Copy WHERE EventID IS NULL";
                   // cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["Count"]);
                        int Price = Convert.ToInt32(reader["Price"]);
                        int Count = Convert.ToInt32(reader["Count"]);
                        string Brand = (reader["Brand"].ToString());
                        string Serie = (reader["Serie"].ToString());
                        string Type = (reader["Type"].ToString());
                                          
                                                                
                        // id brand serie typenummer prijs
                        Product Product = new Product(ID,Brand,Serie, Type, Price, Count);
                        CopyList.Add(Product);
                    }
                    return CopyList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());

                }
                finally
                {
                    DatabaseAcces.CloseConnection();
                }
            }
            return CopyList;
        }


    }
}
