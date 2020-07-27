using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWebApi.Models;

namespace ThirdWebApi.Unity.Interface
{
    public interface IUserService
    {
        List<Users> GetList();
    }
}
