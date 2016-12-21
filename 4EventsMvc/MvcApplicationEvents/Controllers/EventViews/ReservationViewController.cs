using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class ReservationViewController : Controller
    {
        // GET: ReservationView
        public ActionResult ReservationView(Event ParameterEvent)
        {
            ParameterEvent.GetReservations();
            List<Reservation> ReservationList = ParameterEvent.ReservationList;

            return View(ReservationList);
        }

  
    }
}