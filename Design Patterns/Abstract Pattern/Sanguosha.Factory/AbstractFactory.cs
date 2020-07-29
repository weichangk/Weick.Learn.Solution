using Sanguosha.Interface;
using Sanguosha.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Factory
{
    /// <summary>
    /// 三国杀抽象工厂
    /// </summary>
    public abstract class AbstractFactory
    {

        public abstract IGroup CreateGroup();
        public abstract IGenerals CreateGenerals();
    }

}
