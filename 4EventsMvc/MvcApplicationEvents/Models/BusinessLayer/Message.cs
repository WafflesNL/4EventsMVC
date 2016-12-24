using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Message
    {
        public string Title { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// creates a message
        /// </summary>
        /// <param name="title">title of the post or message<param>
        /// <param name="content">text that the user wants to post<param>
        public Message(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

    }
}