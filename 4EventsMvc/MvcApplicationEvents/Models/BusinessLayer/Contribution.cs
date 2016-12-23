using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationEvents.Models
{
    public class Contribution
    {

        public int ID { get; set; }
        public int ContributionID { get; set; }
        public DateTime DateTime { get; set; }    
        public string Category { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }    
        public int PostID { get; set; }
        public byte[] File { get; set; }
        public string Attachment { get; set; }
        public Message Message { get; set; }
        public bool IsSelected { get; set; }
        public int AccountID { get; set; }

        /// <summary>
        /// Create Constructor
        /// </summary> 
        /// <param name="category">The category of a post</param>    
        /// <param name="likes">The amount of likes of a post</param> 
        /// <param name="file">The file belonging to the post</param>
        /// <param name="postID">This is the ID of the post reacted to</param>
        public Contribution(DateTime datetime, string category, int likes, int reports, int postid, Message message, int accountid)
        {           
            this.Category = category;    
            this.Likes = likes;
            this.Reports = reports;
            this.PostID = postid;
            this.DateTime = datetime;
            this.Message = message;
            this.AccountID = accountid;
        }

        /// <summary>
        /// Get Constructor
        /// </summary> 
        /// <param name="ID">ID of the post</param>  
        /// <param name="category">The category of a post</param>    
        /// <param name="likes">The amount of likes of a post</param> 
        /// <param name="Reports">The amount of reports of a post</param>  
        /// <param name="postID">This is the ID of the post reacted to</param>
        /// <param name="file">The file belonging to the post</param>
        /// <param name="Message">This is the ID of the post reacted to</param>
        public Contribution(int id, DateTime datetime, string category, int likes, int reports, int postid, byte[] file, Message message, string attachment, bool isselected)
        {
            this.ID = id;
            this.Category = category;
            this.Likes = likes;
            this.Reports = reports;
            this.PostID = postid;
            this.File = file;
            this.Message = message;
            this.Attachment = attachment;
            this.DateTime = datetime;
            this.IsSelected = isselected;
        }

        public Contribution(int id)
        {
            this.ID = id;
        }

        public Contribution(Message message)
        {
            this.Message = message;
        }

        public bool likePost()
        {
            if (DatabaseEditContribution.LikePost(ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReportPost()
        {
            if (DatabaseEditContribution.ReportPost(ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void AddReply(int ContributionID)
        {
            this.ContributionID = ContributionID;
        }

        public void AddFile(byte[] file)
        {
            this.File = file;
        }

        public void AddMessage(Contribution Contrib)
        {
            DatabaseCreateContribution.CreateContribution(Contrib, 1);
        }


        /// <summary>
        /// Used to get/add posts to the Data Access Layer
        /// </summary>
        /// <returns>ToString method to write to the listbox</returns>
        public override string ToString()
        {
            return base.ToString();
        }






    }
}