using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
    public class Consumer
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        //object sender:表示触发事件的对象
        //EventArgs e：表示事件数据的类的基类
        public void NewCarIsHere(object sender, CarInfoEventArgs e)//声明基于指定事件参数的方法；才有资格订阅
        {
            Console.WriteLine("{0}: car {1} is new", name, e.Car);
        }
    }
}
