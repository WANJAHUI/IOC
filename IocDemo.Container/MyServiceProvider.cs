using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IocDemo.Container
{
    /// <summary>
    /// 根节点的服务提供者
    /// </summary>
    public class MyServiceProvider
    {
        public ConcurrentDictionary<Type, MyServiceDiscriptor> dictionary { get; set; }
        public MyServiceProvider(MyServiceCollection services)
        {
            dictionary = new();
            ResizeService(services);
        }
        /// <summary>
        /// 把容器转化成字典
        /// </summary>
        /// <param name="services"></param>
        public void ResizeService(MyServiceCollection services)
        {
            foreach (var service in services)
            {
                dictionary.TryAdd(service.ServiceType, service);
            }
        }

        public object? GetService(Type serviceType, MyServiceProviderScoped scopedProvider)
        {
            var hasValue = dictionary.TryGetValue(serviceType, out MyServiceDiscriptor discriptor);
            if (hasValue)
            {
                switch (discriptor.Life)
                {
                    
                    default:
                    case MyServiceLife.Transient:
                    {
                        return Activator.CreateInstance(discriptor.ImplementType);
                    }
                    case MyServiceLife.Singleton:
                    {
                        if(discriptor.ImplementInstance == null)
                        {
                                lock (discriptor)
                                {
                                    if (discriptor.ImplementInstance == null)
                                    {
                                        discriptor.ImplementInstance = Activator.CreateInstance(discriptor.ImplementType);
                                    }
                                }
                        }
                        return discriptor.ImplementInstance;
                    }
                    case MyServiceLife.Scoped:
                    {
                        if(scopedProvider.DicScopedService.TryGetValue(serviceType,out object instance))
                        {
                            if(instance == null)
                            {
                                instance = Activator.CreateInstance(discriptor.ImplementType);
                                scopedProvider.DicScopedService[serviceType] = instance;
                            }
                        }
                        return instance;
                    }
                }
            }
            else
            {
                // throw new Exception("当前服务并未注册");
                return null;
            }
        }
    }

}