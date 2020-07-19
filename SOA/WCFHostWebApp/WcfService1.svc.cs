using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFHostWebApp
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WcfService1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 WcfService1.svc 或 WcfService1.svc.cs，然后开始调试。
    public class WcfService1 : IWcfService1
    {
        public void DoWork()
        {
            Console.WriteLine("DoWork");
        }

        public string GetString()
        {
            return "GetString";
        }

        public List<User> GetUserList(int index)
        {
            return new List<User>()
                {
                    new User()
                    {
                        Id=123,
                        Age=23,
                        Sex=0,
                        Name="xxx",
                        Description="xxxxxx"
                    },
                    new User()
                    {
                        Id=234,
                        Age=34,
                        Sex=0,
                        Name="yyy",
                        Description="yyyyyy"
                    },
                };
        }

        public void HelloWord()
        {
            Console.WriteLine("HelloWord");
        }
    }
}
