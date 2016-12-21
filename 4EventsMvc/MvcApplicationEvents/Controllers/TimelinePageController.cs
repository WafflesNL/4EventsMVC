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
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach (Contribution c in Contriblist)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = c.Message.Content,
                    Value = c.ID.ToString(),
                    Selected = c.IsSelected
                };
                listSelectListItems.Add(selectList);
            }

            ContribViewModel ContribViewModel = new ContribViewModel()
            {
                Contribs = listSelectListItems
            };

            return View(ContribViewModel);
        }

        [HttpPost]
        public string TimelinePage(IEnumerable<string> selectedConts)
        {
            if (selectedConts == null)
            {
                return "No cities selected";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - " + string.Join(",", selectedConts));
                return sb.ToString();
            }
        }
    }
}