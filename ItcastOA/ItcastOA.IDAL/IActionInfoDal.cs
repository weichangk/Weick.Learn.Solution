using ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.IDAL
{
    //具体实体数据访问接口；用来对具体实体数据访问自定义接口
    public interface IActionInfoDal : IBaseDal<ActionInfo>//拥有基类接口的所有公共方法
    {
        //还可自定义ActionInfo数据访问层接口方法
    }
}
