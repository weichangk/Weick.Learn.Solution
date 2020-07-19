using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebAPI1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            // define route
            IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}",
                                                new { id = RouteParameter.Optional }, null);
            // Add route
            config.Routes.Add("DefaultApi", defaultRoute);




            //Configure Multiple Routes
            // school route
            config.Routes.MapHttpRoute(
                name: "School",
                routeTemplate: "api/myschool/{id}",
                defaults: new { controller = "school", id = RouteParameter.Optional },
                constraints: new { id = "/d+" }
            ) ;
        }
    }
}
