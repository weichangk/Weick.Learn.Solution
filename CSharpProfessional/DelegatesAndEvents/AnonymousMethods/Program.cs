using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    class Program
    {
        static void Main()
        {
            string mid = ", middle part,";

            Func<string, string> anonDel = delegate (string param)//anonDel委托指向 delegate定义的匿名方法
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Console.WriteLine(anonDel("Start of string"));

            Console.ReadKey();
        }
    }
}
