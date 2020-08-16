using ItcastOA.IBLL;
using ItcastOA.IDAL;
using ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.BLL
{
    //业务层R_UserInfo_ActionInfoService业务实现
    public class R_UserInfo_ActionInfoService : BaseService<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoService
    {
        public override void SetCurrentDal()//重载抽象类抽象方法，在对象实例化时对具体的数据操作类进行实例
        {
            this.CurrentDal = this.CurrentDBSession.R_UserInfo_ActionInfoDal;
        }


        //复杂业务中经常涉及到对多个实体模型（表）的操作，我们希望连接一次数据库，完成对多个实体模型的操作，
        //提高性能，涉及多张表的操作，完成所有数据的保存，要么都提交，要么都回滚。
        //可以通过数据会话层CurrentDBSession操作多个具体数据操作类，再统一CurrentDBSession.SaveChanges();如：
        //public void xxx()
        //{
        //    //this.CurrentDBSession.UserInfoDal.Insert();
        //    //this.CurrentDBSession.UserInfoDal.Delete     
        //    //this.CurrentDBSession.xxxDal.xxx();
        //    //this.CurrentDBSession.yyyDal.yyy();
        //    //this.CurrentDBSession.SaveChanges();
        //}
    }
}
