using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAConsoleApp
{
    public class CalculatorCallBack : WcfCalculatorServiceReference.ICalculatorServiceCallback
    {
        public void Show(int m, int n, int result)
        {
            Console.WriteLine($"回调操作展示：{m}+{n}={result}");
        }
    }
}
