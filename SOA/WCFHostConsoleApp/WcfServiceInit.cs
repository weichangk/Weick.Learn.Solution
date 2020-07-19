using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFService;

namespace WCFHostConsoleApp
{
    public class WcfServiceInit
    {
        public static void Process()
        {
            List<ServiceHost> hosts = new List<ServiceHost>()
            {
                new ServiceHost(typeof(ContactService)),
                new ServiceHost(typeof(CalculatorService))
            };
            foreach (var host in hosts)
            {
                host.Opening += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备打开");
                host.Opened += (s, e) => Console.WriteLine($"{host.GetType().Name} 已经正常打开");
                host.Open();
            }
            Console.WriteLine("输入任何字符，就停止");
            Console.Read();
            foreach (var host in hosts)
            {
                host.Close();
                Console.WriteLine("已经停止");
            }
            Console.Read();
        }
    }
}
