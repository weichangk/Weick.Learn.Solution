using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public class H : BaseWord
    {
        public H()
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("字符H被构造");
        }

        public override string Display()
        {
            return "H";
        }
    }
}
