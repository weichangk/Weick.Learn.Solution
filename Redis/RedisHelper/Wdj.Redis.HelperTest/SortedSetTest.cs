using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Wdj.Redis.Helper;
using System.Collections.Generic;

namespace Wdj.Redis.HelperTest
{
    /// <summary>
    /// Redis的SortedSet有序数据结构 操作方法测试
    /// </summary>
    [TestClass]
    public class SortedSetTest
    {
        /// <summary>
        /// 同步方法测试
        /// </summary>
        [TestMethod]
        public void TestSortedSetAction()
        {
            var redis = RedisHelper.SortedSetService;
            string key = "Test_SortedSetKey";
            string key1 = "Test_SortedSetKey1";
            string key2 = "Test_SortedSetKey2";
            string[] keyList = new string[] { key, key1, key2 };

            List<int> valueList1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> valueList2 = new List<int>() { 1, 3, 2, 6, 7, 9 };
            List<int> valueList3 = new List<int>() { 2, 3, 5, 7, 8, 9 };

            redis.KeyFulsh();

            Assert.IsTrue(redis.SortedSetAdd<int>(key, 1, 1));

            Assert.AreEqual(5, redis.SortedSetAdd<int>(key, valueList1));
            Assert.AreEqual(valueList2.Count, redis.SortedSetAdd(key1, valueList2));
            Assert.AreEqual(valueList3.Count, redis.SortedSetAdd(key2, valueList3));

            Assert.AreEqual(6, redis.SortedSetLength(key));
            Assert.AreEqual(4, redis.SortedSetLengthByValue(key, 2, 5));

            double? scoreValue = redis.SortedSetScore<int>(key, 3);
            Assert.IsNotNull(scoreValue);
            Assert.AreEqual(4, scoreValue);

            Assert.AreEqual(2, redis.SortedSetMinScore(key));
            Assert.AreEqual(7, redis.SortedSetMaxScore(key));


            var byRankValue = redis.SortedSetRangeByRank<int>(key);
            var byRankValue1 = redis.SortedSetRangeByRank<int>(key, 1, 1, true);
            var byRankWithScoresValue = redis.SortedSetRangeByRankWithScores<int>(key1);
            var byRankWithScoresValue1 = redis.SortedSetRangeByRankWithScores<int>(key1, 0, 3);

            var byScoreValue = redis.SortedSetRangeByScore<int>(key);
            var byScoreValue1 = redis.SortedSetRangeByScore<int>(key, 1, 1, true);
            var byScoreWithScoresValue = redis.SortedSetRangeByScoreWithScores<int>(key1);
            var byScoreWithScoresValue1 = redis.SortedSetRangeByScoreWithScores<int>(key1, 0, 3);

            var byValueValue = redis.SortedSetRangeByValue<int>(key2, 3, 7);

            //获取几个集合的交叉并集合,并保存到一个新Key中
            long combineUnionValue = redis.SortedSetCombineUnionAndStore(key + "_new", keyList);
            Assert.AreEqual(9, combineUnionValue);

            long combineIntersectValue = redis.SortedSetCombineIntersectAndStore(key1 + "_new", keyList);
            Assert.AreEqual(2, combineIntersectValue);

            //查看源码，并不支持该Difference操作
            //long combineDifferenceValue = redis.SortedSetCombineDifferenceAndStore(key2 + "_new", key,key1);
            //Assert.AreEqual(1, combineDifferenceValue);

            double decrementValue = redis.SortedSetDecrement<int>(key1, 2, 3);
            double incrementValue = redis.SortedSetIncrement<int>(key2, 2, 1);

            long removeValue = redis.SortedSetRemove<int>(key, 4);
            long removeRangeByValue = redis.SortedSetRemoveRangeByValue<int>(key, 4, 5);
            long removeRangeByRank = redis.SortedSetRemoveRangeByRank(key1, 1, 2);
            long removeRangeByScore = redis.SortedSetRemoveRangeByScore(key1, 1, 2);

        }

        /// <summary>
        /// 异步方法测试
        /// </summary>
        [TestMethod]
        public async Task TestSortedSetAsync()
        {
            var redis = RedisHelper.SortedSetService;
            string key = "Test_SortedSetKey";
            string key1 = "Test_SortedSetKey1";
            string key2 = "Test_SortedSetKey2";
            string[] keyList = new string[] { key, key1, key2 };

            List<int> valueList1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> valueList2 = new List<int>() { 1, 3, 2, 6, 7, 9 };
            List<int> valueList3 = new List<int>() { 2, 3, 5, 7, 8, 9 };

            redis.KeyFulsh();

            Assert.IsTrue(await redis.SortedSetAddAsync<int>(key, 1, 1));

            Assert.AreEqual(5, await redis.SortedSetAddAsync<int>(key, valueList1));
            Assert.AreEqual(valueList2.Count, await redis.SortedSetAddAsync(key1, valueList2));
            Assert.AreEqual(valueList3.Count, await redis.SortedSetAddAsync(key2, valueList3));

            Assert.AreEqual(6, await redis.SortedSetLengthAsync(key));
            Assert.AreEqual(4, await redis.SortedSetLengthByValueAsync(key, 2, 5));

            double? scoreValue = await redis.SortedSetScoreAsync<int>(key, 3);
            Assert.IsNotNull(scoreValue);
            Assert.AreEqual(4, scoreValue);

            Assert.AreEqual(2, await redis.SortedSetMinScoreAsync(key));
            Assert.AreEqual(7, await redis.SortedSetMaxScoreAsync(key));


            var byRankValue = await redis.SortedSetRangeByRankAsync<int>(key);
            var byRankValue1 = await redis.SortedSetRangeByRankAsync<int>(key, 1, 1, true);
            var byRankWithScoresValue = await redis.SortedSetRangeByRankWithScoresAsync<int>(key1);
            var byRankWithScoresValue1 = await redis.SortedSetRangeByRankWithScoresAsync<int>(key1, 0, 3);

            var byScoreValue = await redis.SortedSetRangeByScoreAsync<int>(key);
            var byScoreValue1 = await redis.SortedSetRangeByScoreAsync<int>(key, 1, 1, true);
            var byScoreWithScoresValue = await redis.SortedSetRangeByScoreWithScoresAsync<int>(key1);
            var byScoreWithScoresValue1 = await redis.SortedSetRangeByScoreWithScoresAsync<int>(key1, 0, 3);

            var byValueValue = await redis.SortedSetRangeByValueAsync<int>(key2, 3, 7);

            //获取几个集合的交叉并集合,并保存到一个新Key中
            long combineUnionValue = await redis.SortedSetCombineUnionAndStoreAsync(key + "_new", keyList);
            Assert.AreEqual(9, combineUnionValue);

            long combineIntersectValue = await redis.SortedSetCombineIntersectAndStoreAsync(key1 + "_new", keyList);
            Assert.AreEqual(2, combineIntersectValue);

            //long combineDifferenceValue = await  redis.SortedSetCombineDifferenceAndStoreAsync(key2 + "_new", keyList);
            //Assert.AreEqual(1, combineDifferenceValue);

            double decrementValue = await redis.SortedSetDecrementAsync<int>(key1, 2, 3);
            double incrementValue = await redis.SortedSetIncrementAsync<int>(key2, 2, 1);

            long removeValue = await redis.SortedSetRemoveAsync<int>(key, 4);
            long removeRangeByValue = await redis.SortedSetRemoveRangeByValueAsync<int>(key, 4, 5);
            long removeRangeByRank = await redis.SortedSetRemoveRangeByRankAsync(key1, 1, 2);
            long removeRangeByScore = await redis.SortedSetRemoveRangeByScoreAsync(key1, 1, 2);

        }

    }
}
