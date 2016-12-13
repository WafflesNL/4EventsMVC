using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Models
{
    public static class DatabaseGetContribution
    {
        public static List<Contribution> GetContributions(int EventID)
        {
            //List<Contribution> ContributionList = new List<Contribution>();
            //byte[] File;
            //string Attachment;

            //if (DatabaseAcces.OpenConnection())
            //{
            //    try
            //    {
            //        DatabaseAcces.OpenConnection();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = DatabaseAcces.connect;

            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.CommandText = "GetPosts";

            //        SqlDataReader reader = cmd.ExecuteReader();

            //        while (reader.Read())
            //        {              
            //            int ID = Convert.ToInt32(reader["ID"]);
            //            int contributionid = Convert.ToInt32(reader["ID"]);
            //            int accountid = Convert.ToInt32(reader["ID"]);
            //            int likes = Convert.ToInt32(reader["ID"]);
            //            int reports = Convert.ToInt32(reader["ID"]);

            //            DateTime date = Convert.ToDateTime(reader["ID"]);                     
            //            string category = (reader["ID"].ToString());
            //            string title = (reader["ID"].ToString());
            //            string content = (reader["ID"].ToString());
            //            if (reader["File"] != DBNull.Value)
            //            {
            //                Attachment = "Bijlage";
            //                File = (byte[])reader["File"];
            //            }
            //            else
            //            {
            //                Attachment = "None";
            //                File = null;
            //            }

            //            Contribution contribution = new Contribution(ID, date, category , ,, );
            //            ContributionList.Add(contribution);
            //        }



            //        return ContributionList;
            //    }
            //    catch (SqlException e)
            //    {
            //        Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
            //    }
            //    finally
            //    {
            //        DatabaseAcces.CloseConnection();
            //    }

            //}
            return null; ;
        }
    }
}