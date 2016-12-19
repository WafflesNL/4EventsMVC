using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseAcces
    {
        public static SqlConnection connect { get; set; } //database static

        /// <summary>
        /// Check if database connection is open
        /// </summary>
        /// <returns>True if open false if closed</returns>
        public static bool OpenConnection()
        {
            connect = new SqlConnection();

            try
            {
                connect.ConnectionString =
                    // "Data Source=mssql.fhict.local;Initial Catalog=dbi336545;User ID=dbi336545;Password=Fontysproject"; 
                    "Server=4EVENTSDATABASE;Database=4Events;User ID=4Events;Password=Password1";
                //  "Server=4EVENTSDATABASE;Database=4EVENTSDATABASE;User ID=4Events;Password=Password1";

                connect.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            if (connect.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Close database connection
        /// </summary>
        /// <returns>True if connection is closed false if not</returns>
        public static void CloseConnection()
        {
            connect.Close();
        }
    }
}