using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace IOC.Service
{
    public class ApplePhone : IPhone
    {
        [Dependency]//属性注入：不错，但是有对容器的依赖
        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }

        public IPower iPower { get; set; }

        //[InjectionConstructor]
        public ApplePhone()
        {
            Console.WriteLine("{0}构造函数", this.GetType().Name);
        }

        //[InjectionConstructor]//构造函数注入：最好的，默认找参数最多的构造函数
        public ApplePhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0}带参数构造函数", this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name);
        }

        [InjectionMethod]//方法注入：最不好的，增加一个没有意义的方法，破坏封装
        public void Init1234(IPower power)
        {
            this.iPower = power;
        }
    }
}
