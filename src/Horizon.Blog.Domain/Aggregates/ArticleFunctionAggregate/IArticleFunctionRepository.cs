using Horizon.Blog.Domain.Core;

namespace Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate
{
    public interface IArticleFunctionRepository : IRepository<ArticleFunction>
    {
        ArticleFunction GetByArticle(string articleId);
    }
}
