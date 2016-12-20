using System;
using System.Collections.Generic;
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
        public static List<Product> GetProductforEvent(int EventID)
        {
            List<Product> ProductList = new List<Product>();

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Materiaal WHERE EventID = @EventID";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int Price = Convert.ToInt32(reader["Price"]);
                        int Typenumber = Convert.ToInt32(reader["Typenumber"].ToString());
                        string Serie = (reader["Serie"].ToString());
                        string Brand = (reader["Brand"].ToString());
                        int? eventid = (reader["EventID"] != DBNull.Value) ? Convert.ToInt32(reader["EventID"]) : 0;
                        int? accountID = (reader["AccountID"] != DBNull.Value) ? Convert.ToInt32(reader["AccountID"]) : 0;
                        if (eventid == 0)
                        {
                            eventid = null;
                        }
                        if (accountID == 0)
                        {
                            accountID = null;
                        }


                        Product Product = new Product(ID, Brand, Serie, Typenumber, Price);
                        ProductList.Add(Product);
                    }
                    return ProductList;
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
            return ProductList;
        }

        public static List<Product> GetProductforEventNoAccount(int EventID)
        {
            List<Product> ProductList = new List<Product>();

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Materiaal WHERE EventID = @EventID AND AccountID IS NULL";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int Price = Convert.ToInt32(reader["Price"]);
                        int Typenumber = Convert.ToInt32(reader["Typenumber"].ToString());
                        string Serie = (reader["Serie"].ToString());
                        string Brand = (reader["Brand"].ToString());
                        int? eventid = (reader["EventID"] != DBNull.Value) ? Convert.ToInt32(reader["EventID"]) : 0;
                        int? accountID = (reader["AccountID"] != DBNull.Value) ? Convert.ToInt32(reader["AccountID"]) : 0;
                        if (eventid == 0)
                        {
                            eventid = null;
                        }
                        if (accountID == 0)
                        {
                            accountID = null;
                        }


                        Product Product = new Product(ID, Brand, Serie, Typenumber, Price);
                        ProductList.Add(Product);
                    }
                    return ProductList;
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
            return ProductList;
        }

        public static List<Product> GetProductforAccountonEvent(int EventID, int AccountID)
        {
            List<Product> ProductList = new List<Product>();

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Materiaal WHERE EventID = @EventID AND AccountID = @AccountID";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));
                    cmd.Parameters.Add(new SqlParameter("AccountID", AccountID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int Price = Convert.ToInt32(reader["Price"]);
                        int Typenumber = Convert.ToInt32(reader["Typenumber"].ToString());
                        string Serie = (reader["Serie"].ToString());
                        string Brand = (reader["Brand"].ToString());
                        int? eventid = (reader["EventID"] != DBNull.Value) ? Convert.ToInt32(reader["EventID"]) : 0;
                        int? accountID = (reader["AccountID"] != DBNull.Value) ? Convert.ToInt32(reader["AccountID"]) : 0;
                        if (eventid == 0)
                        {
                            eventid = null;
                        }
                        if (accountID == 0)
                        {
                            accountID = null;
                        }


                        Product Product = new Product(ID, Brand, Serie, Typenumber, Price);
                        ProductList.Add(Product);
                    }
                    return ProductList;
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
            return ProductList;
        }
        /// <summary>
        /// Gets a Products that haven't been linked to an event yet
        /// </summary>     
        /// <returns>A list of Products</returns>
        public static List<Product> GetProductAvailable()
        {
            List<Product> ProductList = new List<Product>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Materiaal WHERE EventID IS NULL";
                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int Price = Convert.ToInt32(reader["Price"]);
                        int Typenumber = Convert.ToInt32(reader["Typenumber"].ToString());
                        string Serie = (reader["Serie"].ToString());
                        string Brand = (reader["Brand"].ToString());
                        int? eventid = (reader["EventID"] != DBNull.Value) ? Convert.ToInt32(reader["EventID"]) : 0;
                        int? accountID = (reader["AccountID"] != DBNull.Value) ? Convert.ToInt32(reader["AccountID"]) : 0;
                        if (eventid == 0)
                        {
                            eventid = null;
                        }
                        if (accountID == 0)
                        {
                            accountID = null;
                        }
                       
                        // id brand serie typenummer prijs
                        Product Product = new Product(ID, Brand, Serie, Typenumber, Price);
                        ProductList.Add(Product);
                    }
                    return ProductList;
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
            return ProductList;
        }


    }
}
