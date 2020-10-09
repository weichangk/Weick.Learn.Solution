using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
	/*
	享元模式（Flyweight）又称为 轻量级模式，它是一种对象结构型模式。
	面向对象技术可以很好地解决一些灵活性或可扩展性问题，但在很多情况下需要在系统中增加类和对象的个数。当对象数量太多时，将导致运行代价过高，带来性能下降等问题。享元模式 正是为解决这一类问题而诞生的。
	享元模式 是对象池的一种实现。类似于线程池，线程池可以避免不停的创建和销毁多个对象，消耗性能。享元模式 也是为了减少内存的使用，避免出现大量重复的创建销毁对象的场景。
	享元模式 的宗旨是共享细粒度对象，将多个对同一对象的访问集中起来，不必为每个访问者创建一个单独的对象，以此来降低内存的消耗。
	享元模式 把一个对象的状态分成内部状态和外部状态，内部状态即是不变的，外部状态是变化的；然后通过共享不变的部分，达到减少对象数量并节约内存的目的。
	享元模式 本质：缓存共享对象，降低内存消耗

	主要解决
	当系统中多处需要同一组信息时，可以把这些信息封装到一个对象中，然后对该对象进行缓存，这样，一个对象就可以提供给多处需要使用的地方，避免大量同一对象的多次创建，消耗大量内存空间。

	享元模式 其实就是 工厂模式 的一个改进机制，享元模式 同样要求创建一个或一组对象，并且就是通过工厂方法生成对象的，只不过 享元模式 中为工厂方法增加了缓存这一功能。

	优缺点
	优点
	享元模式 可以极大减少内存中对象的数量，使得相同对象或相似对象在内存中只保存一份，降低内存占用，增强程序的性能；
	享元模式 的外部状态相对独立，而且不会影响其内部状态，从而使得享元对象可以在不同的环境中被共享；

	缺点
	享元模式 使得系统更加复杂，需要分离出内部状态和外部状态，这使得程序的逻辑复杂化；
	为了使对象可以共享，享元模式 需要将享元对象的状态外部化，而且外部状态必须具备固化特性，不应该随内部状态改变而改变，否则会导致系统的逻辑混乱；
	使用场景
	系统中存在大量的相似对象；
	细粒度的对象都具备较接近的外部状态，而且内部状态与环境无关，也就是说对象没有特定身份；
	需要缓冲池的场景；

	享元模式 主要包含三种角色：
	抽象享元角色（BaseWord）：享元对象抽象基类或者接口，同时定义出对象的外部状态和内部状态的接口或实现；
	具体享元角色（H E L O）：实现抽象角色定义的业务。该角色的内部状态处理应该与环境无关，不能出现会有一个操作改变内部状态，同时修改了外部状态；
	享元工厂（FlyweightFactory）：负责管理享元对象池和创建享元对象；

	ThreadPool 数据库连接池 多次使用相同字符串 应用了享元模式
	*/

	class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Test();

				new Action(Show).BeginInvoke(null, null);
				new Action(ShowHello).BeginInvoke(null, null);

				
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
        }

        private static void Show()
        {
            Console.WriteLine("**********张三********");
            BaseWord h = FlyweightFactory.GetWord(WordType.H);
            BaseWord e = FlyweightFactory.GetWord(WordType.E);
            BaseWord l = FlyweightFactory.GetWord(WordType.L);
            BaseWord o = FlyweightFactory.GetWord(WordType.O);

            Console.WriteLine("{0}{1}{2}{3}{4}",
                h.Display(), e.Display(),
                l.Display(), l.Display(),
                o.Display());
        }


        private static void ShowHello()
        {
            Console.WriteLine("**********李四********");
			BaseWord h = FlyweightFactory.GetWord(WordType.H);
			BaseWord e = FlyweightFactory.GetWord(WordType.E);
			BaseWord l = FlyweightFactory.GetWord(WordType.L);
			BaseWord o = FlyweightFactory.GetWord(WordType.O);

			Console.WriteLine("{0}{1}{2}{3}{4}",
				h.Display(), e.Display(),
				l.Display(), l.Display(),
				o.Display());

		}
		private static void Test()
		{
			string Hello1 = "Hello";//引用类型
			string Hello2 = "Hello";//引用类型

			Console.WriteLine("Hello1==Hello2?                        {0}", Hello1 == Hello2);//比较值
			Console.WriteLine("Hello1.Equals(Hello2)?                 {0}", Hello1.Equals(Hello2));//比较的也是值
			Console.WriteLine("object.ReferenceEquals(Hello1, Hello2)?{0}", object.ReferenceEquals(Hello1, Hello2));//比较的是引用

			string Hello3 = string.Format("Hel{0}", "lo");

			//string Hello2 = "Hel" + "lo";

			Console.WriteLine("Hello1==Hello3?                        {0}", Hello1 == Hello3);//比较值
			Console.WriteLine("Hello1.Equals(Hello3)?                 {0}", Hello1.Equals(Hello3));//比较的也是值
			Console.WriteLine("object.ReferenceEquals(Hello1, Hello3)?{0}", object.ReferenceEquals(Hello1, Hello3));//比较的是引用
		}
    }
}
