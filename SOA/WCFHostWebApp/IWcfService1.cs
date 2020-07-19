using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFHostWebApp
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWcfService1”。
    [ServiceContract]//服务契约(Service Contract)
    public interface IWcfService1
    {
        [OperationContract]//必须标记.操作契约(Operation Contract)
        void DoWork();

        [OperationContract]//必须标记
        string GetString();

        [OperationContract]//必须标记
        List<User> GetUserList(int index);

        void HelloWord();//没有标志则不对外公开
    }
}
