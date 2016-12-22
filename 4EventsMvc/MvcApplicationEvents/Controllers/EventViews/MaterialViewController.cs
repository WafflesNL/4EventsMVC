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
        public ActionResult MaterialView()
        {
            List<Product> empty = new List<Product>();
           return View(empty);
        }

        public ActionResult MaterialViewForEvent(Event ParameterEvent)
        {
            //ParameterEvent.get();
            //List<Product> ProductList = ParameterEvent.productList;

            //return View(GuestList);
            return View();
        }

        public ActionResult GetAll()
        {
            Product product = new Product();
            List<Product> productlist = new List<Product>();
            productlist = product.GetAvailableCopies();
            return View("MaterialView", productlist);
        }

        public ActionResult GetAllRented()
        {
            Product product = new Product();
            List<Product> productlist = new List<Product>();
       //     productlist = product.GetAvailableCopies();
            return View("MaterialView", productlist);
        }

        public ActionResult Rent(string barcode)
        {
            Rental rental = new Rental();
            List<Product> productlist = new List<Product>();
            Product product = new Product(1, "", "", "", 20, 3);
            productlist.Add(product);
            rental.Rent(productlist, barcode);
            return RedirectToAction("GetAll");
        }
        public ActionResult Return(string barcode)
        {
            Rental rental = new Rental();
            rental.Return;
            return RedirectToAction("GetAll");
        }
    }
}