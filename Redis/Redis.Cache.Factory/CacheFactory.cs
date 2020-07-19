using Redis.Cache.Base;
using Redis.Cache;

namespace Redis.Cache.Factory
{
    /// <summary>
    ///定义缓存工厂类
    /// </summary>
    public class CacheFactory
    {
        public static ICache CaChe()
        {
            return new CacheByRedis();
        }
    }
}
