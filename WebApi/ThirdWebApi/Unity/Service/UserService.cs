using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThirdWebApi.Models;
using ThirdWebApi.Unity.Interface;

namespace ThirdWebApi.Unity.Service
{
    public class UserService : IUserService
    {
        private DbContext _DbContext = null;
        public UserService(DbContext context)//context将在ioc中通过配置依赖注入
        {
            this._DbContext = context;
        }

        public List<Users> GetList()
        {
            List<Users> _userList = new List<Users>
             {
                 new Users {UserID = 1, UserName = "Superman", UserEmail = "Superman@cnblogs.com"},
                 new Users {UserID = 2, UserName = "Spiderman", UserEmail = "Spiderman@cnblogs.com"},
                 new Users {UserID = 3, UserName = "Batman", UserEmail = "Batman@cnblogs.com"}
            };
            return _userList;
        }
    }
}