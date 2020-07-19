using IOC.Factory;
using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPower Power = UnityIocHelper.Instance.GetService<IPower>("Power");
            Console.WriteLine();

            IPhone AndroidPhone = UnityIocHelper.Instance.GetService<IPhone>("AndroidPhone");
            AndroidPhone.Call();
            Console.WriteLine();


            IPhone ApplePhone = UnityIocHelper.Instance.GetService<IPhone>("ApplePhone");
            ApplePhone.Call();

            Console.ReadLine();
        }
    }
}
