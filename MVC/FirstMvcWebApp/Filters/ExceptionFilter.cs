using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            string path = filterContext.HttpContext.Server.MapPath("~/Exception.txt");

            File.AppendAllText(path, ex.Message + Environment.NewLine);

            //5、标记异常已经处理完毕
            filterContext.ExceptionHandled = true;

            filterContext.Result = new RedirectResult("/Shared/Error");
        }
    }
}