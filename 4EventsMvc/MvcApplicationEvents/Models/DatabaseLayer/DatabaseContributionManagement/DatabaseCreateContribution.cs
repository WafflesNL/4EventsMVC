using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseCreateContribution
    {
        public static bool CreateContribution(Contribution Contribution, int EventID)
        {
            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "CreatePost";
                    cmd.Parameters.AddWithValue("@Date", Contribution.DateTime);
                    cmd.Parameters.AddWithValue("@Category", Contribution.Category);
                    cmd.Parameters.AddWithValue("@Content", Contribution.Message.Content);
                    cmd.Parameters.AddWithValue("@Title", Contribution.Message.Title);
                    //cmd.Parameters.AddWithValue("@File", Contribution.File);
                    cmd.Parameters.AddWithValue("@ContributionID", Contribution.ContributionID);
                    cmd.Parameters.AddWithValue("@EventID", EventID);
                    cmd.Parameters.AddWithValue("@AccountID", CurrentAccount.ID);

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