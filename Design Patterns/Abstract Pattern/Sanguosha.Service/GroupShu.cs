using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 蜀国主公
    /// </summary>
    public class GroupShu : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine($"{this.GetType().Name} is 刘备");
        }
    }
}
