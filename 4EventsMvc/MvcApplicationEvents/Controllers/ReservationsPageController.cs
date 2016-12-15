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
        public ActionResult ReservationsPage()
        {
            List<Place> placelist = new List<Place>();
            for (int i = 0; i < 12; i++)
            {
                placelist.Add(new Place(1, 5, 10, false));
            }
            return View();
        }

        //hiermee maakt gebruiker nieuwe reservering mee aan
        public ActionResult btnCreateReservation()
        {




            return View();
        }

    }
}