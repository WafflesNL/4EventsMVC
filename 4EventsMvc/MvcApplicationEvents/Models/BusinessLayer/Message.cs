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

        public Message(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

    }
}