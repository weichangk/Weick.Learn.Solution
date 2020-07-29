using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 魏国武将
    /// </summary>
    public class GeneralsWei : IGenerals
    {
        public void ShowGenerals()
        {
            Console.WriteLine($"{this.GetType().Name} is 许褚，典韦，夏侯渊，徐晃，张辽");
        }

    }
}
