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
    /// 蜀国工厂
    /// </summary>
    public class FactoryShu: AbstractFactory
    {
        
        public override IGroup CreateGroup()
        {
            return new GroupShu();
        }
        public override IGenerals CreateGenerals()
        {
            return new GeneralsShu();
        }
    }

}
