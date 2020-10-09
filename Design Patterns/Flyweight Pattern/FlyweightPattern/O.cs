using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public class O : BaseWord
    {
        public O()
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("字符O被构造");
        }

        public override string Display()
        {
            return "O";
        }
    }
}
