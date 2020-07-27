using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace ThirdWebApi.Unity
{
    /// <summary>
    /// basic验证
    /// </summary>
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 发生请求前去完成验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var authorization = actionContext.Request.Headers.Authorization;

            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count != 0
                || actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count != 0)
            {
                base.OnAuthorization(actionContext);//正确的访问方法
            }
            else if (authorization != null && authorization.Parameter != null)
            {
                //用户验证逻辑
                if (ValidateTicket(authorization.Parameter))
                {
                    base.IsAuthorized(actionContext);//正确的访问方法
                }
                else
                {
                    this.HandleUnauthorizedRequest(actionContext);//没有权限
                }
            }
            else
            {
                this.HandleUnauthorizedRequest(actionContext);//没有权限
            }
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);//告诉浏览器要验证
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");//权限信息放在basic
            //throw new System.Web.Http.HttpResponseException(challengeMessage);

            base.HandleUnauthorizedRequest(actionContext);//返回没有授权
        }

        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;
            return string.Equals(strTicket, string.Format("{0}&{1}", "Admin", "123456"));
            //应该分拆后去数据库验证
        }
    }
}