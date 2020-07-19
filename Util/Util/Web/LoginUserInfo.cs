using System.Web;

namespace Util
{
    /// <summary>
    /// 当前上下文执行用户信息获取
    /// </summary>
    public static class LoginUserInfo
    {
        /// <summary>
        /// 获取当前上下文执行用户信息
        /// </summary>
        /// <returns></returns>
        public static UserInfo Get()
        {
            return (UserInfo)HttpContext.Current.Items["LoginUserInfo"];
        }
    }
}
