using FactoryPattern.ToyotaMotor.Interface;
using FactoryPattern.ToyotaMotor.Service;
using FactoryPattern.ToyotaMotor.ServiceExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.FactoryMethod
{
    public class Fujiwara85Factory : IFactoryMethod
    {
        public virtual IToyota CreateInstance()
        {
            return new Fujiwara85("装个86的发动机",100,new object(),new Camry(),new Corolla(),new Alphard());//一些具体业务;改装有点复杂。。。。
        }

    }

    /// <summary>
    /// 工厂方法的一个作用：对象创建提供可扩展点
    /// 扩展的工厂；为了满足另一种需求的改装。。。。
    /// </summary>
    public class Fujiwara85FactoryExtend : Fujiwara85Factory
    {
        public override IToyota CreateInstance()
        {
            Console.WriteLine("给85装个Benz的方向盘。。。。");//一些具体业务;改装有点蛋疼。。。。
            return base.CreateInstance();
        }
    }
}
