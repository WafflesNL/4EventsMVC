using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class GuestListViewController : Controller
    {
        // GET: GuestListView
        public ActionResult GuestListView()
        {
            return View();
        }

        public ActionResult GetGuestList(Event parameterEvent)
        {
            Event Event2 = parameterEvent;
            //Event.getGuestList
            //get the guest list          
            return View("GuestListView", Event2);
        }
    }
}