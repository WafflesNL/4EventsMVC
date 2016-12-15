using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseCreateReservation
    {
        public static bool CreateReservation(Reservation Reservation)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "CreateReservation";
                    cmd.Parameters.AddWithValue("@PlaceID", Reservation.Place.ID);
                    cmd.Parameters.AddWithValue("@EventID", Reservation.Event.ID);
                    cmd.Parameters.AddWithValue("@datestart", Reservation.Datestart);
                    cmd.Parameters.AddWithValue("@dateend", Reservation.Dateend);
                    cmd.Parameters.AddWithValue("@accountID", Reservation.Account.ID);
               
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