using ItcastOA.DALFactory;
using ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.BLL
{
    //泛型实体业务层公共抽象类；用来对所有实体业务公共访问泛型接口的公共实现
    public abstract class BaseService<T> where T: class, new()
    {
        //业务层调数据会话层；需要获取数据会话DBSession实例
        public IDBSession CurrentDBSession
        {
            //get { return new DBSession(); }//为了防止业务操作类中多次调用CurrentDBSession造成实例化多个DBSession，应该对DBSession的创建封装为线程内唯一
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }

        //父类无法知道通过数据会话层DBSession获取哪个数据操作类的实例；需要通过多态在所有业务子类的重载方法中指定具体的数据操作类实例
        public IDAL.IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();//提供数据操作业务子类重载，在业务子类中对具体的数据操作类进行实例
        public BaseService()
        {
            SetCurrentDal();//业务子类被构造时该抽象方法被调用，业务子类重载了该抽象方法也将被调用
        }

        public bool Delete(T model)
        {
            CurrentDal.Delete(model);
            return CurrentDBSession.SaveChanges();
        }

        public T Insert(T model)
        {
            CurrentDal.Insert(model);
            CurrentDBSession.SaveChanges();
            return model;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.Select(whereLambda);
        }

        public IQueryable<T> SelectPage<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.SelectPage(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }

        public bool Update(T model)
        {
            CurrentDal.Update(model);
            return CurrentDBSession.SaveChanges();
        }
    }
}
