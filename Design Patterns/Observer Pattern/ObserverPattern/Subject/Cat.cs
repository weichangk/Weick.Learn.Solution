using ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Subject
{
    public class Cat
    {
        //猫叫，对象耦合
        public void Miao_0()
        {
            Console.WriteLine("{0} Miao 一声", this.GetType().Name);
            //猫叫后想触发一系列后续动作，但是这样写造成对象耦合了，违背了面向对象的开放封闭原则（对象或实体应该对扩展开放，对修改封闭。）
            new Mouse().Run();
            new Dog().Wang();
            new Baby().Cry();
        }




        //观察者对象的具体行为集合（订阅集合）
        private List<IObserver> _ObserverList = new List<IObserver>();
        //添加观察者对象订阅
        public void AddObserver(IObserver observer)
        {
            this._ObserverList.Add(observer);
        }
        //取消观察者对象订阅
        public void RemoveObserver(IObserver observer)
        {
            this._ObserverList.Remove(observer);
        }

        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver 一声", this.GetType().Name);
            //一系列后续动作
            foreach (var observer in this._ObserverList)
            {
                observer.Action();
            }
        }



        //使用事件实现观察者的发布/订阅
        public event Action CatMiaoEvent;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoEvent 一声", this.GetType().Name);
            if (this.CatMiaoEvent != null)
            {
                CatMiaoEvent.Invoke();
            }
        }
    }
}
