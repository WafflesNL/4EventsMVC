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

        /// <summary>
        /// creates a wrsitband
        /// </summary>  
        public Wristband()
        {
        }

        /// <summary>
        /// creates a wrsitband
        /// </summary>  
        /// <param name="id">Id of the wristband<param>
        /// <param name="barcode">Barcode of the wristband<param>
        /// <param name="active">true if active false if not<param>
        public Wristband(int id, int barcode, bool active)
        {
            this.ID = id;
            this.Barcode = barcode;
            this.Active = active;
        }

        /// <summary>
        /// Activate or deactives a wristband
        /// </summary>
        /// <param name="barcode">The event to be created as Event object.</param>
        public void Activate(string barcode)
        {
            DatabaseCheckWristband.ChangePresentStatus(barcode);
            Active = true;
        }

     //   public bool Deactivate(string barcode)
     //   {
     //       Active = false;
     //       return Active;
     //   }



    }
 }