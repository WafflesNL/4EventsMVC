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
        public int Barcode { get; set; }

        public Copy(int id, int serialnumber, int barcode)
        {
            this.ID = id;
            this.Serialnumber = serialnumber;
            this.Barcode = barcode;
        }

    }
}