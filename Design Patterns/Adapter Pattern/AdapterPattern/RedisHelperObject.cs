using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 通过组合  对象适配器模式
    /// </summary>
    public class RedisHelperObject : IHelper
    {
        private IRedisHelper _RedisHelper = null;
        public RedisHelperObject(IRedisHelper redisHelper)
        {
            this._RedisHelper = redisHelper;
        }

        public void Add<T>()
        {
            this._RedisHelper.AddRedis<T>();
        }

        public void Delete<T>()
        {
            this._RedisHelper.DeleteRedis<T>();
        }

        public void Update<T>()
        {
            this._RedisHelper.UpdateRedis<T>();
        }

        public void Query<T>()
        {
            this._RedisHelper.QueryRedis<T>();
        }
    }
}
