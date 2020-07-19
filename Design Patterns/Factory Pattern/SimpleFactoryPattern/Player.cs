using FactoryPattern.ToyotaMotor.Interface;
using FactoryPattern.ToyotaMotor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    public class Player
    {
        public string Name { get; set; }

        #region 面向细节，产生耦合，不利于扩展
        public void DriveAlphard(Alphard car)
        {
            Console.WriteLine($"{this.Name} driving...");
            car.Drive();
        }
        public void DriveCamry(Camry car)
        {
            Console.WriteLine($"{this.Name} driving...");
            car.Drive();
        }
        public void DriveCorolla(Corolla car)
        {
            Console.WriteLine($"{this.Name} driving...");
            car.Drive();
        }
        #endregion

        #region 面向接口，松耦合，依赖倒置原则：高层模块不应该依赖低层模块，两者都应该依赖其抽象，抽象不应该依赖细节，细节应该依赖抽象。依赖倒置原则的核心就是面向抽象(抽象类或者接口)编程
        public void DriveToyota(IToyota car)
        {
            Console.WriteLine($"{this.Name} driving...");
            car.Drive();
        }
        #endregion



    }
}
