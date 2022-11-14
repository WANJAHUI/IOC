using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IocDemo.Container
{
    public static class ServiceFactory
    {
        /// <summary>
        /// 创建根服务提供者
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static MyServiceProvider BuildProvider(this MyServiceCollection services)
        {
            return new MyServiceProvider(services);
        }
        public static MyServiceProviderScoped CreateScoped(this MyServiceProvider provider)
        {
            return new MyServiceProviderScoped(provider);
        }
    }
}