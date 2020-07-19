using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wdj.Redis.ConsoleTest
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static int testNumber = 10000;
        static void Main(string[] args)
        {

            ReadWriteTest();

            //ListTest();

            Console.ReadLine();
        }
        /// <summary>
        /// 读写测试
        /// </summary>
        static void ReadWriteTest()
        {            
            string key = "TestTimeKey";
            var redis = Helper.RedisHelper.StringService;
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            for (int i = 0; i < testNumber; i++)
            {
                redis.StringSet(key, new UserModel { Id = 1, UserName = $"wdj{i}号" });
                //redis.StringSet(key, "wdj");
            }
            sw.Stop();
            Console.WriteLine($"写{testNumber}次共耗时：{sw.ElapsedMilliseconds}毫秒");


            sw.Restart();
            for (int i = 0; i < testNumber; i++)
            {
                redis.StringGet(key);
            }
            sw.Stop();
            Console.WriteLine($"读{testNumber}次共耗时：{sw.ElapsedMilliseconds}毫秒");

            sw.Restart();
            for (int i = 0; i < testNumber; i++)
            {
                redis.StringSet(key, new UserModel { Id = 1, UserName = $"wdj{i}号" });
                //redis.StringSet(key, "wdj");
                redis.StringGet(key);
            }
            sw.Stop();
            Console.WriteLine($"读写{testNumber}次共耗时：{sw.ElapsedMilliseconds}毫秒");
        }

        /// <summary>
        /// 测试Reids队列
        /// </summary>
        static void ListTest()
        {
            var redis = Helper.RedisHelper.ListService;
            string key = "List_TestKey";

            //开5个监控线程
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        var user = redis.ListRightPop<UserModel>(key);
                        if (null != user)
                        {
                            Console.WriteLine($"我是线程 [{Thread.CurrentThread.ManagedThreadId}], 处理了 [{user.Id}_{user.UserName}]");
                            //Thread.Sleep(1000);
                        }
                        //Thread.Sleep(1000);
                    }
                });
            }


            Console.Write("请输入测试人姓名：");
            while (true)
            {
                string wValue = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(wValue))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        redis.ListLeftPush<UserModel>(key,
                            new UserModel { Id = i, UserName = $"{wValue}{i}号" });
                    }
                }
            }
        }
    }

    #region model
    /// <summary>
    /// 测试用户实体模型
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
    #endregion
}
