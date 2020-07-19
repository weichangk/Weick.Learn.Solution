using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Filters
{ 
    public class ActionLogFilterAttribute : FilterAttribute, IActionFilter//实现非全局过滤器；特性过滤器
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            File.AppendAllText(path, ctrlName + "." + actionName + "执行完成--实现非全局过滤器；特性过滤器" + Environment.NewLine);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            File.AppendAllText(path, ctrlName + "." + actionName + "开始执行--实现非全局过滤器；特性过滤器" + Environment.NewLine);
        }
    }
}