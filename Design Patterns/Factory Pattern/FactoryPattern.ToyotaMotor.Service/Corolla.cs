using FactoryPattern.ToyotaMotor.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.ToyotaMotor.Service
{
    public class Corolla : IToyota
    {
        public void Drive()
        {
            Console.WriteLine($"{this.GetType().Name} is runing...");
        }
    }
}
