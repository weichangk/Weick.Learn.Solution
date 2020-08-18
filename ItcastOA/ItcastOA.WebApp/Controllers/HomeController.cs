using Redis.Cache.Base;
using Redis.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItcastOA.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private ICache cache = CacheFactory.CaChe();
        public ActionResult Index()
        {
            return View();
        }

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

        public class ClassTest
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
        }
        public ActionResult Test()
        {
            ClassTest c1 = new ClassTest
            {
                Id = 1,
                FirstName = "qqqq"
            };
            cache.Write<ClassTest>("c1", c1);
            ClassTest c1temp = cache.Read<ClassTest>("c1");
            return Content(c1temp.FirstName);
        }
    }
}