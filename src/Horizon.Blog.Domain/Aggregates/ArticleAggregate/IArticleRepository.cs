using Horizon.Blog.Domain.Aggregates.ArticleAggreate;
using Horizon.Blog.Domain.Core;

namespace Horizon.Blog.Domain.Aggregates.ArticleAggregate
{
    public interface IArticleRepository : IRepository<Article>
    {
        /// <summary>
        /// 根据排序值获取最顶/最底的文章,true最顶，false最底
        /// </summary>
        /// <param name="asc"></param>
        /// <returns></returns>
        Article GetBySortNum(bool asc = false);
    }
}
