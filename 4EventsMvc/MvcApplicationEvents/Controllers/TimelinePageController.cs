using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;
using System.Text;

namespace MvcApplicationEvents.Controllers
{
    public class TimelinePageController : Controller
    {
        Event Event;
        public List<Contribution> Contriblist = new List<Contribution>();
        /// <summary>
        /// Original Action to View
        /// </summary>
        /// <param name="Event">Event which is matched with the Timeline</param>
        /// <returns>View TimelinePage</returns>
        [HttpGet]
        public ActionResult TimelinePage(Event Event)
        {
            Contriblist = DatabaseGetContribution.GetContributions(Event.ID);
            return View(Contriblist);
        }

        /// <summary>
        /// Like Function
        /// </summary>
        /// <param name="ID">ID from selected post</param>
        [HttpPost]
        public void Like(int ID)
        {
                Contribution C = new Contribution(ID);
                C.likePost();
                RedirectToAction("TimelinePage");
            
        }

        /// <summary>
        /// Report Function
        /// </summary>
        /// <param name="ID">ID from selected post</param>
        [HttpPost]
        public void Report(int ID)
        {
            Contribution C = new Contribution(ID);
            C.ReportPost();
            RedirectToAction("TimelinePage");
        }

        /// <summary>
        /// Adds a post to the database
        /// </summary>
        /// <param name="Event">Event which is matched with the Timeline</param>
        /// <param name="content">The content from the post</param>
        /// <returns>View TimelinePage</returns>
        [HttpPost]
        public ActionResult TimelinePage(Event Event, string content)
        {
            Contriblist = DatabaseGetContribution.GetContributions(Event.ID);

            Message Post = new Message("Title", content);
            Contribution C = new Contribution(DateTime.Now, "Mededeling", 0, 0, 99, Post, (int)CurrentAccount.ID);
            if (Contriblist.Exists(x => x.Message == Post))
            {
                return View(Contriblist);
            }
            else
            {
                C.AddMessage(C);
                return View(Contriblist);
            }
        }
    }
}