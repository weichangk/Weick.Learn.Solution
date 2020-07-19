using FactoryPattern.ToyotaMotor.Interface;
using FactoryPattern.ToyotaMotor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.FactoryMethod
{
    public class CorollaFactory : IFactoryMethod
    {
        public IToyota CreateInstance()
        {
            return new Corolla();
        }
    }
}
