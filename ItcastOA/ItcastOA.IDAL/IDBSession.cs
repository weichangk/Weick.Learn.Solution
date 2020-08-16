using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.IDAL
{
    //数据会话层接口，提供业务层调用
    public interface IDBSession
    {
        DbContext Db { get; }
        IUserInfoDal UserInfoDal { get; set; }
        IActionInfoDal ActionInfoDal { get; set; }
        IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; set; }
        IRoleInfoDal RoleInfoDal { get; set; }

        bool SaveChanges();
    }
}
