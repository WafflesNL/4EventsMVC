﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Contribution
    {

        public int ID { get; set; }
        public DateTime DateTime { get; set; }    
        public string Category { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }    
        public int PostID { get; set; }

        public File File { get; set; }
        public Message Message { get; set; }

   
        /// <summary>
        /// Create Constructor
        /// </summary> 
        /// <param name="category">The category of a post</param>    
        /// <param name="likes">The amount of likes of a post</param> 
        /// <param name="file">The file belonging to the post</param>
        /// <param name="postID">This is the ID of the post reacted to</param>
        public Contribution(DateTime datetime, string category, int likes, int reports, int postid)
        {           
            this.Category = category;    
            this.Likes = likes;
            this.Reports = reports;
            this.PostID = postid;
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
        public Contribution(int id, DateTime datetime, string category, int likes, int reports, int postid, File file, Message message)
        {
            this.ID = id;
            this.Category = category;
            this.Likes = likes;
            this.Reports = reports;
            this.PostID = postid;
            this.File = file;
            this.Message = message;
        }

        public bool CreateContribution(Contribution Contribution)
        {
            //if (DatabaseCreateContribution.somemethod(Contribution))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
         
        }

        public void AddFile(File file)
        {
            this.File = file;
        }

        public void AddMessage(Message message)
        {
            this.Message = message;
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