using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
	public class UseInterlocked
    {
		public static void Show()
		{
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



			var c1 = new CounterNoLock();
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
		static void TestCounter(CounterBase c)
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
		private int _count;

		public int Count { get { return _count; } }

		public override void Increment()
		{
			_count++;
		}

		public override void Decrement()
		{
			_count--;
		}
	}

	class CounterNoLock : CounterBase
	{
		private int _count;

		public int Count { get { return _count; } }

		public override void Increment()
		{
			Interlocked.Increment(ref _count);//Interlocked类，为多线程共享变量提供原子操作，无需用LOCK防止死锁
		}

		public override void Decrement()
		{
			Interlocked.Decrement(ref _count);
		}
	}

	abstract class CounterBase
	{
		public abstract void Increment();

		public abstract void Decrement();
	}
}
