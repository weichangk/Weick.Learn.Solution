using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 吴国武将
    /// </summary>
    public class GeneralsWu : IGenerals
    {
        public void ShowGenerals()
        {
            Console.WriteLine($"{this.GetType().Name} is 黄盖，甘宁，太史慈，韩当，凌统");
        }

    }
}
