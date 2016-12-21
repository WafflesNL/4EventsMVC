using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class MaterialViewController : Controller
    {
        // GET: Material
        public ActionResult MaterialView(Event ParameterEvent)
        {
            //ParameterEvent.get();
            //List<Product> ProductList = ParameterEvent.productList;

            //return View(GuestList);
            return View();
        }

     
    }
}