using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace ThirdWebApi.Unity
{
    /// <summary>
    /// UnityContainer单例容器
    /// </summary>
    public class UnityContainerFactory
    {
        private static IUnityContainer _Container = null;

        static UnityContainerFactory()
        {
            Console.WriteLine("*****************UnityContainer*********************");
            {
                //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "XmlConfig\\ioc.Config");//找配置文件的路径
                //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                //_Container = new UnityContainer();
                //section.Configure(_Container, "IOCcontainer");

                _Container = new UnityContainer();
                UnityConfigurationSection configSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                configSection.Configure(_Container, "IOCcontainer");
            }
        }

        //获取容器实例
        public static IUnityContainer GetContainer()
        {
            return _Container;
        }
    }
}