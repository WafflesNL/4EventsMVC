using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationEvents.Models
{
    public class ContribViewModels
    {
        public IEnumerable<string> SelectedConts { get; set; }
        public IEnumerable<SelectListItem> Contribs { get; set; }
        //Dank Memes
    }
}