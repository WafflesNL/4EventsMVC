using MvcApplicationEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationEvents.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Validate(string tbName, string tbPassword)
        {
            if (CurrentAccount.Login(tbPassword, tbName) == true)
            {
                return RedirectToAction("Home", "Home");
            }

            else
            {
                return View("Login");
            }
           
            
        }
    }
}