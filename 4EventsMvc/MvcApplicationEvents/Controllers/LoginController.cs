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
                switch (CurrentAccount.ID)
                {
                    case (1):
                        CurrentAccount.Function = Function.Bezoeker;
                        break;
                    case (2):
                        CurrentAccount.Function = Function.Beheerder;
                        break;
                    case (3):
                        CurrentAccount.Function = Function.AccountBeheerder;
                        break;
                    case (4):
                        CurrentAccount.Function = Function.Medewerker;
                        break;
                    case (0):
                        CurrentAccount.ID = 0;
                        break;
                }

                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View("Login");
            }
           
            
        }

        public ActionResult LogOut ()
        {
            CurrentAccount.RemovePropertys();
            return View("Login");
        }


    }
}