using Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisConsoleApp
{
    /// <summary>
    /// ServiceStack API封装测试  五大结构理解
    /// </summary>
    public class ServiceStackTest
    {
        public static void Show()
        {

            Console.WriteLine("*****************************************");
            {
                ////key-value  get/set  Append GetAndSetValue Incr DecrBy
                ////为啥花里胡哨？ 不仅少一次命令，这个redis提供的操作，可以原子性操作
                ////不可分割，一定成功/失败，不会中间状态
                ////GetAndSetValue 如果两步，高并发时，可能别的请求改了
                ////数据库：秒杀的时候，10件商品，100个人想买，假定大家一瞬间都来了，
                ////A 查询还有没有--有---1更新
                ////B 查询还有没有--有---1更新
                ////C 查询还有没有--有---1更新
                ////可能会卖出12  12甚至20件商品
                ////程序中处理，lock  单线程（多服务器呢）
                ////Redis
                //using (RedisStringService service = new RedisStringService())
                //{
                //    service.Set<string>("student1", "梦的翅膀");
                //    Console.WriteLine(service.Get("student1"));

                //    service.Append("student1", "20180802");
                //    Console.WriteLine(service.Get("student1"));

                //    Console.WriteLine(service.GetAndSetValue("student1", "程序错误"));
                //    Console.WriteLine(service.Get("student1"));

                //    service.Set<string>("student2", "王", DateTime.Now.AddSeconds(5));
                //    Thread.Sleep(5100);
                //    Console.WriteLine(service.Get("student2"));

                //    service.Set<int>("Age", 32);
                //    Console.WriteLine(service.Incr("Age"));
                //    Console.WriteLine(service.IncrBy("Age", 3));
                //    Console.WriteLine(service.Decr("Age"));
                //    Console.WriteLine(service.DecrBy("Age", 3));
                //}
            }

            Console.WriteLine("*****************************************");
            {
                ////key-value局限性：一个对象序列化保存--读出来反序列化--修改---序列化保存
                ////空间浪费问题：默认空间  即使value就是一个1  也要那么多空间
                ////缓存用户id-name

                ////hashtable：一个解决序列化的问题
                ////可以更节约内存空间，一个hash保存多个key-value  IdNameMapping----id-name
                //using (RedisHashService service = new RedisHashService())
                //{
                //    service.SetEntryInHash("student", "id", "123456");
                //    service.SetEntryInHash("student", "name", "张xx");
                //    service.SetEntryInHash("student", "remark", "高级班的学员");

                //    var keys = service.GetHashKeys("student");
                //    var values = service.GetHashValues("student");
                //    var keyValues = service.GetAllEntriesFromHash("student");
                //    Console.WriteLine(service.GetValueFromHash("student", "id"));

                //    service.SetEntryInHashIfNotExists("student", "name", "太子爷");
                //    service.SetEntryInHashIfNotExists("student", "description", "高级班的学员2");

                //    Console.WriteLine(service.GetValueFromHash("student", "name"));
                //    Console.WriteLine(service.GetValueFromHash("student", "description"));
                //    service.RemoveEntryFromHash("student", "description");
                //    Console.WriteLine(service.GetValueFromHash("student", "description"));
                //}
            }
            Console.WriteLine("*****************************************");
            {
                ////Set居然有顺序了，，疑难问题

                ////Set:key-List<value>  去重  用户ip记录； 关键词;
                //using (RedisSetService service = new RedisSetService())
                //{
                //    service.FlushAll();//清理全部数据

                //    service.Add("advanced", "111");
                //    service.Add("advanced", "112");
                //    service.Add("advanced", "114");
                //    service.Add("advanced", "114");
                //    service.Add("advanced", "115");
                //    service.Add("advanced", "115");
                //    service.Add("advanced", "113");

                //    var result = service.GetAllItemsFromSet("advanced");

                //    var random = service.GetRandomItemFromSet("advanced");//随机获取
                //    service.GetCount("advanced");//独立的ip数
                //    service.RemoveItemFromSet("advanced", "114");

                //    {
                //        service.Add("begin", "111");
                //        service.Add("begin", "112");
                //        service.Add("begin", "115");

                //        service.Add("end", "111");
                //        service.Add("end", "114");
                //        service.Add("end", "113");

                //        var result1 = service.GetIntersectFromSets("begin", "end");
                //        var result2 = service.GetDifferencesFromSet("begin", "end");
                //        var result3 = service.GetUnionFromSets("begin", "end");
                //        //共同好友   共同关注
                //    }
                //}
            }
            Console.WriteLine("*****************************************");
            {
                //using (RedisZSetService service = new RedisZSetService())
                //{
                //    //去重   而且自带排序   排行榜/统计全局排行榜  
                //    service.FlushAll();//清理全部数据

                //    service.Add("advanced", "1");
                //    service.Add("advanced", "2");
                //    service.Add("advanced", "5");
                //    service.Add("advanced", "4");
                //    service.Add("advanced", "7");
                //    service.Add("advanced", "5");
                //    service.Add("advanced", "9");

                //    var result1 = service.GetAll("advanced");
                //    var result2 = service.GetAllDesc("advanced");

                //    service.AddItemToSortedSet("Sort", "BY", 123234);
                //    service.AddItemToSortedSet("Sort", "走自己的路", 123);
                //    service.AddItemToSortedSet("Sort", "redboy", 45);
                //    service.AddItemToSortedSet("Sort", "大蛤蟆", 7567);
                //    service.AddItemToSortedSet("Sort", "路人甲", 9879);
                //    var result3 = service.GetAllWithScoresFromSortedSet("Sort");

                //    //交叉并
                //}
            }

            Console.WriteLine("*****************************************");
            {
                using (RedisListService service = new RedisListService())
                {
                    //service.FlushAll();

                    //service.Add("article", "eleven1234");
                    //service.Add("article", "kevin");
                    //service.Add("article", "大叔");
                    //service.Add("article", "C卡");
                    //service.Add("article", "触不到的线");
                    //service.Add("article", "程序错误");

                    //var result1 = service.Get("article");
                    //var result2 = service.Get("article", 0, 3);
                    ////可以按照添加顺序自动排序；而且可以分页获取

                    //1 内存操作，分页   最新微博  最新评论  最近登录用户
                    //个人blog  第一页为了速度，直接读redis；还需要继续读，说明真的感兴趣，那得去把数据库读一下
                    //80%的请求  都在20%数据上    
                    //一个list可以放入2的32次方  20亿条数据



                    ////栈
                    //service.FlushAll();

                    //service.Add("article", "eleven1234");
                    //service.Add("article", "kevin");
                    //service.Add("article", "大叔");
                    //service.Add("article", "C卡");
                    //service.Add("article", "触不到的线");
                    //service.Add("article", "程序错误");

                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine(service.PopItemFromList("article"));
                    //    var result1 = service.Get("article");
                    //}




                    //// 队列：生产者消费者模型
                    //service.FlushAll();
                    //service.RPush("article", "eleven1234");
                    //service.RPush("article", "kevin");
                    //service.RPush("article", "大叔");
                    //service.RPush("article", "C卡");
                    //service.RPush("article", "触不到的线");
                    //service.RPush("article", "程序错误");

                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine(service.PopItemFromList("article"));
                    //    var result1 = service.Get("article");
                    //}
                    ////分布式缓存，多服务器都可以访问到，多个生产者，多个消费者，任何产品只被消费一次
                }

                #region 生产者消费者
                using (RedisListService service = new RedisListService())
                {
                    //List<string> stringList = new List<string>();
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    stringList.Add(string.Format($"放入任务{i}"));
                    //}

                    //service.Add("test", "这是一个学生Add1");
                    //service.Add("test", "这是一个学生Add2");
                    //service.Add("test", "这是一个学生Add3");

                    //service.LPush("test", "这是一个学生LPush1");
                    //service.LPush("test", "这是一个学生LPush2");
                    //service.LPush("test", "这是一个学生LPush3");
                    //service.LPush("test", "这是一个学生LPush4");
                    //service.LPush("test", "这是一个学生LPush5");
                    //service.LPush("test", "这是一个学生LPush6");

                    //service.RPush("test", "这是一个学生RPush1");
                    //service.RPush("test", "这是一个学生RPush2");
                    //service.RPush("test", "这是一个学生RPush3");
                    //service.RPush("test", "这是一个学生RPush4");
                    //service.RPush("test", "这是一个学生RPush5");
                    //service.RPush("test", "这是一个学生RPush6");
                    //service.Add("task", stringList);

                    //Console.WriteLine(service.Count("test"));
                    //Console.WriteLine(service.Count("task"));
                    //var list = service.Get("test");
                    //list = service.Get("task", 2, 4);

                    //Action act = new Action(() =>
                    //{
                    //    while (true)
                    //    {
                    //        Console.WriteLine("************请输入数据**************");
                    //        string testTask = Console.ReadLine();
                    //        service.LPush("test", testTask);
                    //    }
                    //});
                    //act.EndInvoke(act.BeginInvoke(null, null));
                }
                #endregion



                #region 发布订阅:观察者，一个数据源，多个接受者，只要订阅了就可以收到的，能被多个数据源共享
                Task.Run(() =>
                {
                    using (RedisListService service = new RedisListService())
                    {
                        service.Subscribe("Eleven", (c, message, iRedisSubscription) =>
                        {
                            Console.WriteLine($"注册{1}{c}:{message}，Dosomething else");
                            if (message.Equals("exit"))
                                iRedisSubscription.UnSubscribeFromChannels("Eleven");
                        });//blocking
                    }
                });
                Task.Run(() =>
                {
                    using (RedisListService service = new RedisListService())
                    {
                        service.Subscribe("Eleven", (c, message, iRedisSubscription) =>
                        {
                            Console.WriteLine($"注册{2}{c}:{message}，Dosomething else");
                            if (message.Equals("exit"))
                                iRedisSubscription.UnSubscribeFromChannels("Eleven");
                        });//blocking
                    }
                });
                Task.Run(() =>
                {
                    using (RedisListService service = new RedisListService())
                    {
                        service.Subscribe("Twelve", (c, message, iRedisSubscription) =>
                        {
                            Console.WriteLine($"注册{3}{c}:{message}，Dosomething else");
                            if (message.Equals("exit"))
                                iRedisSubscription.UnSubscribeFromChannels("Twelve");
                        });//blocking
                    }
                });
                using (RedisListService service = new RedisListService())
                {
                    Thread.Sleep(1000);

                    service.Publish("Eleven", "Eleven123");
                    service.Publish("Eleven", "Eleven234");
                    service.Publish("Eleven", "Eleven345");
                    service.Publish("Eleven", "Eleven456");

                    service.Publish("Twelve", "Twelve123");
                    service.Publish("Twelve", "Twelve234");
                    service.Publish("Twelve", "Twelve345");
                    service.Publish("Twelve", "Twelve456");
                    Console.WriteLine("**********************************************");

                    service.Publish("Eleven", "exit");

                    service.Publish("Eleven", "123Eleven");
                    service.Publish("Eleven", "234Eleven");
                    service.Publish("Eleven", "345Eleven");
                    service.Publish("Eleven", "456Eleven");

                    service.Publish("Twelve", "exit");
                    service.Publish("Twelve", "123Twelve");
                    service.Publish("Twelve", "234Twelve");
                    service.Publish("Twelve", "345Twelve");
                    service.Publish("Twelve", "456Twelve");
                }
                #endregion
            }
        }
    }
}
