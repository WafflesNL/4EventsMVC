using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetReservation
    {
        public static List<Reservation> GetReservationEvent(int EventID)
        {
            List<Reservation> ReservationList = new List<Reservation>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;


                    cmd.CommandText = "select * from RESERVATION r where r.EventID = @EventID";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        DateTime datestart = Convert.ToDateTime(reader["datestart"]);
                        DateTime dateend = Convert.ToDateTime(reader["dateend"]);
                        bool Paid = Convert.ToBoolean(reader["paid"]);

                        Place Place = DatabaseGetPlace.GetPlaceByReservation(ID);
                        Event Event = DatabaseGetEvent.GetEventByID(EventID);
                        Account Account = DatabaseGetAccount.GetAccountsInReservation(ID);

                        Reservation Reservation = new Reservation(ID, datestart, dateend, Place, Account, Event);                      
                        ReservationList.Add(Reservation);
                    }

                    return ReservationList;
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