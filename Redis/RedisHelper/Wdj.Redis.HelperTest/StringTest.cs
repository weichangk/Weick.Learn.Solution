using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Wdj.Redis.HelperTest.Model;

namespace Wdj.Redis.HelperTest
{
    /// <summary>
    /// String数据类型测试
    /// </summary>
    [TestClass]
    public class StringTest
    {
        /// <summary>
        /// 同步方法测试
        /// </summary>
        [TestMethod]
        public void TestStringAction()
        {
            var redis = Helper.RedisHelper.StringService;

            //新增
            Assert.IsTrue(redis.StringSet("Test_String", "Test_String"));
            Assert.IsTrue(redis.StringSet("Test_String1", "Test_String1"));

            Assert.IsTrue(redis.StringSet(new Dictionary<string, string>()
            {
                {"Test_StringList1", "Test_StringList1"},
                {"Test_StringList2", "Test_StringList2"},
                {"Test_StringList3", "Test_StringList3"},
                {"Test_StringList4", "Test_StringList4"}
            }));
            Assert.IsTrue(redis.StringSet<UserModel>("Test_Object", new UserModel { Id = 1, UserName = "Wdj", Age = 33 }));
            Assert.IsTrue(redis.StringSet<UserModel>("Test_Object1", new UserModel { Id = 2, UserName = "Wang", Age = 33 }));

            //追加
            Assert.IsTrue(redis.StringAppend("Test_String1", "_AppendValue") > 0);

            //取值
            Assert.AreEqual("Test_String", redis.StringGet("Test_String"));
            var getListValue = redis.StringGet("Test_StringList1", "Test_StringList2");
            Assert.AreEqual(2, getListValue.Count);

            //取对象
            Assert.IsNotNull(redis.StringGet<UserModel>("Test_Object"));
            var objList = redis.StringGet<UserModel>("Test_Object", "Test_Object1");
            Assert.AreEqual(2, objList.Count);

            //获取旧值赋上新值
            Assert.AreEqual("Test_StringList3", redis.StringGetSet("Test_StringList3", "Test_StringList3_News"));
            Assert.AreEqual(2, redis.StringGetSet<UserModel>("Test_Object1", new UserModel { Id = 2, UserName = "Wang_new", Age = 33 }).Id);

            //获取值的长度
            Assert.AreEqual("Test_StringList4".Length, redis.StringGetLength("Test_StringList4"));


            //数字增长，减少
            redis.KeyDelete("Test_Increment");
            Assert.AreEqual(1, redis.StringIncrement("Test_Increment", 1));
            Assert.AreEqual(3, redis.StringIncrement("Test_Increment", 2));
            Assert.AreEqual(2, redis.StringDecrement("Test_Increment", 1));


        }

        /// <summary>
        /// 异步方法测试
        /// </summary>
        [TestMethod]
        public async Task TestStringAsync()
        {
            var redis = Helper.RedisHelper.StringService;

            //新增
            Assert.IsTrue(await redis.StringSetAsync("Test_String", "Test_String"));
            Assert.IsTrue(await redis.StringSetAsync("Test_String1", "Test_String1"));

            Assert.IsTrue(await redis.StringSetAsync(new Dictionary<string, string>()
            {
                {"Test_StringList1", "Test_StringList1"},
                {"Test_StringList2", "Test_StringList2"},
                {"Test_StringList3", "Test_StringList3"},
                {"Test_StringList4", "Test_StringList4"}
            }));
            Assert.IsTrue(await redis.StringSetAsync<UserModel>("Test_Object", new UserModel { Id = 1, UserName = "Wdj", Age = 33 }));
            Assert.IsTrue(await redis.StringSetAsync<UserModel>("Test_Object1", new UserModel { Id = 2, UserName = "Wang", Age = 33 }));

            //追加
            Assert.IsTrue(await redis.StringAppendAsync("Test_String1", "_AppendValue") > 0);

            //取值
            Assert.AreEqual("Test_String", await redis.StringGetAsync("Test_String"));
            var getListValue = await redis.StringGetAsync("Test_StringList1", "Test_StringList2");
            Assert.AreEqual(2, getListValue.Count);

            //取对象
            Assert.IsNotNull(await redis.StringGetAsync<UserModel>("Test_Object"));
            var objList = await redis.StringGetAsync<UserModel>("Test_Object", "Test_Object1");
            Assert.AreEqual(2, objList.Count);

            //获取旧值赋上新值
            Assert.AreEqual("Test_StringList3", await redis.StringGetSetAsync("Test_StringList3", "Test_StringList3_News"));
            Assert.AreEqual(2, (await redis.StringGetSetAsync<UserModel>("Test_Object1", new UserModel { Id = 2, UserName = "Wang_new", Age = 33 })).Id);

            //获取值的长度
            Assert.AreEqual("Test_StringList4".Length, await redis.StringGetLengthAsync("Test_StringList4"));

            //数字增长，减少
            redis.KeyDelete("Test_IncrementAsync");
            Assert.AreEqual(1, await redis.StringIncrementAsync("Test_IncrementAsync", 1));
            Assert.AreEqual(3, await redis.StringIncrementAsync("Test_IncrementAsync", 2));
            Assert.AreEqual(2, await redis.StringDecrementAsync("Test_IncrementAsync", 1));


        }

    }
}
