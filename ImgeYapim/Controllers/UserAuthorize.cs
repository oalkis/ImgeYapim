using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Content
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["userInfo"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/User/Login");
                return false;
            }

        }
    }
}