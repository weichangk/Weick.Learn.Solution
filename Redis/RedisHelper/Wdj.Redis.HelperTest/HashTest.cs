using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Wdj.Redis.Helper;
using Wdj.Redis.HelperTest.Model;
using System.Collections.Generic;

namespace Wdj.Redis.HelperTest
{
    /// <summary>
    /// Redis常用Hash数据类型 操作方法测试
    /// </summary>
    [TestClass]
    public class HashTest
    {
        /// <summary>
        /// 同步方法测试
        /// </summary>
        [TestMethod]
        public void TestHashAction()
        {
            var redis = RedisHelper.HashService;
            string key = "Test_HaskKey";
            string listKey = "Test_HasklistKey";
            string incrementKey = "Test_HaskIncrementKey";

            UserModel user1 = new UserModel()
            {
                Age = 33,
                Id = 1,
                UserName = "Wdj"
            };
            UserModel user2 = new UserModel()
            {
                Age = 33,
                Id = 2,
                UserName = "Wang"
            };

            List<UserModel> userList = new List<UserModel>()
            {
                user1,user2
            };

            //添加
            Assert.IsTrue(redis.HashSet<UserModel>(key, "user1", user1));
            Assert.IsTrue(redis.HashSet<UserModel>(key, "user2", user2));
            Assert.IsTrue(redis.HashSet(listKey, "userList", userList));

            //是否存在
            Assert.IsTrue(redis.HashExists(key, "user1"));
            Assert.IsTrue(redis.HashExists(key, "user2"));
            Assert.IsTrue(redis.HashExists(listKey, "userList"));

            //获取
            Assert.AreEqual(user1.Id, redis.HashGet<UserModel>(key, "user1").Id);
            Assert.AreEqual(userList.Count, redis.HashGet<List<UserModel>>(listKey, "userList").Count);

            //获取所有Key
            Assert.AreEqual(2, redis.HashKeys(key).Length);

            //获取所有Key与值
            var dicList = redis.HashGetAll<UserModel>(key);
            Assert.AreEqual(2, dicList.Count);

            //递增，递减
            Assert.AreEqual(1, redis.HashIncrement(incrementKey, "Increment"));
            Assert.AreEqual(3, redis.HashIncrement(incrementKey, "Increment", 2));
            Assert.AreEqual(2, redis.HashDecrement(incrementKey, "Increment"));
            Assert.AreEqual(0, redis.HashDecrement(incrementKey, "Increment", 2));

            //删除
            Assert.IsTrue(redis.HashDelete(listKey, "userList"));

            Assert.AreEqual(2, redis.HashDelete(key, "user2", "user1"));

        }

        /// <summary>
        /// 异步方法测试
        /// </summary>
        [TestMethod]
        public async Task TestHashAsync()
        {
            var redis = RedisHelper.HashService;
            string key = "Test_HaskAsyncKey";
            string listKey = "Test_HaskAsynclistKey";
            string incrementKey = "Test_HaskAsyncIncrementKey";

            UserModel user1 = new UserModel()
            {
                Age = 33,
                Id = 1,
                UserName = "Wdj"
            };
            UserModel user2 = new UserModel()
            {
                Age = 33,
                Id = 2,
                UserName = "Wang"
            };

            List<UserModel> userList = new List<UserModel>()
            {
                user1,user2
            };

            //添加
            Assert.IsTrue(await redis.HashSetAsync<UserModel>(key, "user1", user1));
            Assert.IsTrue(await redis.HashSetAsync<UserModel>(key, "user2", user2));
            Assert.IsTrue(await redis.HashSetAsync(listKey, "userList", userList));

            //是否存在
            Assert.IsTrue(await redis.HashExistsAsync(key, "user1"));
            Assert.IsTrue(await redis.HashExistsAsync(key, "user2"));
            Assert.IsTrue(await redis.HashExistsAsync(listKey, "userList"));

            //获取
            Assert.AreEqual(user1.Id, (await redis.HashGetAsync<UserModel>(key, "user1")).Id);
            Assert.AreEqual(userList.Count, (await redis.HashGetAsync<List<UserModel>>(listKey, "userList")).Count);

            //获取所有Key
            Assert.AreEqual(2, (await redis.HashKeysAsync(key)).Length);

            //获取所有Key与值
            var dicList = await redis.HashGetAllAsync<UserModel>(key);
            Assert.AreEqual(2, dicList.Count);

            //递增，递减
            Assert.AreEqual(1, await redis.HashIncrementAsync(incrementKey, "Increment"));
            Assert.AreEqual(3, await redis.HashIncrementAsync(incrementKey, "Increment", 2));
            Assert.AreEqual(2, await redis.HashDecrementAsync(incrementKey, "Increment"));
            Assert.AreEqual(0, await redis.HashDecrementAsync(incrementKey, "Increment", 2));

            //删除
            Assert.IsTrue(redis.HashDelete(listKey, "userList"));

            Assert.AreEqual(2, redis.HashDelete(key, "user2", "user1"));

        }
    }
}
