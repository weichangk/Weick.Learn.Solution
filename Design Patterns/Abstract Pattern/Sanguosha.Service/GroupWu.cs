using Sanguosha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguosha.Service
{
    /// <summary>
    /// 吴国主公
    /// </summary>
    public class GroupWu : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine($"{this.GetType().Name} is 孙权");
        }
    }
}
