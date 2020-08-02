using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeakEventsGenericSample
{
    //弱事件：
    //动态创建订阅器时，为了避免出现资源泄露，必须特别留意事件。也就是说，需要在订阅器离开作用域(不再需要它)之前，确保取消对事件的订阅。另一种方法就是使用弱事件。
    //通过事件，直接连接到发布程序和侦听器。但垃圾回收有一个问题。例如，如果侦听器不再直,接引用，发布程序就仍有一个引用。垃圾回收器不能清空侦听器占用的内存，因为发布程序仍保有一个引用，会针对侦听器触发事件。
    //这种强连接可以通过弱事件模式来解决,即使用WeakEventManager作为发布程序和侦听器之间的中介。
    public class Consumer : IWeakEventListener//提供事件侦听
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine("{0}: car {1} is new", name, e.Car);
        }

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventArgs);
            return true;
        }


    }
}
