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

        //public ActionResult HomeGetEvents()
        //{
        //    //List<Event> EventsList = CurrentAccount.methode();

        //    //return View("Home", EventsList);
        //}
      
    }
}