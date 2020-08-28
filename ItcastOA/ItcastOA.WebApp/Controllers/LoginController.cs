using Redis;
using Redis.Cache.Base;
using Redis.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace ItcastOA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ICache cache = CacheFactory.CaChe();
        IBLL.IUserInfoService UserInfoService { get; set; }//Spring.Net IOC注入
        //IBLL.IUserInfoService UserInfoService = new BLL.UserInfoService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        #region 完成用户登录
        public ActionResult UserLogin()
        {
            string validateCode = Session["session_verifycode"] != null ? Session["session_verifycode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["session_verifycode"] = null;
            string txtCode = Md5Helper.Encrypt(Request["vCode"].ToLower(), 16);//输入验证码加密
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            var userInfo = UserInfoService.Select(u => u.UName == userName && u.UPwd == userPwd).FirstOrDefault();//根据用户名找用户
            if (userInfo != null)
            {
                Model.UserInfoDto userInfoDto = new Model.UserInfoDto
                {
                    Id = userInfo.Id,
                    UName = userInfo.UName,
                    UPwd = userInfo.UPwd
                };

                // Session["userInfo"] = userInfo;
                //产生一个GUID值作为RedisString的键., DateTime.Now.AddMinutes(30)
                string sessionId = Guid.NewGuid().ToString();

                //将登录用户信息存储到RedisString中。直接存userInfo对象，如果存userInfo的json字符串时会存在\转义字符导致序列化失败。
                //延迟加载和Redis string数据类型中存储对象序列化为字符串类型不能很好地混合，
                //如果不小心，只是因为启用了延迟加载，最终就可以对整个数据库进行查询。 大多数序列化程序通过访问类型实例上的每个属性来工作。 属性访问会触发延迟加载，因此会序列化更多的实体。 写入redis string时卡死现象
                //在这些实体上，将访问这些实体的属性，甚至还会加载更多实体。 在对实体进行序列化之前，最好关闭延迟加载。或新建临时实体对象
                //cache.Write<Model.UserInfo>(sessionId, userInfo, DateTime.Now.AddMinutes(30));
                cache.Write<Model.UserInfoDto>(sessionId, userInfoDto, DateTime.Now.AddMinutes(30));
                Response.Cookies["sessionId"].Value = sessionId;//将RedisString中登录用户信息的key以Cookie的形式返回给浏览器。

                return Content("ok:登录成功");
            }
            else
            {

                return Content("no:登录失败");
            }
        }
        #endregion

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");//将验证码加密保存Session["session_verifycode"]中并将未加密验证码在登录界面显示
        }
        #endregion
    }
}