using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.IDAL
{
    //泛型实体数据访问公共接口；用来对所有实体公共数据访问接口封装基类接口
    public interface IBaseDal<T> where T: class, new()
    {
        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> SelectPage<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);

        bool Delete(T model);

        bool Update(T model);

        T Insert(T model);
    }
}
