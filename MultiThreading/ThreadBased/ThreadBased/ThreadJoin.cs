using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
    //线程等待
    public class ThreadJoin
    {
        public static void Show()
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();//主线程等待子线程终止后继续往下执行；此时主线程处于阻塞状态，实现两线程间的同步执行
            Console.WriteLine("Thread completed");
            Console.ReadLine();
        }

        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine(i);
            }
        }
    }
}
