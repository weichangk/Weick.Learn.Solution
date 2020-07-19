using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Memcache
{
    public class MemcacheCache
    {
        private static readonly MemcacheConfig memcachedConfigInfo = MemcacheConfig.GetConfig();
        private static readonly MemcachedClient mc = null;
        static MemcacheCache()
        {
            string[] serverlist = SplitString(memcachedConfigInfo.ServerList, ","); ;
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.InitConnections = memcachedConfigInfo.InitConnections;
            pool.MinConnections = memcachedConfigInfo.MinConnections;
            pool.MaxConnections = memcachedConfigInfo.MaxConnections;
            pool.SocketConnectTimeout = memcachedConfigInfo.SocketConnectTimeout;
            pool.SocketTimeout = memcachedConfigInfo.SocketTimeout;
            pool.MaintenanceSleep = memcachedConfigInfo.MaintenanceSleep;
            pool.Failover = memcachedConfigInfo.Failover;
            pool.Nagle = memcachedConfigInfo.Nagle;
            pool.Initialize();
            // 获得客户端实例
            mc = new MemcachedClient
            {
                EnableCompression = memcachedConfigInfo.EnableCompression
            };
        }
        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }
        public static bool Set(string key, object value)
        {
            return mc.Set(key, value);
        }
        public static bool Set(string key, object value, DateTime time)
        {
            return mc.Set(key, value, time);
        }
        public static object Get(string key)
        {
            return mc.Get(key);
        }
        public static bool Delete(string key)
        {
            if (mc.KeyExists(key))
            {
                return mc.Delete(key);

            }
            return false;
        }
        public static bool IsExists(string key)
        {
            return mc.KeyExists(key);
        }
    }
}
