using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Service
{
    public class Power : IPower
    {
        public Power()
        {
            Console.WriteLine("Power 被构造");
        }
    }
}
