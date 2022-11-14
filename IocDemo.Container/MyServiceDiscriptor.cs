using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IocDemo.Container
{
    public class MyServiceDiscriptor
    {
        // 服务生命周期
        public MyServiceLife Life { get; set; }
        // 服务类型
        public Type ServiceType { get; set; }
        // 实现类型
        public Type ImplementType { get; set; }
        // 实现实例
        public  object ImplementInstance { get; set; }
    }
}