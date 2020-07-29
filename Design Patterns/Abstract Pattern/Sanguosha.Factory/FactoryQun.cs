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
    /// 扩展群雄工厂
    /// </summary>
    public class FactoryQun : AbstractFactory
    {
        
        public override IGroup CreateGroup()
        {
            return new GroupQun();
        }
        public override IGenerals CreateGenerals()
        {
            return new GeneralsQun();
        }
    }

}
