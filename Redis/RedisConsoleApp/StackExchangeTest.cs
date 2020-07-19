using Redis.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisConsoleApp
{
    public class StackExchangeTest
    {
        public static void Show()
        {

            Console.WriteLine("*****************************************");
            {
                //key  value 都是string   假如是个对象呢？序列化一下
                //假如要修改某一个属性的值   读--反序列化--修改--序列化 memcached
                using (RedisStringService service = new RedisStringService())
                {
                    service.KeyFulsh();
                    service.StringSet("RedisStringService_key1", "RedisStringService_value1");
                    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                    Console.WriteLine(service.StringGetSet("RedisStringService_key1", "RedisStringService_value2"));
                    Console.WriteLine(service.StringGet("RedisStringService_key1"));

                    service.StringAppend("RedisStringService_key1", "Append");
                    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                    service.StringSet("RedisStringService_key1", "RedisStringService_value", new TimeSpan(0, 0, 0, 5));
                    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                    Thread.Sleep(5000);
                    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                }
            }

            //保存 查询对象：
            //Student_2_id  12  Student_2_Name Twelve
            // 序列化后保存一个对象没问题，
            //查询--反序列化--修改--序列化--保存

            Console.WriteLine("*****************************************");
            {
                using (RedisHashService service = new RedisHashService())
                {
                    //service.KeyFulsh();
                    //service.SetEntryInHash("lisi", "id", "15");

                    //service.SetEntryInHash("zhangsan", "id", "13");
                    //service.SetEntryInHash("zhangsan", "Name", "Thirteen");
                    //service.SetEntryInHashIfNotExists("zhangsan", "Remark", "1234567");
                    //var value13 = service.GetHashValues("zhangsan");
                    //var key13 = service.GetHashKeys("zhangsan");

                    //var dicList = service.GetAllEntriesFromHash("zhangsan");

                    //service.SetEntryInHash("zhangsan", "id", "14");//同一条数据，覆盖
                    //service.SetEntryInHash("zhangsan", "Name", "Fourteen");
                    //service.SetEntryInHashIfNotExists("zhangsan", "Remark", "2345678");//同一条数据，不覆盖
                    //service.SetEntryInHashIfNotExists("zhangsan", "Other", "234543");//没有数据就添加
                    //service.SetEntryInHashIfNotExists("zhangsan", "OtherField", "1235665");


                    //var value14 = service.GetHashValues("zhangsan");
                    //service.RemoveEntryFromHash("zhangsan", "Remark");
                    //service.SetEntryInHashIfNotExists("zhangsan", "Remark", "2345678");
                    //value14 = service.GetHashValues("zhangsan");

                    //service.StoreAsHash<Student>(student_1);
                    //Student student1 = service.GetFromHash<Student>(11);
                    //service.StoreAsHash<Student>(student_2);
                    //Student student2 = service.GetFromHash<Student>(12);
                }
            }
            Console.WriteLine("*****************************************");
            {
                //using (RedisSetService service = new RedisSetService())
                //{
                //    //key--values
                //     service.KeyFulsh();
                //    service.Add("Advanced", "111");
                //    service.Add("Advanced", "112");
                //    service.Add("Advanced", "113");
                //    service.Add("Advanced", "115");
                //    service.Add("Advanced", "114");
                //    service.Add("Advanced", "111");

                //    service.Add("Begin", "111");
                //    service.Add("Begin", "112");
                //    service.Add("Begin", "113");
                //    service.Add("Begin", "117");
                //    service.Add("Begin", "116");
                //    service.Add("Begin", "111");

                //    service.Add("Internal", "111");
                //    service.Add("Internal", "112");
                //    service.Add("Internal", "117");
                //    service.Add("Internal", "119");
                //    service.Add("Internal", "118");
                //    service.Add("Internal", "111");

                //    var result = service.GetAllItemsFromSet("Advanced");
                //    var result2 = service.GetRandomItemFromSet("Advanced");
                //    result = service.GetAllItemsFromSet("Begin");
                //    result2 = service.GetRandomItemFromSet("Begin");

                //    var result3 = service.GetIntersectFromSets("Advanced", "Begin");//交
                //    result3 = service.GetDifferencesFromSet("Advanced", "Begin", "Internal");//差
                //    result3 = service.GetUnionFromSets("Advanced", "Begin", "Internal");//并

                //    service.RemoveItemFromSet("Advanced", "111");
                //    result = service.GetAllItemsFromSet("Advanced");
                //    service.RandomRemoveItemFromSet("Advanced");
                //    result = service.GetAllItemsFromSet("Advanced");
                //}
            }
            Console.WriteLine("*****************************************");
            {
                //using (RedisZSetService service = new RedisZSetService())
                //{
                //     service.KeyFulsh();
                //    service.Add("score", "111");
                //    service.Add("score", "112");
                //    service.Add("score", "113");
                //    service.Add("score", "114");
                //    service.Add("score", "115");
                //    service.Add("score", "111");

                //    service.AddItemToSortedSet("user", "Eleven1", 1);
                //    service.AddItemToSortedSet("user", "Eleven2", 2);
                //    service.AddItemToSortedSet("user", "Eleven3", 5);
                //    service.AddItemToSortedSet("user", "Eleven4", 3);
                //    service.AddItemToSortedSet("user", "1Eleven2", 4);


                //    var list = service.GetAll("score");
                //    var listDesc = service.GetAllDesc("score");

                //    var user = service.GetAll("user");
                //    var userDesc = service.GetAllDesc("user");
                //}
            }
            Console.WriteLine("*****************************************");
            {
                using (RedisListService service = new RedisListService())
                {
                    service.KeyFulsh();

                    List<string> stringList = new List<string>();
                    for (int i = 0; i < 10; i++)
                    {
                        stringList.Add(string.Format($"放入任务{i}"));
                    }

                    service.ListLeftPush("test", "这是一个学生1");
                    service.ListLeftPush("test", "这是一个学生2");
                    service.ListLeftPush("test", "这是一个学生3");
                    service.ListLeftPush("test", "这是一个学生4");
                    service.ListLeftPush("test", "这是一个学生5");
                    service.ListLeftPush("test", "这是一个学生6");

                    service.ListLeftPush("task", stringList);

                    Console.WriteLine(service.ListLength("test"));
                    Console.WriteLine(service.ListLength("task"));
                    var list = service.ListRange<string>("test");

                    Action act = new Action(() =>
                    {
                        while (true)
                        {
                            Console.WriteLine("************请输入数据**************");
                            string testTask = Console.ReadLine();
                            service.ListLeftPush("test", testTask);
                        }
                    });
                    act.EndInvoke(act.BeginInvoke(null, null));
                }
            }
        }
    }
}
