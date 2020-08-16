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
    //ActionInfo数据访问层；具体实体数据访问实现；用来对具体实体数据访问自定义接口的实现，也可以自定义方法
    public class ActionInfoDal : BaseDal<ActionInfo>, IActionInfoDal//拥有BaseDal<ActionInfo>泛型抽象类的所有实体公共数据访问方法，继承IActionInfoDal接口的公共方法已经抽象类中实现不用再次实现，在接口中自定义的在方法需要实现
    {
        //除了有用抽象类的所有实体公共数据访问方法，还能实现接口自定义非公共方法，还可以自定义方法
    }
}
