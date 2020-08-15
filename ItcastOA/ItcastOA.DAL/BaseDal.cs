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
    //泛型实体数据访问实现公共抽象类；用来对所有实体数据公共访问泛型接口的公共实现
    public abstract class BaseDal<T> where T: class, new()
    {
        //ItcastOAEntities Db = new ItcastOAEntities();
        readonly DbContext Db = DBContextFactory.CreateDbcontext();
        public bool Delete(T model)
        {
            Db.Entry<T>(model).State = EntityState.Deleted;
            return true;//return Db.SaveChanges() > 0;
        }

        public T Insert(T model)
        {
            Db.Set<T>().Add(model);
            //Db.SaveChanges();
            return model;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }

        public IQueryable<T> SelectPage<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        public bool Update(T model)
        {
            Db.Entry<T>(model).State = EntityState.Modified;
            return true;//return Db.SaveChanges() > 0;
        }
    }
}
