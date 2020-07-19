using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFModel;

namespace WCFInterface
{
    [ServiceContract]//服务契约(Service Contract)
    public interface IContactService
    {
        [OperationContract]//必须标记.操作契约(Operation Contract)
        int Add(int a, int b);
        [OperationContract]
        List<Contact> Select(string id = null);
        [OperationContract]
        void Insert(Contact contact);
        [OperationContract]

        void Update(Contact contact);
        [OperationContract]
        void Delete(string id);
    }
}
