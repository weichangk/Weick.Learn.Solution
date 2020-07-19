using FactoryPattern.ToyotaMotor.Interface;
using FactoryPattern.ToyotaMotor.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    /// <summary>
    /// 简单工厂类
    /// </summary>
    public class ToyotaFactory
    {
        #region 使用枚举+实例化对象静态方法，为上层提供根据参数获取具体对象的方法
        public enum ToyotaType
        {
            Alphard = 1,
            Camry = 2,
            Corolla = 3
        }

        public static IToyota CreateInstance(ToyotaType toyotaType)
        {
            IToyota toyota;
            switch (toyotaType)
            {
                case ToyotaType.Alphard:
                    toyota = new Alphard();
                    break;
                case ToyotaType.Camry:
                    toyota = new Camry();
                    break;
                case ToyotaType.Corolla:
                    toyota = new Corolla();
                    break;
                default:
                    throw new Exception("IToyota CreateInstance error...");
            }
            return toyota;
        }
        #endregion


        #region 使用配置+实例化对象静态方法，为上层提供根据配置获取具体对象的方法
        private static readonly string ToyotaTypeConfig = ConfigurationManager.AppSettings["ToyotaTypeConfig"];
        public static IToyota CreateInstanceConfig()
        {
            ToyotaType toyotaType = (ToyotaType)Enum.Parse(typeof(ToyotaType), ToyotaTypeConfig);//字符串转枚举
            IToyota toyota;
            switch (toyotaType)
            {
                case ToyotaType.Alphard:
                    toyota = new Alphard();
                    break;
                case ToyotaType.Camry:
                    toyota = new Camry();
                    break;
                case ToyotaType.Corolla:
                    toyota = new Corolla();
                    break;
                default:
                    throw new Exception("IToyota CreateInstance error...");
            }
            return toyota;
        }
        #endregion


        #region 使用配置+反射+实例化对象静态方法，为上层提供根据配置获取具体对象的方法
        private static readonly string ToyotaTypeConfigReflection = ConfigurationManager.AppSettings["ToyotaTypeConfigReflection"];
        private static readonly string DllName = ToyotaTypeConfigReflection.Split(',')[0];
        private static readonly string ClassName = ToyotaTypeConfigReflection.Split(',')[1];
        public static IToyota CreateInstanceConfigReflection()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(ClassName);
            Object oObject = Activator.CreateInstance(type);
            return (IToyota)oObject;
        }
        #endregion

    }
}
