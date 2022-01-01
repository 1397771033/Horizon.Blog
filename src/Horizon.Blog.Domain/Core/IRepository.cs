namespace Horizon.Blog.Domain.Core
{
    public interface IRepository<TEntity> where TEntity :Entity, IAggregateRoot
    {
        /// <summary>
        /// 获取聚合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(string id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// 实体更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
    }
}
