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

        public File(string filelocation, int size)
        {
            this.FileLocation = filelocation;
            this.Size = size;
        }
    }
}