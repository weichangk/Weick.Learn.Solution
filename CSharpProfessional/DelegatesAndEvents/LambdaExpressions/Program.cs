using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        static void Main()
        {
            SimpleDemos();

            Closure();

            ForeachClosure();

            Console.ReadKey();
        }


        static void SimpleDemos()
        {
            //使用lambda表达式
            Action noParam = () => Console.WriteLine("HHHHHHHHHHHHHHHHHHHHH");
            noParam();

            Func<string> fff = () => "FFFFFFFFFFFFFFFFFFF";
            Console.WriteLine(fff());

            Func<string, string> oneParam = s => String.Format("change uppercase {0}", s.ToUpper());
            Console.WriteLine(oneParam("test"));

            Func<double, double, double> twoParams = (x, y) => x * y;
            Console.WriteLine(twoParams(3, 2));

            Func<double, double, double> twoParamsWithTypes = (double x, double y) => x * y;
            Console.WriteLine(twoParamsWithTypes(4, 2));

            Func<double, double> operations = x => x * 2;
            operations += x => x * x;//lambda不能用+=实现多播，会直接覆盖。

            ProcessAndDisplayNumber(operations, 2.0);
            ProcessAndDisplayNumber(operations, 8.00);
            ProcessAndDisplayNumber(operations, 10.00);
            Console.WriteLine();
        }

        static void ProcessAndDisplayNumber(Func<double, double> action, double value)
        {
            double result = action(value);
            Console.WriteLine(
               "Value is {0}, result of operation is {1}", value, result);

        }


        static void Closure()
        {
            int someVal = 5;
            Func<int, int> f = x => x + someVal;//通过lambda表达式可以访问lambda表达式块外部的变量。这称为闭包。闭包是一个非常好的功能,但如果使用不当,也会非常危险。

            someVal = 7;//可能会在其他地方对lambda表达式访问访问的外部的变量进行了修改，导致lambda表达式中的外部的变量变得不确定

            Console.WriteLine(f(3));
        }


        static void ForeachClosure()
        {
            var values = new List<int>() { 10, 20, 30 };
            var func = new List<Func<int>>();

            foreach (var val in values)
            {
                //var v = val;
                func.Add(() => val);
            }

            foreach (var f in func)
            {
                Console.WriteLine(f());
                //在C#5.0中，这段代码的结果发生了变化。使用C# 4或更早版本的编译器时，会在控制台中输出30三次。
                //解决办法：可以使用中间变量，如上：var v = val;
            }
        }
    }
}
