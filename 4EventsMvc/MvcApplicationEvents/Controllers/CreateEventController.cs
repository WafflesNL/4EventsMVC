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
        public ActionResult btnCreate(string Name, string description, DateTime DateStart, DateTime Dateend, int Maxvisitors, string location)
        {
            Location Location = new Location(location);
            Location.GetlocationID();

            Event Event = new Event(Name, Location, DateStart, Dateend, Maxvisitors, description);

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
