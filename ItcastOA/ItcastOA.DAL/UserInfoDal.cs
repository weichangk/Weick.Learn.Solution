using ItcastOA.IDAL;
using ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.DAL
{
    //UserInfo数据访问层；具体实体数据访问实现；用来对具体实体数据访问自定义接口的实现，也可以自定义方法
    public class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal//拥有BaseDal<UserInfo>泛型抽象类的所有实体公共数据访问方法，已经在抽象类中实现不用再次实现；继承IUserInfoDal接口方法需要实现
    {
        //除了有用抽象类的所有实体公共数据访问方法，还能实现接口方法，还可以自定义方法
    }
}
