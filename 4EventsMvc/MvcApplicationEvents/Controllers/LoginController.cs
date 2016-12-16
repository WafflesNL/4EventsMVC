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

        public ActionResult btnLogin(string Username, string Password)
        {
            if (CurrentAccount.Login(Username, Password) == true)
            {
                return RedirectToAction("Home", "Home");
            }

            else
            {
                Username = null;
                Password = null;
                return View();
            }
           
            
        }
    }
}