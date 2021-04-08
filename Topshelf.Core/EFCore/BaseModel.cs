using System;

namespace Topshelf.Core
{
    public interface IBaseModel<TKey> 
    {
        TKey id { get; set; }
    }

    /// <summary>
    /// 所有数据表实体类都必须继承此类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public abstract class BaseModel<TKey> : IBaseModel<TKey>
    {
        public abstract TKey id { get; set; }
    }
}
