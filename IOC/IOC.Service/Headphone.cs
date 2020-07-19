using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Service
{
    public class Headphone : IHeadphone
    {
        public Headphone()
        {
            Console.WriteLine("Headphone 被构造");
        }
    }
}
