using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wdj.Redis.HelperTest.Model
{
    /// <summary>
    /// 测试用户实体模型
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
