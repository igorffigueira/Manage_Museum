using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;

namespace ManageMuseum.Controllers
{
    public class SpaceController : Controller
    {
        // GET: Space
        public ActionResult Map()
        {
         
            return View();
        }
    }
}