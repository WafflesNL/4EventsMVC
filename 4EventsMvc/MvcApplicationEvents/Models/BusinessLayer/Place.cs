using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Place
    {
        public int ID { get; set; }
        public int Capacity { get; set; }
        public int Number { get; set; }
        public bool Reserved { get; set; }
        public bool GrayedOut { get; set; } = false;

        /// <summary>
        /// creates a place
        /// </summary>
        /// <param name="id">ID of the place<param>
        /// <param name="capacity">amount of space in dm²<param>
        /// <param name="number">number of the place<param>
        /// <param name="reserved">false if place is reserved true if not<param>  
        public Place(int id, int capacity, int number, bool reserved)
        {
            this.ID = id;
            this.Capacity = capacity;
            this.Number = number;
            this.Reserved = reserved;
        }

        public Place(int id, int number)
        {
            this.ID = id;
            this.Number = number;          
        }

        public Place()
        {

        }

        public bool GetID(int Number, int EventID)
        {
            Place place = DatabaseGetPlace.GetPlaceinformation(Number, EventID);
            if (place != null)
            {
                this.ID = place.ID;
                this.Number = place.Number;
                this.Capacity = place.Capacity;
                return true;
            }
            else
            {
                return false;
            }

        }

        public void GrayOut()
        {
            this.GrayedOut = true;
        }


    }
}