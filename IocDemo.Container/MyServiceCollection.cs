using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IocDemo.Container
{
    public class MyServiceCollection : List<MyServiceDiscriptor>
    {
        /// <summary>
        /// 添加瞬时
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        /// <returns></returns>
        public void AddTransient<TService, TImplement>()
            where TService : class
            where TImplement : class
        {
            AddTransient(typeof(TService), typeof(TImplement));
        }
        public void AddTransient(Type seviceType, Type implementType)
        {
            var discriptor = new MyServiceDiscriptor()
            {
                Life = MyServiceLife.Transient,
                ServiceType = seviceType,
                ImplementType = implementType
            };
            AddIfNotContent(discriptor);
        }
        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        /// <returns></returns>
        public void AddScoped<TService, TImplement>()
            where TService : class
            where TImplement : class
        {
            AddScoped(typeof(TService), typeof(TImplement));
        }
        public void AddScoped(Type seviceType, Type implementType)
        {
            var discriptor = new MyServiceDiscriptor()
            {
                Life = MyServiceLife.Scoped,
                ServiceType = seviceType,
                ImplementType = implementType
            };
            AddIfNotContent(discriptor);
        }
        /// <summary>
        /// 添加作单例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        /// <returns></returns>
        public void AddSington<TService, TImplement>()
            where TService : class
            where TImplement : class
        {
            AddSington(typeof(TService), typeof(TImplement));
        }
        public void AddSington<TService>(object instance)
            where TService : class
        {
            AddSington(typeof(TService), instance.GetType(), instance);
        }
        public void AddSington(Type seviceType, Type implementType)
        {
            AddSington(seviceType, implementType, null);
        }
        public void AddSington(Type seviceType, Type implementType, object instacne)
        {
            var discriptor = new MyServiceDiscriptor()
            {
                Life = MyServiceLife.Singleton,
                ServiceType = seviceType,
                ImplementType = implementType,
                ImplementInstance = instacne
            };
            AddIfNotContent(discriptor);
        }
        /// <summary>
        /// 往集合中添加类型
        /// </summary>
        /// <param name="discriptor"></param>
        private void AddIfNotContent(MyServiceDiscriptor discriptor)
        {
            if (!this.Any(m => m.ServiceType == discriptor.ServiceType && m.ImplementType == discriptor.ImplementType))
            {
                this.Add(discriptor);
            }
        }
    }
}