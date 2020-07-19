using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Wdj.Redis.Helper;
using System.Collections.Generic;

namespace Wdj.Redis.HelperTest
{
    /// <summary>
    /// Redis的Set 无序数据结构 操作方法测试
    /// </summary>
    [TestClass]
    public class SetTest
    {
        /// <summary>
        /// 同步方法测试
        /// </summary>
        [TestMethod]
        public void TestSetAction()
        {
            var redis = RedisHelper.SetService;
            string key = "Test_SetKey";
            string key1 = "Test_SetKey1";
            string key2 = "Test_SetKey2";
            string[] keyList = new string[] { key, key1, key2 };

            //测试前删除所有Key
            redis.KeyDelete(keyList);

            List<int> valueList1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> valueList2 = new List<int>() { 1, 3, 2, 6, 7, 9 };
            List<int> valueList3 = new List<int>() { 2, 3, 5, 7, 8, 9 };

            //新增
            Assert.IsTrue(redis.SetAdd(key, 1));
            //这里要添加数据个数为6个，实际添加个数为5个，因为1已经存在，Set数据格式数据不会重复
            Assert.AreEqual(valueList1.Count - 1, redis.SetAdd(key, valueList1));
            Assert.AreEqual(valueList2.Count, redis.SetAdd(key1, valueList2));
            Assert.AreEqual(valueList3.Count, redis.SetAdd(key2, valueList3));

            //获取集合中值的数量
            Assert.AreEqual(valueList2.Count, redis.SetLength(key2));
            //判断集合中是否包含指定的值
            Assert.IsTrue(redis.SetContains(key, 1));
            //随机获取一个值
            Assert.IsNotNull(redis.SetRandomMember<int>(key));
            //获取Key中的所有值
            var getValue = redis.SetMembers<int>(key);
            Assert.IsTrue(getValue.Count > 0);

            //获取交叉并集合  Union：并集  Intersect：交集  Difference：差集
            var UnionValue = redis.SetCombineUnion<int>(keyList);
            var IntersectValue = redis.SetCombineIntersect<int>(keyList);
            var DifferenceValue = redis.SetCombineDifference<int>(keyList);
            Assert.AreEqual(9, UnionValue.Count);
            Assert.AreEqual(2, IntersectValue.Count);
            Assert.AreEqual(1, DifferenceValue.Count);

            //获取几个集合的交叉并集合,并保存到一个新Key中
            long combineUnionValue = redis.SetCombineUnionAndStore(key + "_new", keyList);
            long combineIntersectValue = redis.SetCombineIntersectAndStore(key1 + "_new", keyList);
            long combineDifferenceValue = redis.SetCombineDifferenceAndStore(key2 + "_new", keyList);
            Assert.AreEqual(9, combineUnionValue);
            Assert.AreEqual(2, combineIntersectValue);
            Assert.AreEqual(1, combineDifferenceValue);

            //删除
            Assert.AreEqual(1, redis.SetRemove(key, 1));
            Assert.IsNotNull(redis.SetPop<int>(key));


        }

        /// <summary>
        /// 异步方法测试
        /// </summary>
        [TestMethod]
        public async Task TestSetAsync()
        {
            var redis = RedisHelper.SetService;
            string key = "Test_SetKey";
            string key1 = "Test_SetKey1";
            string key2 = "Test_SetKey2";
            string[] keyList = new string[] { key, key1, key2 };

            //测试前删除所有Key
            redis.KeyDelete(keyList);

            List<int> valueList1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> valueList2 = new List<int>() { 1, 3, 2, 6, 7, 9 };
            List<int> valueList3 = new List<int>() { 2, 3, 5, 7, 8, 9 };

            //新增
            Assert.IsTrue(await redis.SetAddAsync(key, 1));
            //这里要添加数据个数为6个，实际添加个数为5个，因为1已经存在，Set数据格式数据不会重复
            Assert.AreEqual(valueList1.Count - 1, await redis.SetAddAsync(key, valueList1));
            Assert.AreEqual(valueList2.Count, await redis.SetAddAsync(key1, valueList2));
            Assert.AreEqual(valueList3.Count, await redis.SetAddAsync(key2, valueList3));

            //获取集合中值的数量
            Assert.AreEqual(valueList2.Count, await redis.SetLengthAsync(key2));
            //判断集合中是否包含指定的值
            Assert.IsTrue(await redis.SetContainsAsync(key, 1));
            //随机获取一个值
            Assert.IsNotNull(await redis.SetRandomMemberAsync<int>(key));
            //获取Key中的所有值
            var getValue = await redis.SetMembersAsync<int>(key);
            Assert.IsTrue(getValue.Count > 0);

            //获取交叉并集合  Union：并集  Intersect：交集  Difference：差集
            var UnionValue = await redis.SetCombineUnionAsync<int>(keyList);
            var IntersectValue = await redis.SetCombineIntersectAsync<int>(keyList);
            var DifferenceValue = await redis.SetCombineDifferenceAsync<int>(keyList);
            Assert.AreEqual(9, UnionValue.Count);
            Assert.AreEqual(2, IntersectValue.Count);
            Assert.AreEqual(1, DifferenceValue.Count);

            //获取几个集合的交叉并集合,并保存到一个新Key中
            long combineUnionValue = await redis.SetCombineUnionAndStoreAsync(key + "_new", keyList);
            long combineIntersectValue = await redis.SetCombineIntersectAndStoreAsync(key1 + "_new", keyList);
            long combineDifferenceValue = await redis.SetCombineDifferenceAndStoreAsync(key2 + "_new", keyList);
            Assert.AreEqual(9, combineUnionValue);
            Assert.AreEqual(2, combineIntersectValue);
            Assert.AreEqual(1, combineDifferenceValue);

            //删除
            Assert.AreEqual(1, await redis.SetRemoveAsync(key, 1));
            Assert.IsNotNull(await redis.SetPopAsync<int>(key));

        }

    }
}
