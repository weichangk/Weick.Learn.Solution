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
    /// 吴国工厂
    /// </summary>
    public class FactoryWu : AbstractFactory
    {
        public override IGroup CreateGroup()
        {
            return new GroupWu();
        }
        public override IGenerals CreateGenerals()
        {
            return new GeneralsWu();
        }
    }
}
