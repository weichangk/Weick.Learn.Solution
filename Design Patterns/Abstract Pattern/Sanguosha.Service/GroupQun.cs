using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 扩展群雄武将主公
    /// </summary>
    public class GroupQun : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine($"{this.GetType().Name} is 张角");
        }
    }
}
