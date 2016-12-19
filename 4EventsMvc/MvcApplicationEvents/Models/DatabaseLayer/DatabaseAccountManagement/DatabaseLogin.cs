using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models.DatabaseLayer.DatabaseAccountManagement
{
    public class DatabaseLogin
    {
        public static Account CheckUser(string Password, string Username)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT ID , Username, Password FROM Account Where username = @Username AND password = @Password";


                    
                    cmd.Parameters.Add(new SqlParameter("Password", Password));
                    cmd.Parameters.Add(new SqlParameter("Username", Username));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        string user = (reader["Username"].ToString());
                        string password = (reader["Password"].ToString());
                        Account account = new Account(ID, user, password);
                        return account;
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