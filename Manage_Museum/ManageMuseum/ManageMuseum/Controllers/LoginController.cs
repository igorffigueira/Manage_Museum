using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using Microsoft.Ajax.Utilities;

namespace ManageMuseum.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult ConfirmLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmLogin(UserAccount user)
        {
            string userName = user.Username;
            string password = user.Password;
            
            if (new UserManager().IsValid(userName, password))
            {
                var role = new UserManager().Role(userName, password);
                var userId = new UserManager().GetId(userName, password);
                
                switch (role)
                {
                    case "spacemanager":
                    {
                        HttpCookie cookie = Request.Cookies["UserId"];
                        HttpCookie cookie1 = Request.Cookies["Role"];
                        if (cookie ==null | cookie1 == null)
                        {
                            cookie = new HttpCookie("UserId");
                            cookie1 = new HttpCookie("Role");
                            cookie1.Value = role;
                            cookie.Value = userId.ToString();
                        }
                        else
                        {
                            cookie.Value = userId.ToString();
                            cookie1.Value = role;
                            }
                        Response.Cookies.Add(cookie);
                        Response.Cookies.Add(cookie1);


                            return RedirectToAction("SheduleEvent", "SheduleEvent");
                        }
                    case "artpiecemanager":
                        {
                            HttpCookie cookie = Request.Cookies["UserId"];
                            HttpCookie cookie1 = Request.Cookies["Role"];
                            if (cookie == null | cookie1 == null)
                            {
                                cookie = new HttpCookie("UserId");
                                cookie1 = new HttpCookie("Role");
                                cookie1.Value = role;
                                cookie.Value = userId.ToString();
                            }
                            else
                            {
                                cookie.Value = userId.ToString();
                                cookie1.Value = role;
                            }
                            Response.Cookies.Add(cookie);
                            Response.Cookies.Add(cookie1);
                            return RedirectToAction("SheduleExhibition", "ExhibitionShedule");
                        }
                }
            }

            return View();
        }
    }
}