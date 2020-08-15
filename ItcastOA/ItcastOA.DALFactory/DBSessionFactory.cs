using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.DALFactory
{
    //负责创建数据会话实例IDBSession，必须保证线程内唯一。
    public class DBSessionFactory
    {
        public static IDAL.IDBSession CreateDBSession()
        {
            IDAL.IDBSession dbSession = (IDAL.IDBSession)CallContext.GetData("dbSession");
            if (dbSession == null)
            {
                dbSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }
}