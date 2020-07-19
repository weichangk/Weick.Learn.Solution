using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 私有化构造函数
    /// 私有静态只读变量
    /// 静态构造函数（不能有访问修饰符）对私有静态只读变量创建对象：由CLR自行调用，在第一次使用这个类之前，调用而且只调用一次
    /// 提供一个访问该实例的全局访问点（单例对象获取的静态方法）
    /// 目的：让使用者无须也不能通过构造函数创建对象；只能通过设计者提供的单例对象获取的静态方法获取单例对象（返回私有的自身类型的静态变量对象）
    /// </summary>
    public class SingletonSecond
    {
        private SingletonSecond()
        {
            Thread.Sleep(1000);//耗时
            //string bigSize = "占用10M内存";//耗计算资源
            //string resource = "占用多个线程和数据库连接资源";//耗有限资源
            Console.WriteLine("{0}被构造，线程id={1}", this.GetType().Name, Thread.CurrentThread.ManagedThreadId);
        }

        private static readonly SingletonSecond _Singleton = null;

        /// <summary>
        /// 静态构造函数：由CLR自行调用，在第一次使用这个类之前，调用而且只调用一次
        /// </summary>
        static SingletonSecond()
        {
            _Singleton = new SingletonSecond();
        }
        public static SingletonSecond CreateInstance()
        {
            return _Singleton;
        }


        public void Show()
        {
            Console.WriteLine("这里调用了{0}.Show", this.GetType().Name);
        }
    }
}
