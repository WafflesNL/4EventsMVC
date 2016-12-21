using MvcApplicationEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationEvents.Controllers
{
    public class MaterialPageController : Controller
    {
        // GET: MaterialPage
        public ActionResult MaterialPage()
        {
            Product product = new Product();
            List < Product > productlist = new List<Product>();
            productlist =  product.GetAvailableCopies();
            return View();
        }
    }
}