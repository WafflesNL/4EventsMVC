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
        Event Event;
        // GET: ReservationsPage
        public ActionResult ReservationsPage(Event Event)
        {
            Event.GetLocation();
            Event.Location.Getplaces();
            return View(Event);
        }

        //public ActionResult SeePlace(Place Place, string EventName)
        //{



        //    ViewBag.Place = Place.Number;




        //    return View("", );
        //}

        //hiermee maakt gebruiker nieuwe reservering mee aan
        public ActionResult btnCreateReservation(Event Event, Place Place, DateTime dateStart, DateTime dateend)
        {
            //dit moet nog getest worden met data passen

            Account Account = new Account(CurrentAccount.ID, CurrentAccount.Username, CurrentAccount.Password);        
            Reservation Reservation = new Reservation(dateStart, dateend, Place ,Account ,Event);      
            if (Reservation.CreateReservation(Reservation))
            {
                return View();
            }
            else
            {
                return View(); //moet nog fouten afhandeling in
            }
           
        }

    }
}