using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseCreateEvent
    {
        public static bool CreateEvent(Event Event)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "CreateEvent"; 
                    cmd.Parameters.AddWithValue("@name", Event.Name); 
                    cmd.Parameters.AddWithValue("@description", Event.Description);
                    cmd.Parameters.AddWithValue("@dateStart", Event.DateStart);
                    cmd.Parameters.AddWithValue("@dateEnd", Event.DateEnd);
                    cmd.Parameters.AddWithValue("@Maxvisitors", Event.MaxVisitors);
                    cmd.Parameters.AddWithValue("@locationID", Event.Location.ID);

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
            return false;



        }
    }
}