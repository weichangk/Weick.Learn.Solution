using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAStringDemo
{
    class Program
    {
        private delegate string GetAString();//定义委托

        static void Main()
        {
            int x = 40;
            GetAString firstStringMethod = x.ToString;//声明委托并引用方法
            Console.WriteLine("String is {0}", firstStringMethod());//调用委托；通过委托调用委托引用的方法

            Currency balance = new Currency(34, 50);

            // firstStringMethod references an instance method
            firstStringMethod = balance.ToString;
            Console.WriteLine("String is {0}", firstStringMethod());

            // firstStringMethod references a static method
            firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine("String is {0}", firstStringMethod());

            Console.ReadKey();

        }
    }
}
