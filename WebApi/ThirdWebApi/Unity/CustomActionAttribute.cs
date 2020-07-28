using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ThirdWebApi.Unity
{
    public class CustomActionAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine("OnActionExecuting" + actionContext.Request.RequestUri.AbsoluteUri);
            //可以完成数据验证
            //actionContext.ModelState.IsValid 方法执行前完成检测
            //actionContext.Response
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine("OnActionExecuted");
            //actionExecutedContext.Response
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}