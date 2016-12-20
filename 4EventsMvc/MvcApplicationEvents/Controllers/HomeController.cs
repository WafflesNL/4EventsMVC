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
            ViewBag.EventList = new SelectList(EventList, "Name");
            return View(EventList);
        }


        public ActionResult Goforms(string button)
        {
            Event Event = new Event();
            switch (button)
            {
                case ("Event Aanmaken"):
                    return RedirectToAction("CreateEvent", "CreateEvent");
                  
                case ("Tijdlijn"):
                    return RedirectToAction("GetEventInformation", "Event", new { parameterEvent = Event });
                    
                case ("Materiaal"):
                    return RedirectToAction("GetEventInformation", "Event", new { parameterEvent = Event });
                    
                case ("betalingsstatus"):
                    return RedirectToAction("GetEventInformation", "Event", new { parameterEvent = Event });
                                   
                case ("Event Informatie"):
                    return RedirectToAction("GetEventInformation", "Event", Event);
                    
                case ("Reserveren"):
                    return RedirectToAction("GetEventInformation", "Event", new { parameterEvent = Event });
                    
                default:
                    return View("Home");
            }
             
        }




        public ActionResult btnTimeLine(Event Event)
        {
            return RedirectToAction("Index", "Event", new { parameterEvent = Event });       
        }



    }
}