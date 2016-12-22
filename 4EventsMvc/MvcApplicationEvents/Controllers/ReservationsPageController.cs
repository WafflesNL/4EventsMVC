using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class ReservationsPageController : Controller
    {
        // GET: ReservationsPage
        public ActionResult ReservationsPage(Event Event)
        {
            ViewBag.Place = "nog niets geselecteerd";
            Event.GetLocation();
            Event.Location.Getplaces();
            return View(Event);
        }

        public ActionResult SeePlace(string EventName, Place Place)
        {
            Event Event = new Event();
            Event.Name = EventName;
            Event Event2 = Event.GetEventInformationByname();
            Event2.GetLocation();
            Event2.Location.Getplaces();

            ViewBag.Place = Place.Number;

            return View("ReservationsPage", Event2);
        }


        //hiermee maakt gebruiker nieuwe reservering mee aan
        public ActionResult btnCreateReservation(Event Event, int PlaceNumber, DateTime EventDatestart, DateTime EventDateend)
        {
            Place Place = new Place();        
            Place.GetID(PlaceNumber, Event.ID);

            Account Account = new Account(CurrentAccount.ID, CurrentAccount.Username, CurrentAccount.Password);
            Reservation Reservation = new Reservation(EventDatestart, EventDateend, Place, Account, Event);
            if (Reservation.CreateReservation(Reservation))
            {
                return RedirectToAction("Home","Home");
            }
            else
            {
                return View(); //moet nog fouten afhandeling in
            }

     
           
        }

    }
}