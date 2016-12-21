﻿using System;
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
            List<Place> placelist = new List<Place>();
            for (int i = 0; i < 40; i++)
            {
                placelist.Add(new Place(1, 5, 10, false));
            }
            return View(placelist);
        }

        //public ActionResult SeePlace(Place Place)
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