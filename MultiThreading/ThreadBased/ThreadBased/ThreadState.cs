using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
    //检测线程状态
    public class ThreadState
    {
        public static void Show()
        {
			Console.WriteLine("Starting program...");
			Thread t = new Thread(PrintNumbersWithStatus);
			Thread t2 = new Thread(DoNothing);
			Console.WriteLine(t.ThreadState.ToString());
			t2.Start();
			t.Start();
			for (int i = 1; i < 30; i++)
			{
				Console.WriteLine(t.ThreadState.ToString());
			}
			Thread.Sleep(TimeSpan.FromSeconds(6));
			t.Abort();
			Console.WriteLine("A thread has been aborted");
			Console.WriteLine(t.ThreadState.ToString());
			Console.WriteLine(t2.ThreadState.ToString());
			Console.ReadLine();
		}

		static void DoNothing()
		{
			Thread.Sleep(TimeSpan.FromSeconds(2));
		}

		static void PrintNumbersWithStatus()
		{
			Console.WriteLine("Starting...");
			Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
			for (int i = 1; i < 10; i++)
			{
				Thread.Sleep(TimeSpan.FromSeconds(2));
				Console.WriteLine(i);
			}
		}
	}
}
