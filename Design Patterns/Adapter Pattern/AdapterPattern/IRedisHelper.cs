using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface IRedisHelper
    {
        void AddRedis<T>();
        void DeleteRedis<T>();
        void UpdateRedis<T>();
        void QueryRedis<T>();
    }
}
