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

        //haalt data op voor andere forms
        public ActionResult btnGuestList(Event Event)
        {
            return RedirectToAction("GetGuestList", "GuestListView", new { parameterEvent = Event });          
        }

        public ActionResult btnMaterialList(Event Event)
        {
            return RedirectToAction("GetMaterialList", "MaterialView", new { parameterEvent = Event });
        }

        public ActionResult btnReservationList(Event Event)
        {
            return RedirectToAction("GetReservationList", "ReservationView", new { parameterEvent = Event });
        }
    }
}