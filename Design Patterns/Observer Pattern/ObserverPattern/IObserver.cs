using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    //定义观察者行为接口，用来对主题对象订阅和观察者对象的具体行为实现
    public interface IObserver
    {
        void Action();
    }
}
