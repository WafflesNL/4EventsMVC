﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class TimelinePageController : Controller
    {
        Event Event; //Ik weet niet of dit zo werkt dus er zal mee getest moeten worden.

        // GET: TimelinePage
        public ActionResult TimelinePage()
        {
            return View();
        }

        public ActionResult SetEvent(Event Event) //test
        {
            this.Event = Event;
            return View();
        }

        public ActionResult btnGetPost()
        {
            Event.GetContributions();
            return View("TimelinePage", Event);
        }
    }
}