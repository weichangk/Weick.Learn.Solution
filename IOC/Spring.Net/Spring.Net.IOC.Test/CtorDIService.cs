using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net.IOC.Test
{
    public class CtorDIService : ICtorDIService
    {
        public string FirstName { get; set; }
        public string ShowMsg()
        {
            return FirstName;
        }

        public CtorDIService(string firstName)
        {
            FirstName = firstName;
        }

    }
}
