using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 魏国主公
    /// </summary>
    public class GroupWei : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine($"{this.GetType().Name} is 曹操");
        }
    }
}
