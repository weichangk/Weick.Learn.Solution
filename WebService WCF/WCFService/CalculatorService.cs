using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCFInterface;

namespace WCFService
{
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// 完成计算，然后去回调
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Plus(int x, int y)
        {
            int result = x + y;
            Thread.Sleep(2000);
            ICalculatorCallBack callBack = OperationContext.Current.GetCallbackChannel<ICalculatorCallBack>();
            callBack.Show(x, y, result);
        }
    }
}
