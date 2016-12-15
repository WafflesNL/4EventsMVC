using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetAccount
    {
        public static Account GetUserIDPassword(string Username)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Account Where username = @Username";
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.Add(new SqlParameter("Username", Username));

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        string Password = (reader["Password"].ToString());
                        return new Account(ID, Username, Password);
                    }                   
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
            return null;
        }
    }
}