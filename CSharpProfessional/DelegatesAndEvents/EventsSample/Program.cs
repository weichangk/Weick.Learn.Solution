using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;//订阅事件

            dealer.NewCar("Ferrari");

            var nick = new Consumer("Sebastian");
            dealer.NewCarInfo += nick.NewCarIsHere;

            dealer.NewCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;//注销事件

            dealer.NewCar("Red Bull Racing");


            Console.ReadKey();
        }
    }
}
