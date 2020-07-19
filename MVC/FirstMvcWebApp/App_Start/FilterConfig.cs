using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)//全局过滤器
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
