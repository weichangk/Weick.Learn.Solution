using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastOA.Model
{
    [MetadataType(typeof(UserInfo_DataAnnotations))]
    public partial class UserInfo
    {
    }
    public class UserInfo_DataAnnotations
    {
        //由于使用DBFrist生成的数据模型中UserInfo中引用了R_UserInfo_ActionInfo和RoleInfo集合类型，但是R_UserInfo_ActionInfo和RoleInfo中也引用了UserInfo类型
        //导致循环引用无法对UserInfo进行Json序列化，因为在自动生成的模型中添加特性时，重新更新模型时将被移除，所以需要再这里添加忽略Json序列化的特性。
        //数据库中有主外键关联表使用DBFrist生成的数据模型都会存在这种情况。
        [JsonIgnore]
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        [JsonIgnore]
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
    }
}
