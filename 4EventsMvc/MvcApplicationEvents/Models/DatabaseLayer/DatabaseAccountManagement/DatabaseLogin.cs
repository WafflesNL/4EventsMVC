using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models.DatabaseLayer.DatabaseAccountManagement
{
    public class DatabaseLogin
    {
        public static Account CheckUser(string Username, string Password)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Account Where username = @Username AND password = @Password";

                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.Add(new SqlParameter("Password", Password));
                    cmd.Parameters.Add(new SqlParameter("Username", Username));

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        string user = (reader["Username"].ToString());
                        string password = (reader["Password"].ToString());
                        return new Account(ID, user, password);
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                    return null;
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