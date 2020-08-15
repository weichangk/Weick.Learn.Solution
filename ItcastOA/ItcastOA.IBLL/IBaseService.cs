using ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.IBLL
{
    //泛型实体业务公共接口；用来对所有实体业务公共数据访问接口封装基类接口
    public interface IBaseService<T> where T:class, new()
    {   
        IDBSession CurrentDBSession { get; }

        IDAL.IBaseDal<T> CurrentDal { get; set; }

        bool Delete(T model);

        T Insert(T model);
        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> SelectPage<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);

        bool Update(T model);
    }
}
