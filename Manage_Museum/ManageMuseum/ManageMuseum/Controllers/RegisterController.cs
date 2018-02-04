using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using ManageMuseumData.GetData;

namespace ManageMuseum.Controllers
{
    [SpaceManagerAuthorize]
    public class RegisterController : Controller
    {
        private UserData userData = new UserData();
        public ActionResult Register()
        {
            //var roles = db.Roles.ToList();
            //ViewBag.Roles = new SelectList(roles,"Name","Name");
            var roles = userData.GetRoles();
            ViewBag.Roles = new SelectList(roles, "Name", "Name");

            return View();
        }

        [SpaceManagerAuthorize]
        [HttpPost]
        public ActionResult Register(RegisterViewModel userAccount)
        {
            //var roles = db.Roles.ToList();
            //ViewBag.Roles = new SelectList(roles, "Name", "Name");
            var roles = userData.GetRoles();
            ViewBag.Roles = new SelectList(roles, "Name", "Name");

            //var queryRole = db.Roles.First(s => s.Name == userAccount.Role);
            //var userAccountInsert = new UserAccount(){FirstName = userAccount.FirstName,LastName = userAccount.LastName,Password = userAccount.Password,Username = userAccount.Username,Role = queryRole};

            //db.UserAccounts.Add(userAccountInsert);
            //db.SaveChanges();


            userData.RegisterUser(userAccount.FirstName,userAccount.LastName,userAccount.Role,userAccount.Username,userAccount.Password);
            return Redirect("Register");
        }
    }
}