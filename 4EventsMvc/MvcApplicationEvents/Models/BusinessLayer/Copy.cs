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


        /// <summary>
        /// Costructor to get a copy
        /// </summary>
        /// <param name="id">ID number</param>
        /// <param name="Serialnumber">serial (ID) number</param>
        /// <param name="barcode">Barcode of a copy string<param> 
        public Copy(int id, int serialnumber, string barcode)
        {
            this.ID = id;
            this.Serialnumber = serialnumber;
            this.Barcode = barcode;     
        }

        

    }
}