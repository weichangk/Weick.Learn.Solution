using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI1.Controllers
{
    public class ValuesController : ApiController
    {

        //Attribute Routing
        [Route("api/student/names")]
        public IEnumerable<string> GetStudents()
        {
            return new string[] { "student1", "student2" };
        }



        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok(value);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok(value);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }

        public void Post(int id, string name)
        {
        }

    }

    //如果你想写的方法不是以HTTP动词开始，那么你可以应用适当的HTTP动词属性在方法上，如HttpGet, HttpPost, HttpPut等，就像MVC控制器一样。
    //public class ValuesController : ApiController
    //{
    //    [HttpGet]
    //    public IEnumerable<string> Values()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    [HttpGet]
    //    public string Value(int id)
    //    {
    //        return "value";
    //    }

    //    [HttpPost]
    //    public void SaveNewValue([FromBody]string value)
    //    {
    //    }

    //    [HttpPut]
    //    public void UpdateValue(int id, [FromBody]string value)
    //    {
    //    }

    //    [HttpDelete]
    //    public void RemoveValue(int id)
    //    {
    //    }
    //}
}
