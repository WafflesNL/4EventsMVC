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
        public string NR { get; set; }
        public string Postcode { get; set; }
        public string Place { get; set; }


        public Location(int id, string name, string street, string nr, string postcode, string place)
        {
            this.ID = id;
            this.Name = name;
            this.Street = street;
            this.NR = nr;
            this.Postcode = postcode;
            this.Place = place;
        }

        public Location(string name)
        {    
            this.Name = name;   
        }

        public void Getplaces()
        {
          //  this.PlaceList = //datebase
        }

        public void GetlocationID()
        {
            this.ID = DatabaseGetlocation.GetLocationID(this.Name);
        }

    }
}