using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            List<Event> EventList = CurrentAccount.GetEvents();
            return View(EventList);
        }


        public ActionResult btnEventInformation(Event Event)
        {
            return RedirectToAction("GetEventInformation", "Event", new { parameterEvent = Event });      
        }

        public ActionResult btnTimeLine(Event Event)
        {
            return RedirectToAction("Index", "Event", new { parameterEvent = Event });       
        }

        public ActionResult btnMaterial(Event Event)
        {
            return RedirectToAction("Index", "Event", new { parameterEvent = Event });
        }

        public ActionResult btnPayment(Event Event)
        {
            return RedirectToAction("Index", "Event", new { parameterEvent = Event });
        }

        public ActionResult btnReservation(Event Event)
        {
            return RedirectToAction("Index", "Event", new { parameterEvent = Event });
        }


    }
}