using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceModel;

namespace SOAWebApp.Controllers
{
    public class WebServiceController : Controller
    {
        // GET: WebService
        public ActionResult CRUD()
        {
            return View();
        }
        public ActionResult Select()
        {
            using (WebService1Reference.WebService1SoapClient client = new WebService1Reference.WebService1SoapClient())
            {
                var a = client.Select(null);
                return Json(a, JsonRequestBehavior.AllowGet);//从webservice中获取json数据
            }
        }

        public ActionResult Insert(Contact contact)
        {
            SOAWebApp.WebService1Reference.Contact contact1 = new WebService1Reference.Contact()
            {
                Name = contact.Name,
                PhoneNo = contact.PhoneNo,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address
            };
            using (WebService1Reference.WebService1SoapClient client = new WebService1Reference.WebService1SoapClient())
            {
                client.Insert(contact1);
            }
            return Content("ok");
        }
        public ActionResult Delete()
        {
            string strId = Request["strId"];
            using (WebService1Reference.WebService1SoapClient client = new WebService1Reference.WebService1SoapClient())
            {
                client.Delete(strId);
            }
            return Content("ok");
        }

        public ActionResult ShowEdit()
        {
            string id = Request["rowsid"];
            using (WebService1Reference.WebService1SoapClient client = new WebService1Reference.WebService1SoapClient())
            {
                var a = client.Select(id);
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(Contact contact)
        {
            SOAWebApp.WebService1Reference.Contact contact1 = new WebService1Reference.Contact()
            {
                Name = contact.Name,
                PhoneNo = contact.PhoneNo,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address
            };
            using (WebService1Reference.WebService1SoapClient client = new WebService1Reference.WebService1SoapClient())
            {
                client.Update(contact1);
            }
            return Content("ok");
        }




        public ActionResult SoapHeader()
        {
            using (WebService1Reference.WebService1SoapClient client = new WebService1Reference.WebService1SoapClient())
            {
                ViewBag.SoapHeaderMsg = client.CustomSoapHeaderTest(new SOAWebApp.WebService1Reference.CustomSoapHeader()//SoapHeader验证
                {
                    UserName = "s",
                    PassWord = "1"
                });
            }
            return View();
        }



        public ActionResult WeatherWebService()
        {
            using (cn.com.webxml.ws.WeatherWebService client = new cn.com.webxml.ws.WeatherWebService())//调用远程的WebService
            {
                ViewBag.getWeatherbyCityName = client.getWeatherbyCityName("59493");
            }
            return View();
        }
    }
}