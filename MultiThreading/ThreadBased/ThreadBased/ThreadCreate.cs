using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
    //创建线程
    public class ThreadCreate
    {
        public static void Show()
        {
            Thread t = new Thread(PrintNumbers);//创建线程
            t.Start();//不会马上的执行

            System.Threading.Thread.Sleep(10);//加了延时输出效果差别很大
            PrintNumbers1();
            Console.ReadKey();

        }

        static void PrintNumbers()
        {
            Console.WriteLine("PrintNumbers Starting...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(100);
            }
        }
        static void PrintNumbers1()
        {
            Console.WriteLine("PrintNumbers1 Starting...");
            for (int i = 100; i < 110; i++)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
