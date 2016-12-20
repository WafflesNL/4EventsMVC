using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Copy
    {
        public int ID { get; set; }
        public int Serialnumber { get; set; }
        public string Barcode { get; set; }

        public Copy(int id, int serialnumber, string barcode)
        {
            this.ID = id;
            this.Serialnumber = serialnumber;
            this.Barcode = barcode;     
        }

        

    }
}