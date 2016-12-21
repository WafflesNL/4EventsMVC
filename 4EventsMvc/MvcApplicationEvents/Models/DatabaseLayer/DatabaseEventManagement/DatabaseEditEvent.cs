using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseEditEvent
    {
        public static bool EditEvent(Event Event)
        {
            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "EditEvent";
                    cmd.Parameters.AddWithValue("@Name", Event.Name);
                    cmd.Parameters.AddWithValue("@Description", Event.Description);
                    cmd.Parameters.AddWithValue("@ID", Event.ID);         

                    cmd.ExecuteNonQuery();

                    return true;                 
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

            return false ;

        }

        public static bool checkIn(string Barcode)
        {


            return true;
        }

        public static bool checkOut(string Barcode)
        {


            return true;
        }
    }
}