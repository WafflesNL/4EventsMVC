using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Location
    {
        //test
        public List<Place> PlaceList = new List<Place>();

        public int ID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string NR { get; set; }
        public string Postcode { get; set; }
        public string Place { get; set; }

        /// <summary>
        /// Used to create a location
        /// </summary>
        /// <param name="id">id number of the location<param>
        /// <param name="name">name of the location</param>
        /// <param name="street">street of the location</param> 
        /// <param name="nr">house or location nummer of the location<param>
        /// <param name="postcode">postcode in string</param>
        /// <param name="place">name of a city or village</param> 
        public Location(int id, string name, string street, string nr, string postcode, string place)
        {
            this.ID = id;
            this.Name = name;
            this.Street = street;
            this.NR = nr;
            this.Postcode = postcode;
            this.Place = place;
        }

        /// <summary>
        /// Used to create a location
        /// </summary>
        /// <param name="name">name of the location</param>
        public Location(string name)
        {    
            this.Name = name;   
        }

        /// <summary>
        /// Gets all places of the event location
        /// </summary>
        /// <returns>Return true if it was created false if it was not.</returns>
        public bool Getplaces()
        {     
            PlaceList = DatabaseGetPlace.GetPlaces(ID);
            if (PlaceList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets current locationID by name
        /// </summary>
        public void GetlocationID()
        {
            this.ID = DatabaseGetlocation.GetLocationID(this.Name);
        }

    }
}