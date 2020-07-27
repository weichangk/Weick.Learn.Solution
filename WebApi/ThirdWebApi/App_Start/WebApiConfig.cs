using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ThirdWebApi.Unity;
using ThirdWebApi.Unity.Interface;
using Unity;



namespace ThirdWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //注册容器
            config.DependencyResolver = new UnityDependencyResolver(UnityContainerFactory.GetContainer());

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
