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

        public ActionResult GetEventInformation(Event EventParameter)
        {
            return View("Event", EventParameter);
        }


        public ActionResult btnChangeEvent(Event EventParameter, string Eventname, string Eventdescription, string ButtonValue)
        {
            switch (ButtonValue)
            {
                case ("Opslaan"):
                    Event Event = new Event(EventParameter.ID, Eventname, Eventdescription);

                    if (Event.EditEvent(Event))
                    {
                        return RedirectToAction("Home", "Home");
                    }
                    else
                    {
                        return View("Event", EventParameter); //failed and other reactions still have to be added
                    }
                case ("GastenLijst"):
                    return RedirectToAction("GuestListView", "GuestListView", EventParameter);
                  
                case ("Materiaal"):
                    return RedirectToAction("MaterialView", "MaterialView", EventParameter);
                
                case ("Reserveringen"):
                    return RedirectToAction("ReservationView", "ReservationView", EventParameter);
                
                default:
                    return View("Event");
            }

       
        }

      
     
    }
}