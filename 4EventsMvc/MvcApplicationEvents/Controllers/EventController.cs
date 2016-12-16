using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Event()
        {
            return View();
        }

        public ActionResult btnChangeEvent(int ID, string Name, string description)
        {
            Event Event = new Event(ID, Name, description);

            if (Event.EditEvent(Event))
            {
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View("Event"); //failed and other reactions still have to be added
            }      
        }

        public ActionResult GetEventInformation(Event parameterEvent)
        {
            return View("Event", parameterEvent);
        }


        public ActionResult btnGuestList()
        {
            return View();
        }

        public ActionResult btnMaterialList()
        {
            return View();
        }

        public ActionResult btnReservationList()
        {
            return View();
        }
    }
}