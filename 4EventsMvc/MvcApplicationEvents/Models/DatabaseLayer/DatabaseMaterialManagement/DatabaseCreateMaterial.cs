using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseCreateMaterial
    {
        public static bool CreateRental(List<Product> id, string Barcode)
        {
           if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CreateRental";

                    using (var table = new DataTable())
                    {
                        table.Columns.Add("ID", typeof(int));
                        table.Columns.Add("Aantal", typeof(int));

                        for (int i = 0; i < id.Count; i++)
                        {
                            table.Rows.Add(id[i].ID, id[i].Aantal);
                        }

                        var pList = new SqlParameter("@ProductList", SqlDbType.Structured);
                        cmd.Parameters.AddWithValue("@Barcode", Barcode); //voor klantID door te geven
                        pList.TypeName = "dbo.IntList";
                        pList.Value = table;
                        cmd.Parameters.Add(pList);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                    return false;
                }
                finally
                {
                    DatabaseAcces.CloseConnection();
                }
            }
            return true;
        }
        public static bool ReturnItems(string Barcode)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ReturnProduct";
                    cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = Barcode;
                    cmd.ExecuteNonQuery();                                   
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                    return false;
                }
                finally
                {
                    DatabaseAcces.CloseConnection();
                }
            }
            return true;
        }
    }
}