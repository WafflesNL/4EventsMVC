using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Location
    {
        //test
        List<Place> PlaceList = new List<Place>();

        public int ID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int NR { get; set; }
        public string Postcode { get; set; }
        public string Place { get; set; }


        public Location(int id, string name, string street, int nr, string postcode, string place)
        {
            this.ID = id;
            this.Name = name;
            this.Street = street;
            this.NR = nr;
            this.Postcode = postcode;
            this.Place = place;
        }

        public void Getplaces()
        {
          //  this.PlaceList = //datebase
        }

    }
}