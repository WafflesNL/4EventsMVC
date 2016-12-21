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
        public ActionResult GuestListView(Event ParameterEvent)
        {       
            ParameterEvent.GetGuestList();
            List<Account> GuestList = ParameterEvent.GuestList;

            return View(GuestList);
        }

    }
}