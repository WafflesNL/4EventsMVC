using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Wristband
    {
        public int ID { get; set; }
        public int Barcode { get; set; }
        public bool Active { get; set; }

        public Wristband(int id, int barcode, bool active)
        {
            this.ID = id;
            this.Barcode = barcode;
            this.Active = active;
        }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }



    }
 }