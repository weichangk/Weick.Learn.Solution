using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Wdj.Redis.Helper;
using System.Threading;
using System.Collections.Generic;

namespace Wdj.Redis.HelperTest
{
    /// <summary>
    /// Redis常用Key 操作方法测试
    /// </summary>
    [TestClass]
    public class KeyTest
    {
        /// <summary>
        /// Redis常用Key 同步操作方法测试
        /// </summary>
        [TestMethod]
        public void TestKeyAction()
        {
            //这里随意获取一个Service
            var redis = RedisHelper.StringService;
            //这里获取整个IDataBase对象进行测试，有了这个实际上可以不需要通过封装方法。而直接操作Redis
            //IDatabase db = redis.GetDatabase();
            ////获取当前dataBase中所有Key
            //var v = db.Execute("KEYS", "*"); 

            //添加一个字符串类型
            bool stringSetValue = redis.StringSet("Key_String", "Key_StringTest1的内容，是字符串类型");
            //断言添加成功
            Assert.IsTrue(stringSetValue);

            //添加一个int类型
            bool intSetValue = redis.StringSet("Key_Int", "111");
            //断言添加成功
            Assert.IsTrue(intSetValue);

            //判断Key是否存在
            bool keyExistsValue = redis.KeyExists("Key_Int");
            //断言存在
            Assert.IsTrue(keyExistsValue);

            //测试修改Key名称
            bool keyRenameValue = redis.KeyRename("Key_Int", "Key_NewInt");
             //断言修改
            Assert.IsTrue(keyRenameValue);
            //判断原Key是否存在
            bool keyExistsValue1 = redis.KeyExists("Key_Int");
            //断言不存在
            Assert.IsFalse(keyExistsValue1);

            //设置过期时间,将修改过的Key  "Key_NewInt"设置过期时间为2秒 ，测试所以时间设置短一点。
            bool keyExpireValue = redis.KeyExpire("Key_NewInt", new TimeSpan(0, 0, 2));
            //断言设置成功
            Assert.IsTrue(keyExpireValue);

            //线程等待3秒后判断Key是否存在
            Thread.Sleep(3000);
            //判断原Key是否存在
            bool keyExistsValue2 = redis.KeyExists("Key_NewInt");
            //断言不存在
            Assert.IsFalse(keyExistsValue2);

            //测试删除
            bool keyDeleteValue = redis.KeyDelete("Key_String");
            //断言删除成功
            Assert.IsTrue(keyDeleteValue);


            //测试批量删除
            List<string> keyList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string _keyName = "ListKey_" + i;
                keyList.Add(_keyName);
                redis.StringSet(_keyName, i.ToString("000"));
            }
            //删除
            long keyListDeleteValue = redis.KeyDelete(keyList.ToArray());
            //断言删除结果为5
            Assert.AreEqual(5, keyListDeleteValue);

            //清空当前DataBase
            redis.KeyFulsh();


        }

        /// <summary>
        /// Redis常用Key 异步操作方法测试
        /// </summary>
        [TestMethod]
        public async Task TestKeyAsync()
        {
            //这里随意获取一个Service
            var redis = RedisHelper.StringService;
            //这里获取整个IDataBase对象进行测试，有了这个实际上可以不需要通过封装方法。而直接操作Redis
            //IDatabase db = redis.GetDatabase();
            //添加一个字符串类型
            bool stringSetValue = await redis.StringSetAsync("Key_String", "Key_StringTest1的内容，是字符串类型");
            //断言添加成功
            Assert.IsTrue(stringSetValue);

            //添加一个int类型
            bool intSetValue = await redis.StringSetAsync("Key_Int", "111");
            //断言添加成功
            Assert.IsTrue(intSetValue);

            //判断Key是否存在
            bool keyExistsValue = await redis.KeyExistsAsync("Key_Int");
            //断言存在
            Assert.IsTrue(keyExistsValue);

            //测试修改Key名称
            bool keyRenameValue = await redis.KeyRenameAsync("Key_Int", "Key_NewInt");
            //断言修改
            Assert.IsTrue(keyRenameValue);
            //判断原Key是否存在
            bool keyExistsValue1 = await redis.KeyExistsAsync("Key_Int");
            //断言不存在
            Assert.IsFalse(keyExistsValue1);

            //设置过期时间,将修改过的Key  "Key_NewInt"设置过期时间为2秒 ，测试所以时间设置短一点。
            bool keyExpireValue = await redis.KeyExpireAsync("Key_NewInt", new TimeSpan(0, 0, 2));
            //断言设置成功
            Assert.IsTrue(keyExpireValue);

            //线程等待3秒后判断Key是否存在
            Thread.Sleep(3000);
            //判断原Key是否存在
            bool keyExistsValue2 = await redis.KeyExistsAsync("Key_NewInt");
            //断言不存在
            Assert.IsFalse(keyExistsValue2);

            //测试删除
            bool keyDeleteValue = await redis.KeyDeleteAsync("Key_String");
            //断言删除成功
            Assert.IsTrue(keyDeleteValue);


            //测试批量删除
            List<string> keyList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string _keyName = "ListKey_" + i;
                keyList.Add(_keyName);
                await redis.StringSetAsync(_keyName, i.ToString("000"));
            }
            //删除
            long keyListDeleteValue = await redis.KeyDeleteAsync(keyList.ToArray());
            //断言删除结果为5
            Assert.AreEqual(5, keyListDeleteValue);

            //清空当前DataBase
            await redis.KeyFulshAsync();

        }


        /// <summary>
        /// Redis 事务测试
        /// </summary>
        [TestMethod]
        public void TestTransaction()
        {
            //这里随意获取一个Service
            var redis = RedisHelper.StringService;
            var tran = redis.CreateTransaction();
            tran.StringSetAsync(redis.AddSysCustomKey("tran_string"), "test1");
            tran.StringSetAsync(redis.AddSysCustomKey("tran_string1"), "test2");
            bool bValue = tran.Execute();
            Assert.IsTrue(bValue);
        }

    }
}
