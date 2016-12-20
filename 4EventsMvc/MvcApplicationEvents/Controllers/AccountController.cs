using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationEvents.Models;

namespace MvcApplicationEvents.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Account()
        {
            Account Account = new Account(CurrentAccount.ID, CurrentAccount.Username, CurrentAccount.Password, CurrentAccount.Function , CurrentAccount.Email); 
            return View();
        }

        public ActionResult OwnAcount()
        {




            return View();
        }


    }
}