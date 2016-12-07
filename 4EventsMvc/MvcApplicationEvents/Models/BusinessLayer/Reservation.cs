using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Reservation
    {
        List<Account> AccountList = new List<Account>();

        public Person Person { get; set; }
        public Place Place { get; set; }

        public int ID { get; set; }
        public bool paid { get; set; }
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }

        //aanmaken
        public Reservation(bool paid, DateTime datestart, DateTime dateend, Place place, Person person, List<Account> accountlist)
        {    
            this.paid = paid;
            this.Datestart = datestart;
            this.Dateend = dateend;
            this.Place = place;
            this.Person = person;
            this.AccountList = accountlist;
        }

        //ophalen
        public Reservation(int id, bool paid, DateTime datestart, DateTime dateend, Place place, Person person, List<Account> accountlist)
        {
            this.ID = id;
            this.paid = paid;
            this.Datestart = datestart;
            this.Dateend = dateend;
            this.Place = place;
            this.Person = person;
            this.AccountList = accountlist;
        }

        public void GetAccounts()
        {
            //vanuit de database
        }


    }
}