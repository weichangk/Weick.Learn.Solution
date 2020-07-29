using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 扩展群雄武将
    /// </summary>
    public class GeneralsQun : IGenerals
    {
        public void ShowGenerals()
        {
            Console.WriteLine($"{this.GetType().Name} is 吕布，颜良文丑，纪灵，高顺");
        }

    }
}
