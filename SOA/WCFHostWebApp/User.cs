using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFHostWebApp
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    //[DataContract]//1 标准规范实体需要添加，  有无参数构造函数是可以省略的
    //public class WebServiceUser
    //{
    //    [DataMember]//2 有了DataContract之后，必须DataMember
    //    public int Id { get; set; }
    //    [DataMember]
    //    public int Age { get; set; }
    //    [DataMember]
    //    public int Sex { get; set; }
    //    [DataMember(Name = "ShortName")]
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //}
    ////一般来说，契约和DataMember都声明好
}