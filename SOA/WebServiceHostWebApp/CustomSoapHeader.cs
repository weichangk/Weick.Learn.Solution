using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceHostWebApp
{
    /// <summary>
    /// Header:分配个加密钥  账号密码加密
    /// 
    /// </summary>
    public class CustomSoapHeader : System.Web.Services.Protocols.SoapHeader
    {

        private string userName = string.Empty;
        private string passWord = string.Empty;
        public CustomSoapHeader()//必须有一个无参数的构造函数
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        public CustomSoapHeader(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        /// <summary>
        /// 获取或设置用户用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { this.passWord = value; }
        }
        public bool Validate()
        {
            return this.UserName.Contains("s") && this.PassWord.Contains("1");
        }

    }
}