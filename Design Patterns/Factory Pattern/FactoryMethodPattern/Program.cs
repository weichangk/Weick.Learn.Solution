using FactoryMethodPattern.FactoryMethod;
using FactoryPattern.ToyotaMotor.Interface;
using FactoryPattern.ToyotaMotor.Service;
using SimpleFactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player Player = new Player()
                {
                    Name = "菜虚鲲"
                };

                {
                    //不使用接口创建对象
                    Alphard Alphard = new Alphard();
                    Camry Camry = new Camry();
                    Corolla Corolla = new Corolla();
                }
                {
                    //使用接口创建对象，要习惯面向接口面向抽象编程。。。
                    IToyota Alphard = new Alphard();
                    IToyota Camry = new Camry();
                    IToyota Corolla = new Corolla();
                }
                {
                    //使用工厂方法创建对象，是否感觉多此一举？代码量还变多了。。。
                    //目前也不懂什么具体场合会使用到这种设计模式。。。先做个了解不必深究。。。知识点是分散的。。。多了解“高逼格的编程模式”才会提高代码阅读能力。。。         
                    //这种设计模式对于对象使用者无须关注对象创建细节并且对象创建复杂的情况适用
                    IFactoryMethod AlphardFactory = new AlphardFactory();
                    IToyota Alphard = AlphardFactory.CreateInstance();

                    IFactoryMethod CamryFactory = new CamryFactory();
                    IToyota Camry = CamryFactory.CreateInstance();

                    IFactoryMethod CorollaFactory = new CorollaFactory();
                    IToyota Corolla = CorollaFactory.CreateInstance();


                    IFactoryMethod Fujiwara85Factory = new Fujiwara85Factory();
                    IToyota Fujiwara85 = Fujiwara85Factory.CreateInstance();

                    Player.DriveToyota(Alphard);
                    Console.WriteLine();
                    Player.DriveToyota(Camry);
                    Console.WriteLine();
                    Player.DriveToyota(Corolla);
                    Console.WriteLine();
                    Player.DriveToyota(Fujiwara85);
                    Console.WriteLine();

                    //使用扩展工厂
                    IFactoryMethod Fujiwara85Factory_plus = new Fujiwara85FactoryExtend();
                    IToyota Fujiwara85_plus = Fujiwara85Factory_plus.CreateInstance();
                    Player.DriveToyota(Fujiwara85_plus);

                    Console.WriteLine("*******************面向接口，依赖工厂方法，上层使用者不需要自行实例化下层对象，只需从对应工厂类拿对象********************");
                    Console.WriteLine();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
