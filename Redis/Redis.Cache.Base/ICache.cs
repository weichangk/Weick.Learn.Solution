using System;

namespace Redis.Cache.Base
{
    /// <summary>
    ///定义缓存接口
    /// </summary>
    public interface ICache
    {
        #region Key-Value
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        T Read<T>(string cacheKey, long dbId = 0) where T : class;
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        void Write<T>(string cacheKey, T value, long dbId = 0) where T : class;
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void Write<T>(string cacheKey, T value, DateTime expireTime, long dbId = 0) where T : class;
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void Write<T>(string cacheKey, T value, TimeSpan timeSpan, long dbId = 0) where T : class;
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        void Remove(string cacheKey, long dbId = 0);
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        void RemoveAll(long dbId = 0);
        #endregion
    }
}
