using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMvcWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //启用特性路由
            //在操作方法指定路由特性时，会覆盖控制器级别指定的任何路由特性。使用了特性路由的控制器或方法，会覆盖传统路由匹配规则
            //传入路由特性的字符产叫做路由模板，他就是一个模式匹配规则，决定了这个路由是否适用于传入的请求
            //routes.MapMvcAttributeRoutes();



            //以下定义传统路由
            //MapRoute方法的最简单形式是采取路由名称和路由模板，与特性路由一样，路由模板是一种模式匹配规则，用来决定该路由是否应该处理传入的请求（基于请求的URL决定）
            //特性路由与传统路由的最大区别在于如何将路由链接到操作方法。传统路由依赖于名称字符串而不是特性来完成这种链接。
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //自定义路由
            routes.MapRoute(
                name: "RouteStudent",
                url: "students/{id}",
                defaults: new { controller = "RouteStudent", action = "Index" }
            );

            //默认路由
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            ////可以修改路由设置启动页
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            //);



            //选择特性路由还是传统路由？
            //以下情况考虑选择传统路由
            //想要集中配置所有路由
            //使用自定义约束对象
            //存在现有可工作的应用程序，而又不想修改应用程序

            //以下情况考虑特性路由
            //想把路由和操作方法保存在一起
            //创建新应用程序或者对现有应用程序进行巨大修改

            //传统路由的集中配置意味着可以在一个地方理解请求如何映射到操作；传统路由比特性路由更灵活。特性路由很好的把关于控制器的所有内容放到一起，包括控制器使用的URL和运行的操作。



            //当ASP.NET处理请求时，路由管道主要由以下几步组成
            //1.UrlRoutingModule尝试使用RouteTable中注册的路由匹配当前请求
            //2.如果RouteTable中有一个路由成功匹配，路由模板就会从匹配成功的路由中获取IRouteHandler接口对象
            //3.路由模板调用的IRouteHandler接口GetHandler方法，并返回用来处理请求的IRouteHandler对象
            //4.调用HTTP处理程序中的ProcessRequst方法，然后把处理的请求传递给它
            //5.在ASP.NET mvc中IRouteHandler是MvcRouteHandler类的一个实例，MvcRouteHandler返回一个实现里IRouteHandler接口的MvcHandler对象。MvcHandler对象主要用来实例化控制器，并调用该实例化控制器上的操作方法

        }
    }
}
