﻿using ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.IBLL
{
    //具体实体业务数据访问接口；用来对具体实体业务数据访问自定义接口
    public interface IUserInfoService:IBaseService<UserInfo>
    {
        //还可自定义UserInfo业务层接口方法
    }
}
 