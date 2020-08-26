using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net.IOC.Test
{
    class UserInfoService : IUserInfoService
    {
        public string FirstName { get; set; }
        public Person Person { get; set; }
        public string ShowMsg()
        {
            return "Hello World";
        }

        public string ShowMsg1()
        {
            return  FirstName + ";  Age: " + Person.Age;
        }
    }
}
