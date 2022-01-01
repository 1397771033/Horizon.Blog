using Horizon.Blog.Domain.Aggregates.ArticleAggregate;

namespace Horizon.Blog.Domain.Service
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        /// <summary>
        /// 获取文章里最大的排序值
        /// </summary>
        /// <returns></returns>
        public int GetMaxSortNum()
        {
            var article = _articleRepository.GetBySortNum();
            return article?.SortNum ?? default;
        }
    }
}
