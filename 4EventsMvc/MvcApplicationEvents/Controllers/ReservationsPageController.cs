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
            ViewBag.Place = "geen Plek geselecteerd";
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
                Event Event2 = Event.GetEventInformationByname();
                Event2.GetLocation();
                Event2.Location.Getplaces();
                ViewBag.Place = "geen Plek geselecteerd";
                return View("ReservationsPage", Event2); //moet nog fouten afhandeling in
            }       
        }

        public ActionResult Sort(int DM, string GOK, Event Event)
        {       
                Event Event2 = Event.GetEventInformationByname();
                Event2.GetLocation();
                Event2.Location.Getplaces();

                foreach (Place P in Event2.Location.PlaceList)
                {
                    if (GOK == "Kleiner dan")
                    {
                        if (P.Capacity < DM)
                        {
                            P.GrayOut();
                        }
                    }
                    else if (GOK == "Groter dan")
                    {
                        if (P.Capacity > DM)
                        {
                            P.GrayOut();
                        }
                    }
                }

                ViewBag.title = "geen Plek geselecteerd";

                return View("ReservationsPage", Event2);              
        }


        public ActionResult Free(DateTime datestart, DateTime dateend, Event Event)
        {
            Event Event2 = Event.GetEventInformationByname();
            Event2.GetLocation();
            Event2.Location.Getplaces();



            return View("ReservationsPage", Event2);
        }


    }
}