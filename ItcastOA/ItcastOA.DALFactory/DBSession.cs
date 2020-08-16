using ItcastOA.DAL;
using ItcastOA.IDAL;
using ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.DALFactory
{
    //数据会话层：就是一个工厂类。负责所有实体数据操作类实例的创建。
    //业务层通过数据会话层获取具体数据操作类的实例，数据会话层实现业务层与数据层的解耦
    public class DBSession : IDBSession
    {
        //ItcastOAEntities Db = new ItcastOAEntities();
        //由于数据会话层和数据会话层调用的数据访问层都实例化EF对象，导致对象不唯一，
        //应该将EF对象创建封装成线程内唯一；在数据会话层和数据会话层调用的数据访问层中使用EF线程内唯一的对象创建方法
        public DbContext Db
        {
            get
            {
                return DBContextFactory.CreateDbcontext();
            }
        }

        //工作单元模式
        //一个业务中经常涉及到对多个实体模型（表）的操作，我们希望连接一次数据库，完成对多个实体模型的操作，提高性能，涉及多张表的操作，完成所有数据的保存，要么都提交，要么都回滚。
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;//由于数据会话层调用数据访问层，所以数据访问层中的SaveChanges需要注释掉
        }

        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_UserInfoDal == null)
                {
                    //_UserInfoDal = new DAL.UserInfoDal();
                    //这里直接new数据层数据操作对象，导致数据会话层和数据层耦合了。
                    //将对数据层数据操作对象的创建封装为抽象工厂。
                    _UserInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }

        private IActionInfoDal _ActionInfoDal;
        public IActionInfoDal ActionInfoDal
        {
            get
            {
                if (_ActionInfoDal == null)
                {
                    _ActionInfoDal = AbstractFactory.CreateActionInfoDal();
                }
                return _ActionInfoDal;
            }
            set { _ActionInfoDal = value; }
        }

        private IR_UserInfo_ActionInfoDal _R_UserInfo_ActionInfoDal;
        public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
        {
            get
            {
                if (_R_UserInfo_ActionInfoDal == null)
                {
                    _R_UserInfo_ActionInfoDal = AbstractFactory.CreateR_UserInfo_ActionInfoDal();
                }
                return _R_UserInfo_ActionInfoDal;
            }
            set { _R_UserInfo_ActionInfoDal = value; }
        }

        private IRoleInfoDal _RoleInfoDal;
        public IRoleInfoDal RoleInfoDal
        {
            get
            {
                if (_RoleInfoDal == null)
                {
                    _RoleInfoDal = AbstractFactory.CreateRoleInfoDal();
                }
                return _RoleInfoDal;
            }
            set { _RoleInfoDal = value; }
        }

    }
}
 