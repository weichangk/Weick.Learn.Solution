using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThirdWebApi.Controllers
{
    public class GlobalExceptionController : ApiController
    {
        public GlobalExceptionController()
        {
            throw new Exception("GlobalExceptionController ctor Error ~");
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
