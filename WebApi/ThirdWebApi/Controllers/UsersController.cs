using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThirdWebApi.Models;
using ThirdWebApi.Unity.Interface;

namespace ThirdWebApi.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _iUserService = null;
        private List<Users> _userList = null;

        public UsersController(IUserService userService)//userService将在ioc中通过配置依赖注入
        {
            this._iUserService = userService;
            this._userList = this._iUserService.GetList();
        }


        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _userList;
        }
    }
}
