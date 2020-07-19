using Redis.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisBackServiceConsoleApp
{
    public class StackExchangeProcessor
    {
        public static void Show()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string tag = path.Split('/', '\\').Last(s => !string.IsNullOrEmpty(s));
            Console.WriteLine($"这里是 {tag} 启动了。。");
            using (RedisListService service = new RedisListService())
            {
                Action act = new Action(() =>
                {
                    while (true)
                    {
                        //var result = service.BlockingPopItemFromLists(new string[] { "test", "task" }, TimeSpan.FromHours(3));
                        //Thread.Sleep(5000);
                        //Console.WriteLine($"这里是 {tag} 队列获取的消息 {result.Id} {result.Item}");
                    }
                });
                act.EndInvoke(act.BeginInvoke(null, null));
            }
        }

    }
}
