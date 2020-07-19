using FirstMvcWebApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionLogFilterAttribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult ExceptionTest()
        {
            string str = null;
            return Content(str.Length.ToString());
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!

            ////Redirect to action
            //filterContext.Result = RedirectToAction("Error", "InternalError");

            // OR return specific view
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }



        public ActionResult LayoutTest()
        {
            return View();
        }

        public ActionResult ViewBagTest()
        {
            ViewBag.FirstName = "xxx";
            ViewBag.LastName = "yyy";
            TempData["TempData1"] = "123456789";
            return View();
        }
        public ActionResult ViewDataTest()
        {
            ViewData["FirstName"] = "xxx-xxx";
            ViewData["LastName"] = "yyy-yyy";
            TempData["TempData1"] = "123456789";
            return View();
        }
        public ActionResult GetTempDataTest()
        {
            return View();
        }

    }
}