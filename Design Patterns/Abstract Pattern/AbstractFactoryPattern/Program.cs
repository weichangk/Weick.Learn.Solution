using Sanguosha.Factory;
using Sanguosha.Interface;
using Sanguosha.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{

//抽象工厂
//抽象工厂模式是围绕其他工厂创建的工厂。
//在抽象工厂模式中，接口是负责创建一个相关对象的工厂，不需要显式指定它们的类。每个生成的工厂都能按照工厂模式提供对象。


//业务接口（外部使用接口）
//业务实现（内部具体实现）
//工厂	（构造业务对象，为对象使用者提供获取对象的方法，对象使用者不需要关注对象创建细节）
//抽象工厂（对职责相同的工厂进行抽象）


//扩展其他业务类（产品簇）后增加对应业务类的工厂就可以了，不会对其他工厂产生影响便于维护

//但是需要扩展抽象工厂职责（抽象方法）的话，继承象工厂的所有工厂都需要重写了；

//如果对个别工厂扩展功能的话，可以使扩展功能用接口抽象再继承实现接口；再扩展再提供抽象接口。。。

//c#对类只能单继承，除此之外还能继承多个接口；抽象类提供了对象基本的行为抽象，接口提供了对象花里胡哨的行为扩展。。。

//一般情况下抽象类尽量在设计之初就要考虑好，抽象类应该是稳定的不希望以后被修改。接口也应该使稳定的。
//抽象类的扩展只能修改抽象类，导致所有子类将被修改；接口的扩展可以写另一个接口，子类可按需继承实现扩展

	class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Console.WriteLine("没有使用工厂");
				IGroup group = new GroupShu();
				IGenerals generals = new GeneralsShu();
				group.ShowGroup();
				generals.ShowGenerals();

				Console.WriteLine("使用简单工厂");
				FactoryWei Factory = new FactoryWei();
				IGroup group1 = Factory.CreateGroup();
				IGenerals generals1 = Factory.CreateGenerals();
				group1.ShowGroup();
				generals1.ShowGenerals();

				Console.WriteLine("使用抽象工厂");
				AbstractFactory Factory1 = new FactoryWu();
				IGroup group2 = Factory1.CreateGroup();
				IGenerals generals2 = Factory1.CreateGenerals();
				group2.ShowGroup();
				generals2.ShowGenerals();


				Console.WriteLine("使用抽象工厂：扩展群雄");
				//扩展群雄，只需要添加群雄业务和群雄工厂，扩展方便。
				//但是要扩展抽象工厂职责（抽象方法）比如增加军师，就需要修改抽象工厂，继承了抽象工厂的工厂都要修改
				AbstractFactory FactoryQun = new FactoryQun();
				IGroup groupQun = FactoryQun.CreateGroup();
				IGenerals generalsQun = FactoryQun.CreateGenerals();
				groupQun.ShowGroup();
				generalsQun.ShowGenerals();
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			Console.ReadKey();
        }
    }
}
