using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseCheckWristband
    {
        public static void ChangePresentStatus(string barcode)
        {
        
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand("CheckInOut");
                    cmd.Connection = DatabaseAcces.connect;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcode;

                    cmd.ExecuteNonQuery();
                
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




        }
    }
}

    
