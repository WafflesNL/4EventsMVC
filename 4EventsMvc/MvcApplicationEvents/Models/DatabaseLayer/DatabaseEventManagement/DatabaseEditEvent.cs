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
                    cmd.Parameters.AddWithValue("@ID", Event.DateStart);         

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

        public static bool checkIn(string Barcode, int EventID)
        {
            List<Event> EventList = new List<Event>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "Update ACCOUNT_COUPLING set present = 1 FROM WRISTBAND W join Account_Coupling AC on W.ID = AC.wristbandid join RESERVATION r on ac.reservationid = r.ID where barcode = @Barcode and r.EventID = @EventID";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));
                    cmd.Parameters.Add(new SqlParameter("Barcode", Barcode));
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


        public static bool checkOut(string Barcode, int EventID)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "CheckOut";
                    cmd.Parameters.AddWithValue("@EventID", EventID);
                    cmd.Parameters.AddWithValue("@Barcode", Barcode);

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