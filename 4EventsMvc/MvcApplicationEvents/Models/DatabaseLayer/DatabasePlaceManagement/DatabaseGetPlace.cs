using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetPlace
    {
        public static List<Place> GetPlaces(int LocationID)
        {

            List<Place> PlaceList = new List<Place>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "Select * From Place Where Locationid = @LocationID";
                    cmd.Parameters.Add(new SqlParameter("LocationID", LocationID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int capacity = Convert.ToInt32(reader["capacity"]);
                        int number = Convert.ToInt32(reader["number"]);
                        //bool reserved = Convert.ToBoolean(reader["paid"]);

                        Place Place = new Place(ID, capacity, number, false);
                        PlaceList.Add(Place);
                    }

                    return PlaceList;


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

        public static Place GetPlaceByReservation(int ReservationID)
        {
            //List<Place> PlaceList = new List<Place>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "select * from Place p Join Reservation_Place rp ON p.id = rp.Placeid WHERE rp.ReservationID = @ReservationID";
                    cmd.Parameters.Add(new SqlParameter("ReservationID", ReservationID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int capacity = Convert.ToInt32(reader["capacity"]);
                        int number = Convert.ToInt32(reader["number"]);
                        //bool reserved = Convert.ToBoolean(reader["paid"]);

                        Place Place = new Place(ID, capacity, number, false);
                        return Place;
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

        public static Place GetPlaceinformation(int number, int eventID)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "select * from place p join LOCATION l on p.locationid = l.ID join Event E on l.ID = E.locationid where number = @number and e.ID = @EventID";
                    cmd.Parameters.Add(new SqlParameter("@number", number));
                    cmd.Parameters.Add(new SqlParameter("EventID", eventID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int capacity = Convert.ToInt32(reader["capacity"]);
                     
                        //bool reserved = Convert.ToBoolean(reader["paid"]);
                        Place Place = new Place(ID, capacity, number, false);
                        return Place;
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