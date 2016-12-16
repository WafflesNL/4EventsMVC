﻿using System;
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
            return View();
        }

        public ActionResult GetMaterialList(Event parameterEvent)
        {
            Event Event2 = parameterEvent;
            //Event.getMaterialList
            //get the guest list          
            return View("MaterialView", Event2);
        }
    }
}