using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ThirdWebApi.Unity
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// api异常过滤器特性
        /// api在出现异常时触发（控制器构造异常无法捕获）
        /// 可以在这里写入异常日志
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine($"{actionExecutedContext.Request.RequestUri.AbsoluteUri}:{actionExecutedContext.Exception.Message}");

            //把出现异常的api请求返回指定内容供前端解析
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                HttpStatusCode.OK, new
                {
                    Result = false,
                    Msg = $"{"请联系管理员:" + actionExecutedContext.Request.RequestUri.AbsoluteUri}:{actionExecutedContext.Exception.Message}"
                });

            //base.OnException(actionExecutedContext);
        }
    }
}