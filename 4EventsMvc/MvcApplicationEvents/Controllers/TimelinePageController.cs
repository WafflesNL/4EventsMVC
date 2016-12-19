using System;
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
        public List<Contribution> Contriblist = new List<Contribution>();
        // GET: TimelinePage
        public ActionResult TimelinePage()
        {        
            for (int i = 0; i < 12; i++)
            {
                Contriblist.Add(new Contribution(DateTime.Now, "Dank", 2, 2, 1, new Message("Cunt", "Content")));
            }
            return View(Contriblist);
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

        public ActionResult btnSelectpost(int contrib)
        {           
            return View(contrib);
        }
    }
}