using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using ManageMuseumData.EventManagement;

namespace ManageMuseum.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
           
            EventManagement eventManagement = new EventManagement();
            eventManagement.Management();

            return RedirectToAction("ConfirmLogin", "Login");
        }
        
    }
}