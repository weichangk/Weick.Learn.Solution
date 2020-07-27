using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace ThirdWebApi.Unity
{

    //实现IOC与WebApi结合
    //UnityDependencyResolver 实现一个IDependencyResolver，里面包装自己的Unity容器UnityContainerFactory
    //把webapi的DependencyResolver换成自己的Unity版本的
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _IUnityContainer = null;
        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            this._IUnityContainer = unityContainer;
        }

        /// <summary>
        /// 获取单个服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return this._IUnityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException ex)//因为会累计构造多个对象，很多是没有去扩展，直接null就行
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._IUnityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()//每次请求
        {
            var child = this._IUnityContainer.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        public void Dispose()
        {
            this._IUnityContainer.Dispose();
        }
    }
}