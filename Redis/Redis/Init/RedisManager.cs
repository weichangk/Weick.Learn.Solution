using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    /// <summary>
    /// Redis管理中心
    /// </summary>
    public class RedisManager
    {

        /// <summary>
        /// redis配置文件信息
        /// </summary>
        private static readonly RedisConfigInfo RedisConfigInfo = RedisConfigInfo.GetConfig();

        /// <summary>
        /// Redis客户端池化管理
        /// </summary>
        private static PooledRedisClientManager prcManager;

        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }

        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            string[] writeServerList = SplitString(RedisConfigInfo.WriteServerList, ",");
            string[] readServerList = SplitString(RedisConfigInfo.ReadServerList, ",");

            prcManager = new PooledRedisClientManager(readServerList, writeServerList,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = RedisConfigInfo.MaxWritePoolSize,
                                 MaxReadPoolSize = RedisConfigInfo.MaxReadPoolSize,
                                 AutoStart = RedisConfigInfo.AutoStart,
                             });
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            return prcManager.GetClient();
        }

        /// <summary>
        /// 字串转数组
        /// </summary>
        /// <param name="strSource">字串</param>
        /// <param name="split">分隔符</param>
        /// <returns></returns>
        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }
    }
}
