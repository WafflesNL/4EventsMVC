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
            List<Contribution> ContributionList = new List<Contribution>();
            byte[] File;
            string Attachment;

            if (DatabaseAcces.OpenConnection())
            {
                try
                {
                    DatabaseAcces.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DatabaseAcces.connect;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "GetPosts";
                    cmd.Parameters.AddWithValue("@EventID", EventID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["ID"]);
                        int contributionid = Convert.ToInt32(reader["contributionid"]);
                        int accountid = Convert.ToInt32(reader["accountid"]);
                        int likes = Convert.ToInt32(reader["likes"]);
                        int reports = Convert.ToInt32(reader["reports"]);

                        DateTime date = Convert.ToDateTime(reader["date"]);
                        string category = (reader["category"].ToString());
                        string title = (reader["title"].ToString());
                        string content = (reader["content"].ToString());
                        if (reader["Image"] != DBNull.Value)
                        {
                            Attachment = "Bijlage";
                            File = (byte[])reader["Image"];
                        }
                        else
                        {
                            Attachment = "None";
                            File = null;
                        }

                        Contribution contribution = new Contribution(ID, date, category, likes , reports, contributionid, File, new Message(title, content), Attachment);            
                        ContributionList.Add(contribution);
                    }



                    return ContributionList;
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
            return null; ;
        }
    }
}