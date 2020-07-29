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
    /// 魏国工厂
    /// </summary>
    public class FactoryWei : AbstractFactory
    {
        public override IGroup CreateGroup()
        {
            return new GroupWei();
        }
        public override IGenerals CreateGenerals()
        {
            return new GeneralsWei();
        }
    }
}
