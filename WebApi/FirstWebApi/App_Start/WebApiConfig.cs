using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FirstWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            //Web API 的默认路由模板"是 api/{controller}/{id}。" 在此模板中"，api"是文本路径段，{controller} 和 {id} 是占位符变量。
            //当 Web API 框架收到 HTTP 请求时，它会尝试将 URI 与路由表中的路由模板之一匹配。 如果没有路由匹配，客户端将收到 404 错误。

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //定义多个传统路由
            config.Routes.MapHttpRoute(
                name: "xxx",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
