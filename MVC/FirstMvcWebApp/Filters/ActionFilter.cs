using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            File.AppendAllText(path, DateTime.Now + ": " + ctrlName + "." + actionName + "执行完成" + Environment.NewLine);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            File.AppendAllText(path, DateTime.Now + ": " + ctrlName + "." + actionName + "开始执行..." + Environment.NewLine);
        }
    }
}