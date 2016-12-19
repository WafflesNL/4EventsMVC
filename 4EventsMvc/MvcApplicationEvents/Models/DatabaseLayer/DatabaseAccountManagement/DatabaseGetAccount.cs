using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetAccount
    {
        public static Account GetUserIDPassword(string Username)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "SELECT * FROM Account Where username = @Username";
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.Add(new SqlParameter("Username", Username));

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        string Password = (reader["Password"].ToString());
                        return new Account(ID, Username, Password);
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

        public static List<Account> GetAccountsInReservation(int ReservationID)
        {
            List<Account> AccountList = new List<Account>();

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
                        string Username = (reader["username"].ToString());
                        string Password = (reader["password"].ToString());


                        Account Account = new Account(ID, Username, Password);
                        AccountList.Add(Account);
                    }

                    return AccountList;

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

        public static List<Account> GetGuest(int EventID)
        {
            List<Account> AccountList = new List<Account>();

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandText = "select * from ACCOUNT a join ACCOUNT_COUPLING ac on a.ID = ac.accountid join RESERVATION r on ac.reservationid = r.ID join EVENT e on r.EventID = e.ID where ac.present = 1 and e.ID = @EventID";
                    cmd.Parameters.Add(new SqlParameter("EventID", EventID));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        string Username = (reader["username"].ToString());
                        string Password = (reader["password"].ToString());

                        Account Account = new Account(ID, Username, Password);
                        AccountList.Add(Account);
                    }

                    return AccountList;

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