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

        public Place(int id, int capacity, int number, bool reserved)
        {
            this.ID = id;
            this.Capacity = capacity;
            this.Number = number;
            this.Reserved = reserved;
        }



    }
}