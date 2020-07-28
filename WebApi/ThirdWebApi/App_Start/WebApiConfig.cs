using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using ThirdWebApi.Unity;
using ThirdWebApi.Unity.Interface;
using Unity;



namespace ThirdWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //注册异常过滤器特性（全部webapi）
            config.Filters.Add(new CustomExceptionAttribute());
            //注册全局异常处理；不会覆盖异常过滤器特性
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            ////注册操作方法过滤器特性（一般不全局设置）
            //config.Filters.Add(new CustomActionAttribute());

            //注册容器
            config.DependencyResolver = new UnityDependencyResolver(UnityContainerFactory.GetContainer());


            //string origins = ConfigurationManager.AppSettings["cors:allowedOrigins"];
            //string headers = ConfigurationManager.AppSettings["cors:allowedHeaders"];
            //string methods = ConfigurationManager.AppSettings["cors:allowedMethods"];
            //config.EnableCors(new EnableCorsAttribute(origins, headers, methods));

            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.EnableCors();

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
