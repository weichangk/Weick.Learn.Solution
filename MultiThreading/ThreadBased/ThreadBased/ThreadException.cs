using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
	//线程函数异常
    class ThreadException
    {
		public static void FaultyShow()
		{
			var t = new Thread(FaultyThread);
			t.Start();
			t.Join();

			try
			{
				t = new Thread(BadFaultyThread);
				t.Start();

				BadFaultyThread();//内部异常可以向上抛
			}
			catch (Exception ex)//这里捕获不到线程函数里面的异常，应该在现在函数里做异常处理
			{
				Console.WriteLine("We won't get here!");
			}
		}

		public static void BadFaultyShow()
		{
			try
			{
				var t = new Thread(BadFaultyThread);
				t.Start();

				//BadFaultyThread();//内部异常可以向上抛
			}
			catch (Exception ex)//这里捕获不到线程函数里面的异常，应该在现在函数里做异常处理
			{
				Console.WriteLine("We won't get here!");
			}
		}

		static void BadFaultyThread()
		{
			try
			{
				Console.WriteLine("Starting a BadFaultyThread thread...");
				Thread.Sleep(TimeSpan.FromSeconds(2));
				throw new Exception("Boom!");
			}
			catch (Exception ex)
			{
				throw ex;//可以捕获不处理异常避免应用程序强制结束，不建议隐藏异常！//如果是线程启动，不能向上抛出异常，向上抛上层也捕获不了还是会程序崩溃
			}
		}
		static void FaultyThread()
		{
			try
			{
				Console.WriteLine("Starting a FaultyThread thread...");
				Thread.Sleep(TimeSpan.FromSeconds(1));
				throw new Exception("Boom!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception handled: {0}", ex.Message);
			}
		}
	}
}
