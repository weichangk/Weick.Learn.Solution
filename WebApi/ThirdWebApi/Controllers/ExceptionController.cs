using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThirdWebApi.Unity;

namespace ThirdWebApi.Controllers
{
    //[CustomExceptionAttribute]//对控制器下面的全部方法生效
    public class ExceptionController : ApiController
    {
        //[CustomExceptionAttribute]//只对方法生效
        [CustomActionAttribute]
        public IEnumerable<string> Get()
        {
            throw new Exception("ExceptionController Get Error1 ~");
            return new string[] { "value1", "value2" };
        }

        [CustomActionAttribute]
        public string Get(int id)
        {
            try
            {
                throw new Exception("ExceptionController Get Error2 ~");
                return "value Get";
            }
            catch (Exception ex)//处理异常后异常过滤器特性将不会获得异常
            {
                Console.WriteLine(ex.Message);
                return "ExceptionController Get Error222 ~";
            }

        }
    }
}
