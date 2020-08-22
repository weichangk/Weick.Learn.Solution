using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        //适配器模式是一种结构形设计模式。将一个类装换成客户期望的另外一个接口，使的原本由于接口不兼容而不能工作的那些类可以一起工作。
        //比如现在有一个旧的软件系统，其中有一个旧组件已经过时了，更新需用到第三方的组件（新组件），但是旧组件的接口和新组件的接口（客户期望的接口）不同，
        //同时，又不想去改变现有旧组件的代码，此时可以通过适配器模式将旧组件集成到新组件中，由新组件向客户提供所期望的接口，这样就无需要改变原来的代码，轻松实现从旧组件更新到新组件了。
        //适配器模式分为类适配器模式（通过继承）和对象适配器模式（通过组合）。
        //组合优于继承

        //举例：IHelper是客户期望的接口类型，但是现在项目需要引入另一个组件（IRedisHelper，RedisHelper），但是该组件提供的接口和客户期望的接口IHelper不兼容，通过适配器模式对引入的组件进行适配集成。




        static void Main(string[] args)
        {

            Console.WriteLine("*****************************");
            {
                IHelper helper = new MysqlHelper();
                helper.Add<Program>();
                helper.Delete<Program>();
                helper.Update<Program>();
                helper.Query<Program>();
            }
            Console.WriteLine("*****************************");
            {
                IHelper helper = new OracleHelper();
                helper.Add<Program>();
                helper.Delete<Program>();
                helper.Update<Program>();
                helper.Query<Program>();
            }

            Console.WriteLine("*****************************");
            {
                IHelper helper = new RedisHelperClass(); //通过类适配器模式将IRedisHelper接口适配为IHelper接口
                helper.Add<Program>();
                helper.Delete<Program>();
                helper.Update<Program>();
                helper.Query<Program>();
            }
            {
                RedisHelperClass helper = new RedisHelperClass();
                helper.Add<Program>();
            }
            Console.WriteLine("*****************************");
            {
                IRedisHelper redisHelper = new RedisHelper();
                IHelper helper = new RedisHelperObject(redisHelper); //通过对象适配器模式将IRedisHelper接口适配为IHelper接口
                helper.Add<Program>();
                helper.Delete<Program>();
                helper.Update<Program>();
                helper.Query<Program>();
            }

            Console.ReadKey();
        }
    }
}
