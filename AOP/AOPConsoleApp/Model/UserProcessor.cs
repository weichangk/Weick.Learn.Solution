using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPConsoleApp.Model
{
    public class UserProcessor : IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("用户已注册。");
        }
        public string GetUser(User user)
        {
            return $"Id:{user.Id} Name:{user.Name} Password:{user.Password}";
        }
    }
}
