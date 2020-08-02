using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegates
{
    delegate double DoubleOp(double x);//定义委托

    class Program
    {
        static void Main()
        {
            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
             };//声明委托数组；存储多个方法

            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value)//委托类型做参数；可接受与委托方法签名一样的方法；实现方法做参数
        {
            double result = action(value);
            Console.WriteLine(
               "Value is {0}, result of operation is {1}", value, result);
        }
    }
}
