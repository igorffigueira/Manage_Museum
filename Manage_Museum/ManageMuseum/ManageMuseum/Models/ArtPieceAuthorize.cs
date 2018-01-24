using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageMuseum.Models
{
    public class ArtPieceAuthorize : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var RoleCookie = filterContext.HttpContext.Request.Cookies["Role"]?.Value;
            if (RoleCookie != "artpiecemanager")
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}