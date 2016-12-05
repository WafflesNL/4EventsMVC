using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string HomeNr { get; set; }
        public string Place { get; set; }
        public int BankNr { get; set; }

        public Person(string name, string street, string homenr, string place, int banknr)
        {
            this.Name = name;
            this.Street = street;
            this.HomeNr = homenr;
            this.Place = place;
            this.BankNr = banknr;
        }



    }
}