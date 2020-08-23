using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBased
{
	//带参数线程
	class ThreadParam
    {
		public static void Show()
		{
			var sample = new ThreadParamSample(3);
			var threadOne = new Thread(sample.CountNumbers);//无参线程
			threadOne.Name = "ThreadOne";
			threadOne.Start();
			threadOne.Join();

			Console.WriteLine("--------------------------");

			var threadTwo = new Thread(Count);//带参线程，线程启动的方法必须接收object类型的单个参数
			threadTwo.Name = "ThreadTwo";
			threadTwo.Start(5);
			threadTwo.Join();

			Console.WriteLine("--------------------------");

			var threadThree = new Thread(() => CountNumbers(8));//使用lambda表达式可是不用object类型的单个参数；使用lambda表达式引用对象的方式被称为闭包，当表达式中使用任何局部变量，C#会自动生成类，并将该变量作为类的属性。
			threadThree.Name = "ThreadThree";
			threadThree.Start();
			threadThree.Join();
			Console.WriteLine("--------------------------");


			//注意：存在问题，如果在多个lambda表达式中使用相同变量，他们会共享该变量值。
			int i = 10;
			var threadFour = new Thread(() => PrintNumber(i));
			i = 20;
			var threadFive = new Thread(() => PrintNumber(i));


			threadFour.Start();
			threadFive.Start();
		}


		static void Count(object iterations)
		{
			CountNumbers((int)iterations);
		}

		static void CountNumbers(int iterations)
		{
			for (int i = 1; i <= iterations; i++)
			{
				Thread.Sleep(TimeSpan.FromSeconds(0.5));
				Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
			}
		}

		static void PrintNumber(int number)
		{
			Console.WriteLine(number);
		}


	}

	class ThreadParamSample
	{
		private readonly int _iterations;

		public ThreadParamSample(int iterations)
		{
			_iterations = iterations;
		}
		public void CountNumbers()
		{
			for (int i = 1; i <= _iterations; i++)
			{
				Thread.Sleep(TimeSpan.FromSeconds(0.5));
				Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
			}
		}
	}
}
