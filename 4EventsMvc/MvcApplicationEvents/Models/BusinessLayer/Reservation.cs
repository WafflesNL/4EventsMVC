using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Reservation
    {
        public Account Account { get; set; }
        public Event Event { get; set; }
        public Person Person { get; set; }
        public Place Place { get; set; }

        public int ID { get; set; }
        public bool paid { get; set; }
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }

        //aanmaken
        public Reservation(DateTime datestart, DateTime dateend, Place place, Account Account, Event Event) //List<Account> accountlist
        {      
            this.Datestart = datestart;
            this.Dateend = dateend;
            this.Place = place;
            this.Account = Account;
            this.Event = Event;
        }

        //ophalen
        //public Reservation(int id, bool paid, DateTime datestart, DateTime dateend, Place place, Person person, List<Account> accountlist)
        //{
        //    this.ID = id;
        //    this.paid = paid;
        //    this.Datestart = datestart;
        //    this.Dateend = dateend;
        //    this.Place = place;
        //    this.Person = person;
        //    //this.AccountList = accountlist;
        //}




        public bool CreateReservation(Reservation Reservation)
        {
            bool check = DatabaseCreateReservation.CreateReservation(Reservation);
            return check;
        }



        public void GetAccounts()
        {
            //vanuit de database
        }


    }
}