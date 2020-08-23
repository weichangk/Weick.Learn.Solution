using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
	//lock关键字线程锁，隐患：有可能导致死锁
	class ThreadLock
    {
		public static void Show()
		{
			//多线程访问同一对象（竞争条件）导致数据不安全，
			var c = new Counter();

			var t1 = new Thread(() => TestCounter(c));
			var t2 = new Thread(() => TestCounter(c));
			var t3 = new Thread(() => TestCounter(c));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();
			Console.WriteLine("Incorrect counter");
			Console.WriteLine("Total count: {0}", c.Count);
			Console.WriteLine("--------------------------");


			//如果锁定被多线程访问的对象，需要访问该对象的其他线程会处于阻塞状态，并等待直到该对象解除锁定，确保对象访问的安全性，但是导致严重的性能问题
			var c1 = new CounterWithLock();

			t1 = new Thread(() => TestCounter(c1));
			t2 = new Thread(() => TestCounter(c1));
			t3 = new Thread(() => TestCounter(c1));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();
			Console.WriteLine("Correct counter");
			Console.WriteLine("Total count: {0}", c1.Count);

		}
		static void TestCounter(CounterBase c)//抽象类父类引用指向子类对象
		{
			for (int i = 0; i < 100000; i++)
			{
				c.Increment();
				c.Decrement();
			}
		}
	}



	class Counter : CounterBase
	{
		public int Count { get; private set; }

		public override void Increment()
		{
			Count++;
		}

		public override void Decrement()
		{
			Count--;
		}
	}

	class CounterWithLock : CounterBase//继承抽象类实现抽象方法
	{
		private readonly object _syncRoot = new Object();//线程锁

		public int Count { get; private set; }

		public override void Increment()//重载
		{
			lock (_syncRoot)
			{
				Count++;
			}
		}

		public override void Decrement()
		{
			lock (_syncRoot)
			{
				Count--;
			}
		}
	}

	abstract class CounterBase//抽象类
	{
		public abstract void Increment();//抽象方法

		public abstract void Decrement();
	}
}
