using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 蜀国武将
    /// </summary>
    public class GeneralsShu : IGenerals
    {
        public void ShowGenerals()
        {
            Console.WriteLine($"{this.GetType().Name} is 关羽，张飞，赵云，马超，黄忠");
        }

    }
}
