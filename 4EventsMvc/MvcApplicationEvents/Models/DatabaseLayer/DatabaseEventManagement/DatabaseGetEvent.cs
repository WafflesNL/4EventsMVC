using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetEvent
    {
       
        public static List<Event> GetEvents()
        {
            List<Event> EventList = new List<Event>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Event";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        string Name = (reader["name"].ToString());
                        int LocationID = (reader["locationid"] != DBNull.Value) ? Convert.ToInt32(reader["locationid"]) : 0;
                        Location Location = DatabaseGetlocation.GetLocation(LocationID);
                        DateTime Datestart = Convert.ToDateTime(reader["datestart"]); 
                        DateTime Dateend = Convert.ToDateTime(reader["dateend"]);
                        int Maxvisitors = Convert.ToInt32(reader["maxVisitors"]);
                        string Description = (reader["description"].ToString()); 
                  
                        List<Reservation> ReservationList = null;    //kan ook worden opgehaald met het eventID            
                        List<Contribution> ContributionList = null;

                        Event Event = new Event(ID, Name, Location, Datestart, Dateend, Maxvisitors, Description, ReservationList, ContributionList );
                        EventList.Add(Event);
                    }
                    return EventList;
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
            return EventList;
        }

        public static Event GetEventByID(int EventID)
        {

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "Select * From Event Where id = @EventID";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {                    
                        string name = (reader["name"].ToString()); 
                        DateTime datestart = Convert.ToDateTime(reader["datestart"].ToString()); 
                        DateTime dateend = Convert.ToDateTime(reader["dateend"].ToString());
                        int maxvisitors = Convert.ToInt32(reader["maxvisitors"]); ;
                        string description = (reader["description"].ToString()); 

                        Event Event = new Event(name, null, datestart, dateend, maxvisitors, description);
                        return Event;
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


