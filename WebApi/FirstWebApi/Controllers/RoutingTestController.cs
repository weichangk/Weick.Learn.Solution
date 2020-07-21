using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
    }

    public class RoutingTestController : ApiController
    {
        static List<Contact> contacts;
        static int counter = 2;
        static RoutingTestController()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact { Id = "001", Name = "张三", PhoneNo = "0101-1111111", EmailAddress = "zhangsan@gmail.com", Address = "深南大道001号" });
            contacts.Add(new Contact { Id = "002", Name = "李四", PhoneNo = "0101-2222222", EmailAddress = "lisi@gmail.com", Address = "深南大道002号" });
        }

        #region 使用http动词开头+http动词特性 也可以直接使用http动词  api/RoutingTest 
        [HttpGet]
        public IEnumerable<Contact> GetContact()
        {
            return contacts.AsEnumerable();
        }
        [HttpGet]
        public Contact GetContactById(string id)
        {
            Contact c = (from contact in contacts
                         where contact.Id == id
                         select contact).FirstOrDefault();
            if (c == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return c;
        }
        [HttpPost]
        public IHttpActionResult PostContact(Contact contact)
        {
            Interlocked.Increment(ref counter);
            contact.Id = counter.ToString("D3");
            contacts.Add(contact);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PutContact(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteContact(string id)
        {
            contacts.Remove(contacts.First(c => c.Id == id));
            return Ok();
        }
        #endregion

        #region 使用http动词特性 api/RoutingTest 
        //[HttpGet]
        //public IEnumerable<Contact> Select()
        //{
        //    return contacts.AsEnumerable();
        //}

        //[HttpGet]
        //public Contact SelectById(string id)
        //{
        //    Contact c = (from contact in contacts
        //                 where contact.Id == id
        //                 select contact).FirstOrDefault();
        //    if (c == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }
        //    return c;
        //}


        //[HttpPost]
        //public IHttpActionResult Insert(Contact contact)
        //{
        //    Interlocked.Increment(ref counter);
        //    contact.Id = counter.ToString("D3");
        //    contacts.Add(contact);
        //    return Ok();
        //}

        //[HttpPut]
        //public IHttpActionResult Update(Contact contact)
        //{
        //    contacts.Remove(contacts.First(c => c.Id == contact.Id));
        //    contacts.Add(contact);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(string id)
        //{
        //    contacts.Remove(contacts.First(c => c.Id == id));
        //    return Ok();
        //}
        #endregion

        #region 使用ActionName  api/RoutingTest/thumbnail/1     routeTemplate: "api/{controller}/{action}/{id}",
        //[HttpGet]
        //[ActionName("Thumbnail")]
        //public IHttpActionResult GetThumbnailImage(int id)
        //{
        //    return Ok(id);
        //}

        //[HttpPost]
        //[ActionName("Thumbnail")]
        //public IHttpActionResult AddThumbnailImage(int id)
        //{
        //    return Ok(id);
        //}
        #endregion

        #region 使用Non-Actions 要防止方法作为操作被调用，请使用[NonAction]属性。这向框架发出信号，表明该方法不是一个动作，即使它与路由规则相匹配。
        [NonAction]
        public void GetPrivateData() { }
        #endregion

        #region 使用特性路由+http动词开头    使用传统路由时http动词开头还需要+http动词特性
        //[Route("api/Contacts")]
        //public IEnumerable<Contact> GetContacts()
        //{
        //    return contacts.AsEnumerable();
        //}
        //[Route("api/Contacts/{id}")]
        //public Contact GetContactById(string id)
        //{
        //    Contact c = (from contact in contacts
        //                 where contact.Id == id
        //                 select contact).FirstOrDefault();
        //    if (c == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }
        //    return c;
        //}
        //[Route("api/Contacts")]
        //public IHttpActionResult PostContact(Contact contact)
        //{
        //    Interlocked.Increment(ref counter);
        //    contact.Id = counter.ToString("D3");
        //    contacts.Add(contact);
        //    return Ok();
        //}
        //[Route("api/Contacts")]
        //public IHttpActionResult PutContact(Contact contact)
        //{
        //    contacts.Remove(contacts.First(c => c.Id == contact.Id));
        //    contacts.Add(contact);
        //    return Ok();
        //}
        //[Route("api/Contacts/{id}")]
        //public IHttpActionResult DeleteContact(string id)
        //{
        //    contacts.Remove(contacts.First(c => c.Id == id));
        //    return Ok();
        //}
        #endregion

        #region 使用FromUri FromBody
        //使用[FromUri] 属性强制Web API从查询字符串中获取复杂类型的值，使用[FromBody] 属性从请求主体中获取原始类型的值，与默认规则相反。
        //使用[FromUri] 属性时复杂类型属性的名称和查询字符串参数必须匹配。
        //使用[FromBody] 属性只能应用于操作方法的一个基本参数。它不能应用于同一动作方法的多个基本参数。

        //两个不能同时运行。。。。

        ////public IHttpActionResult Post([FromUri]Student stu)//api/RoutingTest?id=1&name=steve
        ////{
        ////    return Ok(stu.Id);
        ////}

        //public IHttpActionResult Post([FromBody]string name)//api/RoutingTest
        //{
        //    return Ok(name);
        //}
        #endregion

        #region api参数使用基本数据类型+复杂数据类型

        [HttpPost]
        public IHttpActionResult Para2(string name, Student stu)
        {
            return Ok(stu.Id);
        }
        [HttpPost]
        public IHttpActionResult Para3(int id, string name, Student stu)//api/RoutingTest?Name=asaa&id=222               stu在请求主体request body以json格式输入
        {
            return Ok(name);
        }
        #endregion

        //参数绑定
        //Web API控制器中的操作方法可以有一个或多个不同类型的参数。它可以是基本类型，也可以是复杂类型。
        //Web API根据参数类型将操作方法参数绑定到URL的查询字符串或请求主体request body。
        //默认情况下，如果参数类型是.net基本类型，比如int、bool、double、string、GUID、DateTime、decimal或任何其他可以从string类型转换的类型，那么它将设置查询字符串中的参数值。
        //如果参数类型是复杂类型，那么默认情况下，Web API尝试从请求体获取值。



        //使用fiddler对api进行测试
        //在HTTP请求中，MIME类型使用Accept和Content-Type属性在请求头中指定。Accept头属性指定客户端期望的响应数据的格式，Content-Type头属性指定请求体中的数据格式，以便接收方能够将其解析为适当的格式。
        //Accept: text/xml
        //Content-Type: application/json
    }
}
