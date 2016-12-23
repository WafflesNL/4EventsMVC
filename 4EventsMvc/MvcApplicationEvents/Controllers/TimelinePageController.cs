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
        Event Event; //Ik weet niet of dit zo werkt dus er zal mee getest moeten worden.
        public List<Contribution> Contriblist = new List<Contribution>();

        [HttpGet]
        public ActionResult TimelinePage(Event Event)
        {
            Contriblist = DatabaseGetContribution.GetContributions(Event.ID);
            //List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            //foreach (Contribution c in Contriblist)
            //{
            //    SelectListItem selectList = new SelectListItem()
            //    {
            //        Text = c.Message.Content,
            //        Value = c.ID.ToString(),
            //        Selected = c.IsSelected
            //    };
            //    listSelectListItems.Add(selectList);
            //}

            //ContribViewModels ContribViewModel = new ContribViewModels()
            //{
            //    Contribs = listSelectListItems
            //};

            return View(Contriblist);
        }

        [HttpPost]
        public void Like(int ID)
        {
            Contribution C = new Contribution(ID);
            C.likePost();
        }

        [HttpPost]
        public void Report(int ID)
        {
            Contribution C = new Contribution(ID);
            C.ReportPost();
        }

        [HttpPost]
        public void Post(string content)
        {
            Message Post = new Message(null, content);
            Contribution C = new Contribution(Post);
            C.AddMessage(Post);
        }
    }
}