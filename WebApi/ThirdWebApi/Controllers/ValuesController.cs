using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using ThirdWebApi.Unity;

namespace ThirdWebApi.Controllers
{
    [BasicAuthorizeAttribute]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [AllowAnonymous]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet]
        [Route("api/ValuesGet/{id}")]
        public string ValuesGet(string id)
        {
            return id;
        }


        //模拟登录，记录票证Ticket
        [HttpGet]
        [Route("api/Login")]
        [AllowAnonymous]
        public string Login(string account, string password)
        {
            if (account.Equals("Admin") && password.Equals("123456"))
            {
                FormsAuthenticationTicket ticketObject = new FormsAuthenticationTicket(0, account, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", account, password),
                            FormsAuthentication.FormsCookiePath);
                var result = new { Result = true, Ticket = FormsAuthentication.Encrypt(ticketObject) };
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new { Result = false };
                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
