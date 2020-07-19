using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Wdj.Redis.Helper;
using Wdj.Redis.HelperTest.Model;
using System.Collections.Generic;

namespace Wdj.Redis.HelperTest
{
    /// <summary>
    /// Redis的List数据结构 操作方法测试
    /// List队列操作一般是左进右出或者右进左出 
    /// </summary>
    [TestClass]
    public class ListTest
    {
        /// <summary>
        /// 同步方法测试
        /// </summary>
        [TestMethod]
        public void TestListAction()
        {
            string key = "ListTestKey";

            //var redis = RedisHelper.ListService;
            var redis = new Helper.Service.RedisListService(6);

            redis.KeyFulsh();



            //左进
            UserModel leftUser = new UserModel() { Id = 1, UserName = "wdj", Age = 33 };
            Assert.AreEqual(1, redis.ListLeftPush<UserModel>(key, leftUser));
            List<UserModel> leftUserList = new List<UserModel>();
            for (int i = 2; i < 5; i++)
            {
                leftUserList.Add(new UserModel { Id = i, UserName = $"Wdj{i}", Age = 33 + i });
            }
            Assert.AreEqual(4, redis.ListLeftPush<UserModel>(key, leftUserList));

            //获取总数
            Assert.AreEqual(4, redis.ListLength(key));
            //获取key中所有集合
            var allUser = redis.ListRange<UserModel>(key);
            Assert.AreEqual(4, allUser.Count);

            //左出
            var leftPopItem = redis.ListLeftPop<UserModel>(key);
            Assert.AreEqual(4, leftPopItem.Id);

            //右出
            var rigthPopItem = redis.ListRightPop<UserModel>(key);
            Assert.AreEqual(1, rigthPopItem.Id);


            //这里Id设置为21，用于区分，后面插入值会用到
            UserModel rightUser = new UserModel() { Id = 21, UserName = "wdj", Age = 33 };


            //右进

            Assert.AreEqual(3, redis.ListRightPush<UserModel>(key, rightUser));
            List<UserModel> rightUserList = new List<UserModel>();
            for (int i = 5; i < 8; i++)
            {
                rightUserList.Add(new UserModel { Id = i, UserName = $"Wdj{i}", Age = 33 + i });
            }
            Assert.AreEqual(6, redis.ListRightPush<UserModel>(key, rightUserList));

            //左出
            var leftPopItem1 = redis.ListLeftPop<UserModel>(key);
            Assert.AreEqual(3, leftPopItem1.Id);

            //右出
            var rigthPopItem1 = redis.ListRightPop<UserModel>(key);
            Assert.AreEqual(7, rigthPopItem1.Id);


            //根据索引获取，我也不知道是哪一条
            var byIndexItem = redis.ListGetByIndex<UserModel>(key, 2);

            //在指定值之前插入一条数据
            UserModel beforeUser = new UserModel() { Id = 20, UserName = "wdj_Before", Age = 33 };
            Assert.AreEqual(5, redis.ListInsertBefore(key, rightUser, beforeUser));


            //在指定值之后插入一条数据
            UserModel afterUser = new UserModel() { Id = 22, UserName = "wdj_After", Age = 33 };
            Assert.AreEqual(6, redis.ListInsertAfter(key, rightUser, afterUser));

            //删除一条数据
            Assert.AreEqual(1, redis.ListRemove(key, rightUser));


            //右出左进另外一个集合，
            string newKey = "ListTestKey_New";
            long listLenght = redis.ListLength(key);
            for (int i = 0; i < listLenght; i++)
            {
                redis.ListRightPopLeftPush<UserModel>(key, newKey);
            }
            var u = redis.ListRightPop<UserModel>(key);
            listLenght = redis.ListLength(key);
            Assert.AreEqual(0, listLenght);

            //测试一下能不能从key又出再从key左进
            UserModel RightPopLeftPushUser = new UserModel() { Id = 20, UserName = "wdj_Before", Age = 33 };
            redis.ListLeftPush(key, RightPopLeftPushUser);
            redis.ListRightPopLeftPush<UserModel>(key, key);
            listLenght = redis.ListLength(key);
            Assert.AreEqual(1, listLenght);
        }

        /// <summary>
        /// 异步方法测试
        /// </summary>
        [TestMethod]
        public async Task TestListAsync()
        {
            string key = "ListTestKey";

            //var redis = RedisHelper.ListService;
            var redis = new Helper.Service.RedisListService();

            redis.KeyFulsh();



            //左进
            UserModel leftUser = new UserModel() { Id = 1, UserName = "wdj", Age = 33 };
            Assert.AreEqual(1, await redis.ListLeftPushAsync<UserModel>(key, leftUser));
            List<UserModel> leftUserList = new List<UserModel>();
            for (int i = 2; i < 5; i++)
            {
                leftUserList.Add(new UserModel { Id = i, UserName = $"Wdj{i}", Age = 33 + i });
            }
            Assert.AreEqual(4, await redis.ListLeftPushAsync<UserModel>(key, leftUserList));

            //获取总数
            Assert.AreEqual(4, await redis.ListLengthAsync(key));
            //获取key中所有集合
            var allUser = await redis.ListRangeAsync<UserModel>(key);
            Assert.AreEqual(4, allUser.Count);

            //左出
            var leftPopItem = await redis.ListLeftPopAsync<UserModel>(key);
            Assert.AreEqual(4, leftPopItem.Id);

            //右出
            var rigthPopItem = await redis.ListRightPopAsync<UserModel>(key);
            Assert.AreEqual(1, rigthPopItem.Id);


            //这里Id设置为21，用于区分，后面插入值会用到
            UserModel rightUser = new UserModel() { Id = 21, UserName = "wdj", Age = 33 };


            //右进

            Assert.AreEqual(3, await redis.ListRightPushAsync<UserModel>(key, rightUser));
            List<UserModel> rightUserList = new List<UserModel>();
            for (int i = 5; i < 8; i++)
            {
                rightUserList.Add(new UserModel { Id = i, UserName = $"Wdj{i}", Age = 33 + i });
            }
            Assert.AreEqual(6, await redis.ListRightPushAsync<UserModel>(key, rightUserList));

            //左出
            var leftPopItem1 = await redis.ListLeftPopAsync<UserModel>(key);
            Assert.AreEqual(3, leftPopItem1.Id);

            //右出
            var rigthPopItem1 = await redis.ListRightPopAsync<UserModel>(key);
            Assert.AreEqual(7, rigthPopItem1.Id);


            //根据索引获取，我也不知道是哪一条
            var byIndexItem = await redis.ListGetByIndexAsync<UserModel>(key, 2);

            //在指定值之前插入一条数据
            UserModel beforeUser = new UserModel() { Id = 20, UserName = "wdj_Before", Age = 33 };
            Assert.AreEqual(5, await redis.ListInsertBeforeAsync(key, rightUser, beforeUser));


            //在指定值之后插入一条数据
            UserModel afterUser = new UserModel() { Id = 22, UserName = "wdj_After", Age = 33 };
            Assert.AreEqual(6, await redis.ListInsertAfterAsync(key, rightUser, afterUser));

            //删除一条数据
            Assert.AreEqual(1, await redis.ListRemoveAsync(key, rightUser));


            //右出左进另外一个集合，
            string newKey = "ListTestKey_New";
            long listLenght = await redis.ListLengthAsync(key);
            for (int i = 0; i < listLenght; i++)
            {
                await redis.ListRightPopLeftPushAsync<UserModel>(key, newKey);
            }
            listLenght = await redis.ListLengthAsync(key);
            Assert.AreEqual(0, listLenght);

        }

    }
}
