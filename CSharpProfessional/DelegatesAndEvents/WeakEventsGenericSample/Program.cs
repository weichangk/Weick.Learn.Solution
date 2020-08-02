using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeakEventsGenericSample
{
    class Program
    {
        static void Main(string[] args)
        {

            //通过事件，直接连接到发布程序和侦听器。但垃圾回收有一个问题。例如，如果侦听器不再直接引用，发布程序就仍有一个引用。垃圾回收器不能清空侦听器占用的内存，因为发布程序仍保有一个引用，会针对侦听器触发事件。
            //使用弱事件侦听器;为了避免出现资源泄露


            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", michael.NewCarIsHere);

            dealer.NewCar("Mercedes");

            var sebastian = new Consumer("Sebastian");
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", sebastian.NewCarIsHere);

            dealer.NewCar("Ferrari");

            WeakEventManager<CarDealer, CarInfoEventArgs>.RemoveHandler(dealer, "NewCarInfo", michael.NewCarIsHere);

            dealer.NewCar("Red Bull Racing");


            Console.ReadKey();
        }
    }
}
