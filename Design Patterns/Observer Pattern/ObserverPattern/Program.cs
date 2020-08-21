using ObserverPattern.Observer;
using ObserverPattern.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    //观察者模式是一种对象行为模式，有时被称作发布/订阅模式。它定义对象间没有耦合的一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象。
    //主题对象是通知的发布者，它发出通知时并不需要知道谁是它的观察者，可以有任意数目的观察者订阅并接收通知，当一个主题对象的状态发生改变时，所有依赖于它的观察者对象都得到通知并被自动更新。

    //观察者模式在被观察者和观察者之间建立了一个抽象的耦合，被观察者并不知道任何一个具体的观察者，只是保存着抽象观察者的列表，每个具体观察者都符合一个抽象观察者的接口。
    //下面介绍实现观察者模式的两种方法：
    //1.使用面向抽象实现。对观察者行为提供接口；主题对象中提供观察者行为接口的集合用来存放观察者引用（订阅）；通过遍历观察者行为接口集合触发订阅。
    //2.使用Event实现观察者模式。
    class Program
    {
        static void Main(string[] args)
        {
            //一对多的依赖关系有耦合
            Cat cat = new Cat();
            cat.Miao_0();


            //1.使用面向抽象实现观察者模式。对观察者行为提供接口；主题对象中提供观察者行为接口的集合用来存放观察者引用（订阅）；通过遍历观察者行为接口集合触发订阅。
            Console.WriteLine("*************Observer***************");
            {
                cat.AddObserver(new Mouse());
                cat.AddObserver(new Dog());
                cat.AddObserver(new Baby());
                cat.MiaoObserver();
            }

            //2.使用Event实现观察者模式。
            {
                Console.WriteLine("*************Event***************");
                Baby baby = new Baby();
                cat.CatMiaoEvent += new Mouse().Run;
                cat.CatMiaoEvent += new Dog().Wang;
                cat.CatMiaoEvent += baby.Cry;
                cat.MiaoEvent();
                cat.CatMiaoEvent -= baby.Cry;
                cat.MiaoEvent();
            }
            Console.ReadKey();
        }
    }
}
