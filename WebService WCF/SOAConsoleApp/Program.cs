using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfCalculatorServiceReference.CalculatorServiceClient client = null;
            try
            {
                Console.WriteLine("This is wcf service callback test");
                InstanceContext context = new InstanceContext(new CalculatorCallBack());
                client = new WcfCalculatorServiceReference.CalculatorServiceClient(context);
                client.Plus(123, 234);
                client.Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                    client.Abort();
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
