using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<IAsyncResult> resultList = new List<IAsyncResult>();
                for (int i = 0; i < 10; i++)
                {
                    resultList.Add(new Action(() =>
                    {
                        Singleton singleton = Singleton.CreateInstance();
                        singleton.Show();
                    }).BeginInvoke(null, null));//会启动一个异步多线程调用
                }

                while (resultList.Count(r => !r.IsCompleted) > 0)
                {
                    Thread.Sleep(10);
                }


                for (int i = 0; i < 10; i++)
                {
                    resultList.Add(new Action(() =>
                    {
                        //SingletonSecond singleton = SingletonSecond.CreateInstance();
                        SingletonThird singleton = SingletonThird.CreateInstance();
                        singleton.Show();
                    }).BeginInvoke(null, null));//会启动一个异步多线程调用
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
