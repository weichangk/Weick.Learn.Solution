using FactoryPattern.ToyotaMotor.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.ToyotaMotor.ServiceExtend
{
    public class Fujiwara86:IToyota
    {
        public void Drive()
        {
            Console.WriteLine($"{this.GetType().Name} 开着 86 上山了。。。。。。");
        }
    }
}
