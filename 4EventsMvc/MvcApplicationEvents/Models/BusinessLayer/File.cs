using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class File
    {
        public string FileLocation { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// creates a new file
        /// </summary>
        /// <param name="filelocation">location where the file currently is</param>
        /// <param name="size">Amount of mb's a file takes up</param>
        public File(string filelocation, int size)
        {
            this.FileLocation = filelocation;
            this.Size = size;
        }
    }
}