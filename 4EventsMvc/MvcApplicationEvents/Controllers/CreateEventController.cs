using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class CreateEventController : Controller
    {
        // GET: CreateEvent
        public ActionResult CreateEvent()
        {
            return View();
        }
        public ActionResult btnCreate(string Eventname, string Eventdescription, DateTime EventDatestart, DateTime EventDateend, int quantity, string Location)
        {
            Location L = new Location(Location);
            L.GetlocationID();

            Event Event = new Event(Eventname, L, EventDatestart, EventDateend, quantity, Eventdescription);

            if (Event.CreateEvent(Event))
            {
                return RedirectToAction("Home", "Home"); 
            }
            else
            {
                return View("CreateEvent"); //failed and other reactions still have to be added
            }    
        }

    }
}
