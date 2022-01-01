using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;

namespace Horizon.Blog.Domain.Service
{
    public class ArticleFunctionService
    {
        private readonly IArticleFunctionRepository _articleFunctionRepository;

        public ArticleFunctionService(IArticleFunctionRepository articleFunctionRepository)
        {
            _articleFunctionRepository = articleFunctionRepository;
        }

        public bool BindArticle(string articleId)
        {
            var articleFunction = _articleFunctionRepository.GetByArticle(articleId);
            return articleFunction == null;
        }
    }
}
