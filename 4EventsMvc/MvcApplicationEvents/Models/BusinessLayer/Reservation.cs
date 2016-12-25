using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Reservation
    {
        public List<Account> AccountList { get; set; }
        public Account Account { get; set; }
        public Event Event { get; set; }
        public Person Person { get; set; }
        public Place Place { get; set; }

        public int ID { get; set; }
        public bool paid { get; set; }
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }

        /// <summary>
        /// creates a rental
        /// </summary>  
        /// <param name="datestart">date start of the reservation<param>
        /// <param name="dateend">date end of the reservation<param
        /// <param name="place">Place that is coupled eith the reservation<param>
        /// <param name="account">person in the reservation<param>
        /// <param name="event">Event that is reserved for<param>
        public Reservation(DateTime datestart, DateTime dateend, Place place, Account Account, Event Event) //List<Account> accountlist
        {      
            this.Datestart = datestart;
            this.Dateend = dateend;
            this.Place = place;
            this.Account = Account;
            this.Event = Event;
        }

        /// <summary>
        /// creates a rental
        /// </summary>  
        /// <param name="datestart">date start of the reservation<param>
        /// <param name="dateend">date end of the reservation<param
        /// <param name="place">Place that is coupled eith the reservation<param>
        /// <param name="account">person in the reservation<param>
        /// <param name="event">Event that is reserved for<param>
        public Reservation(int id, DateTime datestart, DateTime dateend, Place place, Account Account, Event Event) //List<Account> accountlist
        {
            this.ID = id;
            this.Datestart = datestart;
            this.Dateend = dateend;
            this.Place = place;
            this.Account = Account;
            this.Event = Event;
        }

        /// <summary>
        /// creates a rental
        /// </summary>  
        /// <param name="id">Id of the reservation<param>
        /// <param name="paid">true if paid false if not<param>
        /// <param name="datestart">date start of the reservation<param>
        /// <param name="dateend">date end of the reservation<param
        /// <param name="place">Place that is coupled eith the reservation<param>
        /// <param name="person">Payinf Person for the reservation<param>
        /// <param name="Accountlist">Everybody in the reserverstion<param>
        /// <param name="event">Event that is reserved for<param>
        public Reservation(int id, bool paid, DateTime datestart, DateTime dateend, Place place, Person person, List<Account> accountlist, Event Event)
        {
            this.ID = id;
            this.paid = paid;
            this.Datestart = datestart;
            this.Dateend = dateend;
            this.Place = place;
            this.Person = person;
            this.AccountList = accountlist;
            this.Event = Event;
        }

        /// <summary>
        /// Creates a new reservation in the database.
        /// </summary>
        /// <param name="reservation">The reservation to be created as Event object.</param>
        /// <returns>Return true if it was created false if it was not.</returns>
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