using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Controllers
{
    //[RoutePrefix("RouteTest")]
    //[Route("{action}")]//使用RoutePrefix可以指定路由以RouteTest/开头，可以使URL省略RouteTest/，因为前缀会自动为它们加上RouteTest/

    [Route("RouteT/{action}")]//控制器路由；在操作方法指定路由特性时，会覆盖控制器级别指定的任何路由特性。使用了特性路由的控制器或方法，会覆盖传统路由匹配规则
    public class RouteTestController : Controller
    {
        // GET: RouteTest
        public ActionResult Index()
        {
            return Content("Index");
        }

        //为方法使用特性路由；
        [Route("RouteTest1")]//http://localhost/RouteTest1
        public ActionResult RouteTest1()
        {
            return Content("RouteTest1");
        }


        //为方法使用多个特性路由；
        [Route("")]//http://localhost/
        [Route("RouteTest2")]//http://localhost/RouteTest2
        [Route("RouteTest2/xxx")]//http://localhost/RouteTest2/xxx
        public ActionResult RouteTest2()
        {
            return Content("RouteTest2");
        }

        //带参数特性路由
        [Route("RouteTest3/{id}")]//http://localhost/RouteTest3/1
        public ActionResult RouteTest3(int id)
        {
            return Content($"RouteTest3 id:{id}");
        }

        //带参数特性路由
        [Route("{year}/{month}/{day}")]//http://localhost/2020/April/10
        public ActionResult RouteTest4(string year,string month,string day )
        {
            return Content($"RouteTest4 {year}/{month}/{day}");
        }


        //带路由约束特性路由；因为该路由与[Route("RouteTest3/{id}")]存在二义性
        [Route("RouteTest5/{name：string}")]//http://localhost/RouteTest3/xxx
        public ActionResult RouteTest5(int name)
        {
            return Content($"RouteTest5 name:{name}");
        }



    }
}