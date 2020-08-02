using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
    public class CarInfoEventArgs : EventArgs//自定义事件类；无参数时可以直接用EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }

        public string Car { get; private set; }
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;//类中声明事件；发布事件；提供外部订阅+=和注销-=
        //事件基于委托，为委托提供了一种发布/订阅的机制

        public void NewCar(string car)
        {
            Console.WriteLine("CarDealer, new car {0}", car);

            RaiseNewCarInfo(car);//触发事件；外部订阅事件的函数将被执行；
        }

        protected virtual void RaiseNewCarInfo(string car)
        {
            EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
            if (newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }
}
