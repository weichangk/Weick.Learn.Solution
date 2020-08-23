using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
	//前台线程与后台线程；进程会等待所有前台线程都结束后再结束工作，如果只剩下后台程序则直接结束工作
	//默认情况下显示创建的线程为前台线程，如果程序定义了一个不会完成的前台线程，主程序并不会正常结束。
	public class ThreadBackground
    {
        public static void Show()
        {
			var sampleForeground = new ThreadSample(10);
			var sampleBackground = new ThreadSample(20);

			var threadOne = new Thread(sampleForeground.CountNumbers);
			threadOne.Name = "ForegroundThread";
			var threadTwo = new Thread(sampleBackground.CountNumbers);
			threadTwo.Name = "BackgroundThread";
			threadTwo.IsBackground = true;


			threadOne.Start();
			threadTwo.Start();
			Console.ReadLine();//只剩下后台程序则直接结束工作；可以不用等待完全输出，输入按键退出控制台
		}
    }

	class ThreadSample
	{
		private readonly int _iterations;

		public ThreadSample(int iterations)
		{
			_iterations = iterations;
		}
		public void CountNumbers()
		{
			for (int i = 0; i < _iterations; i++)
			{
				Thread.Sleep(TimeSpan.FromSeconds(0.5));
				Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
			}
		}
	}
}
