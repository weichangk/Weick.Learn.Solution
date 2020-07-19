using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string ctrl_action = ctrlName + actionName;
            if (ctrl_action == "AccountLogOn" || ctrl_action == "AccountRegister" || ctrl_action == "HomeError")
            {
            }
            else
            {
                if (filterContext.HttpContext.Session["UserName"] == null)
                {
                    filterContext.Result = new RedirectResult("/Account/LogOn");
                }
            }
        }
    }
}