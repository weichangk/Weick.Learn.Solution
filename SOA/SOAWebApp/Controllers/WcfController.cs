using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFModel;

namespace SOAWebApp.Controllers
{
    public class WcfController : Controller
    {
        // GET: Wcf
        public ActionResult WcfService1()
        {
            //using (WcfService1Reference.WcfService1Client client =new WcfService1Reference.WcfService1Client())
            //{
            //    client.DoWork();
            //    ViewBag.GetString = client.GetString();
            //    ViewBag.GetUserList = client.GetUserList(0);
            //}

            WcfService1Reference.WcfService1Client client = null;
            try
            {
                client = new WcfService1Reference.WcfService1Client();
                client.DoWork();
                ViewBag.GetString = client.GetString();
                ViewBag.GetUserList = client.GetUserList(0);
                client.Close();
                return View();
            }
            catch (Exception)
            {
                if (client != null) client.Abort();
                throw;
            }

        }






        public ActionResult CRUD()
        {
            return View();
        }
        public ActionResult Select()
        {
            using (WcfService2Reference.ContactServiceClient client = new WcfService2Reference.ContactServiceClient())
            {
                var a = client.Select(null);
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Insert(Contact contact)
        {
            Contact contact1 = new Contact()
            {
                Name = contact.Name,
                PhoneNo = contact.PhoneNo,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address
            };
            using (WcfService2Reference.ContactServiceClient client = new WcfService2Reference.ContactServiceClient())
            {
                client.Insert(contact1);
            }
            return Content("ok");
        }
        public ActionResult Delete()
        {
            string strId = Request["strId"];
            using (WcfService2Reference.ContactServiceClient client = new WcfService2Reference.ContactServiceClient())
            {
                client.Delete(strId);
            }
            return Content("ok");
        }

        public ActionResult ShowEdit()
        {
            string id = Request["rowsid"];
            using (WcfService2Reference.ContactServiceClient client = new WcfService2Reference.ContactServiceClient())
            {
                var a = client.Select(id);
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(Contact contact)
        {
            Contact contact1 = new Contact()
            {
                Name = contact.Name,
                PhoneNo = contact.PhoneNo,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address
            };
            using (WcfService2Reference.ContactServiceClient client = new WcfService2Reference.ContactServiceClient())
            {
                client.Update(contact1);
            }
            return Content("ok");
        }

    }
}