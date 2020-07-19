using FactoryPattern.ToyotaMotor.Interface;
using FactoryPattern.ToyotaMotor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
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
                    //面向细节，依赖细节
                    Alphard Alphard = new Alphard();
                    Camry Camry = new Camry();
                    Corolla Corolla = new Corolla();

                    Player.DriveAlphard(Alphard);
                    Player.DriveCamry(Camry);
                    Player.DriveCorolla(Corolla);
                    Console.WriteLine("*******************面向细节，依赖细节，上层使用者自行实例化下层对象并使用********************");
                    Console.WriteLine();
                }


                {
                    //面向接口，依赖细节
                    IToyota Alphard = new Alphard();
                    IToyota Camry = new Camry();
                    IToyota Corolla = new Corolla();

                    Player.DriveToyota(Alphard);
                    Player.DriveToyota(Camry);
                    Player.DriveToyota(Corolla);
                    Console.WriteLine("*******************面向接口，依赖细节，上层使用者自行实例化下层对象并使用********************");
                    Console.WriteLine();
                }


                {
                    //面向接口，依赖工厂；使用枚举参数做对象选择条件
                    IToyota Alphard = ToyotaFactory.CreateInstance(ToyotaFactory.ToyotaType.Alphard);
                    IToyota Camry = ToyotaFactory.CreateInstance(ToyotaFactory.ToyotaType.Camry);
                    IToyota Corolla = ToyotaFactory.CreateInstance(ToyotaFactory.ToyotaType.Corolla);

                    Player.DriveToyota(Alphard);
                    Player.DriveToyota(Camry);
                    Player.DriveToyota(Corolla);
                    Console.WriteLine("*******************面向接口，依赖工厂；使用枚举参数做对象选择条件，上层使用者不需要自行实例化下层对象，只需要按需从工厂类拿对象********************");
                    Console.WriteLine();
                }

                {
                    //面向接口，依赖工厂；使用配置做对象选择条件
                    IToyota car = ToyotaFactory.CreateInstanceConfig();
                    Player.DriveToyota(car);

                    Console.WriteLine("*******************面向接口，依赖工厂；使用配置做对象选择条件，上层使用者不需要自行实例化下层对象，只需要按需从工厂类拿对象********************");
                    Console.WriteLine();
                }

                {
                    //面向接口，依赖工厂；使用配置+反射(方便扩展)做对象选择条件
                    IToyota car = ToyotaFactory.CreateInstanceConfigReflection();
                    Player.DriveToyota(car);

                    Console.WriteLine("*******************面向接口，依赖工厂；使用配置+反射(方便扩展)做对象选择条件，上层使用者不需要自行实例化下层对象，只需要按需从工厂类拿对象********************");
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
