using System.Web;
using System.Web.Optimization;

namespace FirstMvcWebApp
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
        /*
        ASP.NET MVC中Bundle是用于打包捆绑资源的（一般是css和js），它是在全局文件Global.asax.cs中注册Bundle，而注册的具体实现默认是在App_Start文件夹的BundleConfig.cs中

        在创建ASP.NET MVC5项目时，默认在App_Start文件夹中创建了BudleConfig.cs文件。

        如果是使用空项目创建的MVC则不会自动生成BudleConfig.cs文件。如需添加需要管理nuget程序包添加System.Web.Optimization再手动添加

        bundles.Add是在向网站的BundleTable中添加Bundle项，这里主要有ScriptBundle和StyleBundle，分别用来压缩脚本和样式表。用一个虚拟路径来初始化Bundle的实例，这个路径并不真实存在，然后在新Bundle的基础上Include项目中的文件进去。具体的Include语法可以查阅上面提供的官方简介。

        默认情况下，Bundle是会对js和css进行压缩打包的，不过在Web.config中有一个属性可以显式的说明是否需要打包压缩：当compilation的debug属性设为true时，表示项目处于调试模式，这时Bundle是不会将文件进行打包压缩的。
        css和js资源，在实际应用中，出于为了减轻服务器负载等原因，需要引入压缩版的资源(一般是在未压缩的命名后面加上min来命名，如jquery.js的压缩版【有些叫法是精简版】是jquery.min.js)；最终部署运行时，将debug设为false就可以看到js和css被打包和压缩了
        */
    }
}
