using FactoryPattern.ToyotaMotor.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.ToyotaMotor.ServiceExtend
{
    public class Fujiwara85:IToyota
    {
        /// <summary>
        /// 构造过程复杂（85乱改装），使用工厂方法封装，不需要使用者改装。。。。交给工厂完成。。。这应该是工厂存在的意义和职责吧。。。
        /// </summary>
        public Fujiwara85(string name, int id, object special, IToyota IToyota1, IToyota IToyota2, IToyota IToyota3)
        { 
            //我也不懂要怎么装下去了。。。。。。。
        }
        public void Drive()
        {
            Console.WriteLine($"{this.GetType().Name} 开着改装的 85 上山了。。。。。。");
        }
    }
}
