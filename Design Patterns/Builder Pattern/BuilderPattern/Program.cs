using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
	//建造者模式
	//一般建造者模式涉及到对象内部复杂的对象构造，实例中使用属性代替
	class Program
    {
        static void Main(string[] args)
        {
			try
			{
				//使用重载构造函数或可选参数构造函数实现简单的建造者模式
				Computer computer = new Computer("Intel", "DDR", 5);
				Console.WriteLine(computer);


				//使用链式调用实现建造者模式；链式调用顺序可变，灵活调用
				ComputerBuilder computerBuilder = new ComputerBuilder.Builder("因特尔", "三星")
				.setDisplay("三星24寸")
				.setKeyboard("罗技")
				.setUsbCount(2)
				.build();
				Console.WriteLine(computerBuilder);


				//使用builder模式
				Console.WriteLine("**********************************");
				{
					AbstractBuilder builder = new BuilderBYD();

					Director director = new Director(builder);
					director.GetCar();
				}
			}
			catch (Exception)
			{

				throw;
			}
			Console.ReadKey();
        }
    }
}
