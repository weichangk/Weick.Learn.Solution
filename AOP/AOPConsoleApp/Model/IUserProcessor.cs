using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPConsoleApp.Model
{
    public interface IUserProcessor
    {
        void RegUser(User user);
        string GetUser(User user);
    }
}
