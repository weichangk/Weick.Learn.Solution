using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
	//暂停线程；当线程处于休眠状态时,它会占用尽可能少的CPU时间。
	public class ThreadSleep
    {
        public static void Show()
        {
			Thread t = new Thread(PrintNumbersWithDelay);
			t.Start();
			PrintNumbers();
		}

		static void PrintNumbers()
		{
			Console.WriteLine("Starting1...");
			for (int i = 1; i < 10; i++)
			{
				Console.WriteLine(i);
			}
		}

		static void PrintNumbersWithDelay()
		{
			Console.WriteLine("Starting2...");
			for (int i = 1; i < 10; i++)
			{
				//当线程处于休眠状态时,它会占用尽可能少的CPU时间。
				Thread.Sleep(TimeSpan.FromSeconds(2));//线程阻塞暂停
				Console.WriteLine(i);
			}
		}
	}
}
