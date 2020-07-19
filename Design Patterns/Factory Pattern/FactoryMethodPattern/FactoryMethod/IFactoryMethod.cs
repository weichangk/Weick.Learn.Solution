using FactoryPattern.ToyotaMotor.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.FactoryMethod
{
    public interface IFactoryMethod
    {
        IToyota CreateInstance();
    }
}
