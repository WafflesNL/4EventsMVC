using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Event
    {
        public List<Reservation> ReservationList = new List<Reservation>();
        public List<Contribution> ContributionList = new List<Contribution>();
        public List<Account> GuestList = new List<Account>();

        public int ID { get; set; } 
        public string Name { get; set; }
        public Location Location { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int MaxVisitors { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Used to add an Event to the database
        /// </summary>
        /// <param name="Name">The name of the event as string<param>
        /// <param name="Description">The description of the event as string</param>
        /// <param name="Location">The location an event takes place as string</param> 
        /// <param name="Maxvisitors">The maximum amount of visitors as int<param>
        /// <param name="Date">The date an event takes place as DateTime</param>
        /// <param name="Account">The account that made the event as Account object</param> 
        /// <param name="MaterialList">A list of material that belongs to this event as List<Material></param> 
        public Event(string Name, Location location, DateTime datestart, DateTime dateend, int maxvisitors, string description)
        {
            this.Name = Name;
            this.Location = location;
            this.DateStart = datestart;
            this.DateEnd = dateend;
            this.MaxVisitors = maxvisitors;
            this.Description = description;
        }

        public Event()
        {
            //nothing
        }

        /// <summary>
        /// Used to get an Event to the database
        /// </summary>
        /// <param name="Name">The name of the event as string<param>
        /// <param name="Description">The description of the event as string</param>
        /// <param name="Location">The location an event takes place as string</param> 
        /// <param name="Maxvisitors">The maximum amount of visitors as int<param>
        /// <param name="Date">The date an event takes place as DateTime</param>
        /// <param name="Account">The account that made the event as Account object</param> 
        /// <param name="MaterialList">A list of material that belongs to this event as List<Material></param> 
        public Event(int id, string Name, Location location, DateTime datestart, DateTime dateend, int maxvisitors, string description, List<Reservation> ReservationList, List<Contribution> ContributionList)
        {
            this.ID = id;
            this.Name = Name;
            this.Location = location;
            this.DateStart = datestart;
            this.DateEnd = dateend;
            this.MaxVisitors = maxvisitors;
            this.Description = description;
            this.ContributionList = ContributionList;
            this.ReservationList = ReservationList;
        }

        /// <summary>
        /// Used to edit a event in the database
        /// </summary>
        /// /// <param name="id">The id of the event as int<param>
        /// <param name="Name">The name of the event as string<param>
        /// <param name="Description">The description of the event as string</param>
        public Event(int id, string Name, string description)
        {
            this.ID = id;
            this.Name = Name;
            this.Description = description;        
        }


        /// <summary>
        /// Creates a new event in the database.
        /// </summary>
        /// <param name="Event">The event to be created as Event object.</param>
        /// <returns>Return true if it was created false if it was not.</returns>
        public bool CreateEvent(Event Event)
        {
            bool Check = DatabaseCreateEvent.CreateEvent(Event);
            return Check;
        }

        /// <summary>
        /// Checks if the changes for Event are allowed in the database
        /// </summary>
        /// <param name="Event">The event to be checked as Event object.</param>
        /// <returns>Returns true if the event is allowed in the database false if it is not</returns>
        public bool EditEvent(Event Event)
        {
            bool Check = DatabaseEditEvent.EditEvent(Event);
            return Check;
        }

        //alle post van huidig event worden hiermee opgehaald
        public bool GetContributions()
        {
            ContributionList = DatabaseGetContribution.GetContributions(ID);
            if (ContributionList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetReservations()
        {
            ReservationList = DatabaseGetReservation.GetReservationEvent(ID);
            if (ReservationList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetGuestList()
        {
            GuestList = DatabaseGetAccount.GetGuest(ID);
            if (ReservationList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool GetGuests()
        //{
        //    ReservationList = DatabaseGetReservation.GetReservationEvent(ID);
        //    if (ReservationList.Count != 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool GetMaterial()
        //{
        //    ReservationList = DatabaseGetReservation.GetReservationEvent(ID);
        //    if (ReservationList.Count != 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //maakt nieuw contribution aan voor huidig event
        public bool CreateContribution(Contribution Contribution)
        {
            if (DatabaseCreateContribution.CreateContribution(Contribution, this.ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckinAccount(string Barcode)
        {
            if (DatabaseEditEvent.checkIn(Barcode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckoutAccount(string barcode)
        {
            if (DatabaseEditEvent.checkOut(barcode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Event GetEventInformationByname()
        {
            Event Event = DatabaseGetEvent.GetEventByName(Name);        
            return Event;
        }

        /// <summary>
        /// Tostring methods for event
        /// </summary>
        /// <returns>Object event to a string</returns>
        public override string ToString()
        {
            return Name;
        }

    }
}