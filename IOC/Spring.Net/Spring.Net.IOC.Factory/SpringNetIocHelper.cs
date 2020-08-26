using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net.IOC.Factory
{
    public class SpringNetIocHelper
    {
        public static T GetService<T>(string serviceName)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            return (T)ctx.GetObject(serviceName);
        }
    }
}
