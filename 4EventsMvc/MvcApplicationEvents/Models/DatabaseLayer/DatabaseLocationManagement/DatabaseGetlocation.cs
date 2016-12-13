using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetlocation
    {
        public static int GetLocationID(string name)
        {
            int check = 0;

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM LOCATION Where name = @name";
                    cmd.Parameters.Add(new SqlParameter("name", name));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        check = ID; 
                    }
                    return check;
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

            return check;

        }

        public static Location GetLocation(int ID)
        {     

            if (DatabaseAcces.OpenConnection())
            {

                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM LOCATION Where ID = @ID";
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int LocatieID = Convert.ToInt32(reader["ID"]);
                        string name = (reader["name"].ToString()); 
                        string street = (reader["street"].ToString()); 
                        string nr = (reader["nr"].ToString()); 
                        string postcode = (reader["postcode"].ToString()); 
                        string place = (reader["place"].ToString());

                        Location Location = new Location(LocatieID, name, street, nr, postcode, place);
                        return Location;
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