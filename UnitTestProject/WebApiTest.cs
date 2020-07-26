using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{


    /// <summary>
    /// 调用WebApi就是模拟Http请求，httpwebrequest/httpclient
    /// </summary>
    [TestClass]
    public class WebApiTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result1 = this.GetClient();
            var result2 = this.GetWebQuest();
            var result3 = this.PostClient();
            var result4 = this.PostWebQuest();
            var result5 = this.PutClient();
            var result6 = this.PutWebQuest();
            var result7 = this.DeleteClient();//传值只能是url
            var result8 = this.DeleteWebQuest();

        }


        #region HttpClient Get
        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        private string GetClient()
        {
            //string url = "https://localhost:44315/userapi/users/GetUserByName?username=superman";
            //string url = "https://localhost:44315/userapi/users/GetUserByID?id=1";
            //string url = "https://localhost:44315/userapi/users/GetUserByNameId?userName=Superman&id=1";
            //string url = "https://localhost:44315/userapi/users/Get";
            //string url = "https://localhost:44315/userapi/users/GetUserByModel?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "https://localhost:44315/userapi/users/GetUserByModelUri?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            string url = "https://localhost:44315/userapi/users/GetUserByModelSerialize?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44315/userapi/users/GetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44315/userapi/users/NoGetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            
            
            //var handler = new HttpClientHandler();//{ AutomaticDecompression = DecompressionMethods.GZip };
            //using (var http = new HttpClient(handler))
            //{
            //    var response = http.GetAsync(url).Result;//拿到异步结果
            //    Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
            //    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
            //    return response.Content.ReadAsStringAsync().Result;
            //}


            /// HttpClient
            /// using (var http = new HttpClient(handler)) 不太好 tcp其实并不能立即释放掉
            /// 如果高并发式的这样操作，会出现资源不够  积极拒绝
            /// HttpClient内部有个连接池，各个请求是隔开的，可以复用链接的 实际应该单例一下

            var http = HttpClientFactory.GetHttpClient();
            var response = http.GetAsync(url).Result;//拿到异步结果
            Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                                                    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
            return response.Content.ReadAsStringAsync().Result;
        }


        /// <summary>
        /// 要求HttpClient的实例化都从这里来  全局只要一个实例，不要using
        /// 各个请求是隔开的，可以复用链接的 
        /// </summary>
        public class HttpClientFactory
        {
            private static HttpClient _HttpClient = null;
            static HttpClientFactory()
            {
                _HttpClient = new HttpClient(new HttpClientHandler());
            }
            public static HttpClient GetHttpClient()
            {
                return _HttpClient;
            }
        }
        #endregion

        #region HttpWebRequest实现Get请求
        /// <summary>
        /// HttpWebRequest实现Get请求
        /// </summary>
        private string GetWebQuest()
        {
            //string url = "https://localhost:44315/userapi/users/GetUserByName?username=superman";
            //string url = "https://localhost:44315/userapi/users/GetUserByID?id=1";
            //string url = "https://localhost:44315/userapi/users/GetUserByNameId?userName=Superman&id=1";
            //string url = "https://localhost:44315/userapi/users/Get";
            //string url = "https://localhost:44315/userapi/users/GetUserByModel?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "https://localhost:44315/userapi/users/GetUserByModelUri?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            string url = "https://localhost:44315/userapi/users/GetUserByModelSerialize?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44315/userapi/users/GetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44315/userapi/users/NoGetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 30 * 1000;

            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        #endregion

        #region HttpClient实现Post请求
        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        private string PostClient()
        {
            //string url = "https://localhost:44315/userapi/users/register";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44315/userapi/users/RegisterNoKey";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44315/userapi/users/RegisterUser";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Eleven" },
            //    {"UserEmail","57265177@qq.com" },
            //};

            string url = "https://localhost:44315/userapi/users/RegisterObject";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"User[UserID]","11" },
                {"User[UserName]","Eleven" },
                {"User[UserEmail]","57265177@qq.com" },
                {"Info","this is muti model" }
            };

            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);
                var response = http.PostAsync(url, content).Result;
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                return response.Content.ReadAsStringAsync().Result;
            }

        }
        #endregion

        #region  HttpWebRequest实现post请求
        /// <summary>
        /// HttpWebRequest实现post请求
        /// </summary>
        private string PostWebQuest()
        {
            //string url = "https://localhost:44315/userapi/users/register";
            //var postData = "1";

            //string url = "https://localhost:44315/userapi/users/RegisterNoKey";
            //var postData = "1";

            var user = new
            {
                UserID = "11",
                UserName = "Eleven",
                UserEmail = "57265177@qq.com"
            };
            //string url = "https://localhost:44315/userapi/users/RegisterUser";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "https://localhost:44315/userapi/users/RegisterObject";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "POST";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
        #endregion

        #region HttpClient实现Put请求
        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        private string PutClient()
        {
            string url = "https://localhost:44315/userapi/users/RegisterPut";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"","1" }
            };

            //string url = "https://localhost:44315/userapi/users/RegisterNoKeyPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44315/userapi/users/RegisterUserPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Eleven" },
            //    {"UserEmail","57265177@qq.com" },
            //};

            //string url = "https://localhost:44315/userapi/users/RegisterObjectPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"User[UserID]","11" },
            //    {"User[UserName]","Eleven" },
            //    {"User[UserEmail]","57265177@qq.com" },
            //    {"Info","this is muti model" }
            //};

            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);
                var response = http.PutAsync(url, content).Result;
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                return response.Content.ReadAsStringAsync().Result;
            }

        }
        #endregion

        #region  HttpWebRequest实现put请求
        /// <summary>
        /// HttpWebRequest实现put请求
        /// </summary>
        private string PutWebQuest()
        {
            //string url = "https://localhost:44315/userapi/users/registerPut";
            //var postData = "1";

            //string url = "https://localhost:44315/userapi/users/RegisterNoKeyPut";
            //var postData = "1";

            var user = new
            {
                UserID = "11",
                UserName = "Eleven",
                UserEmail = "57265177@qq.com"
            };
            //string url = "https://localhost:44315/userapi/users/RegisterUserPut";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "https://localhost:44315/userapi/users/RegisterObjectPut";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "PUT";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
        #endregion

        #region HttpClient实现Delete请求
        /// <summary>
        /// HttpClient实现Put请求
        /// 没放入数据
        /// </summary>
        private string DeleteClient()
        {
            string url = "https://localhost:44315/userapi/users/RegisterDelete/1";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"","1" }
            };

            //string url = "https://localhost:44315/userapi/users/RegisterNoKeyDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44315/userapi/users/RegisterUserDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Eleven" },
            //    {"UserEmail","57265177@qq.com" },
            //};

            //string url = "https://localhost:44315/userapi/users/RegisterObjectDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"User[UserID]","11" },
            //    {"User[UserName]","Eleven" },
            //    {"User[UserEmail]","57265177@qq.com" },
            //    {"Info","this is muti model" }
            //};

            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);
                var response = http.DeleteAsync(url).Result;
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        #endregion

        #region  HttpWebRequest实现put请求
        /// <summary>
        /// HttpWebRequest实现put请求
        /// </summary>
        private string DeleteWebQuest()
        {
            //string url = "https://localhost:44315/userapi/users/registerDelete";
            //var postData = "1";

            //string url = "https://localhost:44315/userapi/users/RegisterNoKeyDelete";
            //var postData = "1";

            var user = new
            {
                UserID = "11",
                UserName = "Eleven",
                UserEmail = "57265177@qq.com"
            };
            //string url = "https://localhost:44315/userapi/users/RegisterUserDelete";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "https://localhost:44315/userapi/users/RegisterObjectDelete";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "Delete";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
        #endregion
    }
}
