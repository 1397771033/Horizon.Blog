using Horizon.Blog.Domain.Aggregates.ArticleAggreate;
using Horizon.Blog.Domain.Aggregates.ArticleAggregate;
using Horizon.Blog.Domain.Service;
using Horizon.Blog.Infrastructure.DatabaseContext;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Application.CommandHandlers.ArticleHandlers
{
    public class AddArticleCommandHandler : CommandHandler, IRequestHandler<AddArticleCommand, bool>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ArticleService _articleService;
        public AddArticleCommandHandler(BlogDbContext context,
            IArticleRepository articleRepository,
            ArticleService articleService)
            : base(context)
        {
            _articleRepository = articleRepository;
            _articleService = articleService;
        }
        public async Task<bool> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            int sortNum = _articleService.GetMaxSortNum();
            Article article = new Article(request.Title, request.Content, request.CreatorId, sortNum + 1);
            _articleRepository.Add(article);
            return await SaveEntitiesAsync();
        }
    }
}
