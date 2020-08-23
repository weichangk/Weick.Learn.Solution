using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
	//lock关键字可能造成死锁。由于死锁将导致程序停止工作，可以使用Monitor类来避免死锁。
	public class ThreadMonitor
    {
		//第一个线程保持对lockl对象的锁定,等待直到lock2对象被释放。主线程保持对lock2对象的锁定并等待直到lock1对象被释，但lock1对象永远不会被释放，造成死锁。
		public static void DeadlockShow()
		{
			object lock1 = new object();
			object lock2 = new object();
			new Thread(() => LockTooMuch(lock1, lock2)).Start();
			Console.WriteLine("----------------------------------");
			lock (lock2)
			{
				Console.WriteLine("This will be a deadlock!");
				Thread.Sleep(1000);
				lock (lock1)
				{
					Console.WriteLine("Acquired a protected resource succesfully");
				}
			}
		}

		//实际上lock关键字是Monitor类用例的一个语法糖。
		//因此，我们可以直接使用Monitor类。其拥有TryEnter方法，该方法接受一个超时参数。如果在我们能够获取被lock保护的资源之前，超时参数过期，则该方法会返回false。
		public static void MonitorlockShow()
		{
			object lock1 = new object();
			object lock2 = new object();
			new Thread(() => LockTooMuch(lock1, lock2)).Start();
			Console.WriteLine("----------------------------------");
			lock (lock2)
			{
				Thread.Sleep(1000);
				Console.WriteLine("Monitor.TryEnter allows not to get stuck, returning false after a specified timeout is elapsed");
				if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
				{
					Console.WriteLine("Acquired a protected resource succesfully");
				}
				else
				{
					Console.WriteLine("Timeout acquiring a resource!");
				}
			}
		}

		static void LockTooMuch(object lock1, object lock2)
		{
			lock (lock1)
			{
				Thread.Sleep(1000);
				lock (lock2) ;
			}
		}
	}
}
