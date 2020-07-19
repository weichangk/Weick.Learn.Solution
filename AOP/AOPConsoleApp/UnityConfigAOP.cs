using AOPConsoleApp.Model;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;



namespace AOPConsoleApp
{
    /// <summary>
    /// 使用EntLib\PIAB Unity 实现动态代理
    /// </summary>
    public class UnityConfigAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "caixukun",
                Password = "123456789121231"
            };
            {
                //通过Unity实例化对象
                //IUnityContainer container = new UnityContainer();
                //container.RegisterType<IUserProcessor, UserProcessor>();
                //IUserProcessor processor = container.Resolve<IUserProcessor>();
                //processor.RegUser(user);
            }
            {
                //配置UnityContainer实现AOP动态代理
                IUnityContainer container = new UnityContainer();
                //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
                //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                //UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                UnityConfigurationSection configSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                configSection.Configure(container, "aopContainer");

                IUserProcessor processor = container.Resolve<IUserProcessor>();
                //processor.RegUser(user);

                Console.WriteLine(processor.GetUser(user));
                Console.WriteLine(processor.GetUser(user));

            }
        }
    }
}
