using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebServiceModel;

namespace WebServiceHostWebApp
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        public CustomSoapHeader CustomSoapHeader;


        static List<Contact> contacts;
        static int counter = 2;
        static WebService1()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact { Id = "001", Name = "张三", PhoneNo = "0512-12345678", EmailAddress = "zhangsan@gmail.com", Address = "江苏省苏州市星湖街328号" });
            contacts.Add(new Contact { Id = "002", Name = "李四", PhoneNo = "0512-23456789", EmailAddress = "lisi@gmail.com", Address = "江苏省苏州市金鸡湖大道328号" });
        }

        [WebMethod]//服务方法对外公开标识
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public List<Contact> Select(string id = null)//无法序列化接口 System.Collections.Generic.IEnumerable
        {
            return (from contact in contacts
                    where contact.Id == id || string.IsNullOrEmpty(id)
                    select contact).ToList();
        }
        [WebMethod]
        public void Insert(Contact contact)
        {
            Interlocked.Increment(ref counter);
            contact.Id = counter.ToString("D3");
            contacts.Add(contact);
        }
        [WebMethod]
        public void Update(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
        }
        [WebMethod]
        public void Delete(string id)
        {
            contacts.Remove(contacts.First(c => c.Id == id));
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("CustomSoapHeader")]
        public string CustomSoapHeaderTest()
        {
            if (this.CustomSoapHeader != null && this.CustomSoapHeader.Validate())
            {
                return "身份验证通过";
            }
            else
            {
                throw new SoapException("身份验证不通过", SoapHeaderException.ServerFaultCode);
            }
        }
    }
}
