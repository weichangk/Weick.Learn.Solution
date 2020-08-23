using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
    //线程优先级；线程优先级决定了该线程可占用多少cpu时间
    public class ThreadPriority
    {
		public static void Show()
		{
			Console.WriteLine("Current thread priority: {0}", Thread.CurrentThread.Priority);
			Console.WriteLine("Running on all cores available");
			RunThreads();
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Console.WriteLine("Running on a single core");
			Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
			//为了模拟该情形，我们设置了ProcessorAffinity选项，让操作系统将所有的线程运行在单个CPU核心(第一个核心)上。
			//现在结果完全不同,并且计算耗时将超过2秒钟。这是因为CPU核心大部分时间在运行高优先级的线程，只留给剩下的线程很少的时间来运行。
			RunThreads();
			Console.ReadLine();
		}
		static void RunThreads()
		{
			var sample = new ThreadSample();

			var threadOne = new Thread(sample.CountNumbers);
			threadOne.Name = "ThreadOne";
			var threadTwo = new Thread(sample.CountNumbers);
			threadTwo.Name = "ThreadTwo";

			threadOne.Priority = System.Threading.ThreadPriority.Highest;
			threadTwo.Priority = System.Threading.ThreadPriority.Lowest;
			threadOne.Start();
			threadTwo.Start();

			Thread.Sleep(TimeSpan.FromSeconds(2));
			sample.Stop();
		}

		class ThreadSample
		{
			private bool _isStopped = false;

			public void Stop()
			{
				_isStopped = true;
			}

			public void CountNumbers()
			{
				long counter = 0;

				while (!_isStopped)
				{
					counter++;
				}

				Console.WriteLine("{0} with {1,11} priority " +
							"has a count = {2,13}", Thread.CurrentThread.Name,
							Thread.CurrentThread.Priority,
							counter.ToString("N0"));
			}
		}
	}
}
