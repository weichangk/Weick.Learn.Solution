using Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConsoleApp
{
    /// <summary>
    /// 超卖
    /// 
    ///数据库：秒杀的时候，10件商品，100个人想买，假定大家一瞬间都来了，
    ///A 查询还有没有--有---1更新
    ///B 查询还有没有--有---1更新
    ///C 查询还有没有--有---1更新
    ///可能会卖出12  12甚至20件商品
    ///
    /// 微服务也有超卖的问题，异步队列
    /// </summary>
    public class OversellTest
    {
        private static bool IsGoOn = true;//秒杀活动是否结束
        public static void Show()
        {
            using (RedisStringService service = new RedisStringService())
            {
                service.Set<int>("Stock", 10);//是库存
            }

            for (int i = 0; i < 5000; i++)
            {
                int k = i;
                Task.Run(() =>//每个线程就是一个用户请求
                {
                    using (RedisStringService service = new RedisStringService())
                    {
                        if (IsGoOn)
                        {
                            long index = service.Decr("Stock");
                            if (index >= 0)
                            {
                                Console.WriteLine($"{k.ToString("000")}秒杀成功，秒杀商品索引为{index}");
                                //可以分队列，去数据库操作
                            }
                            else
                            {
                                if (IsGoOn)
                                {
                                    IsGoOn = false;
                                }
                                Console.WriteLine($"{k.ToString("000")}秒杀失败，秒杀商品索引为{index}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{k.ToString("000")}秒杀停止......");
                        }
                    }
                });
            }
            Console.Read();
        }
    }
}
