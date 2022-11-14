namespace IocDemo.Container
{
    /// <summary>
    /// 服务生命周期
    /// </summary>
    public enum MyServiceLife
    {
        // 瞬时
        Transient,
        // 单例
        Singleton,
        // 作用域单例
        Scoped
    }
}
