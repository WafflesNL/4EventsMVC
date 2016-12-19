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
        public ActionResult ReservationView()
        {
            return View();
        }

        public ActionResult GetReservationList(Event parameterEvent)
        {
            Event Event2 = parameterEvent;
            //Event.getReservationList
            //get the guest list          
            return View("ReservationView", Event2);
        }
    }
}