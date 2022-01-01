using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Horizon.Blog.Domain.Events.Articles;
using Horizon.Blog.Domain.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Application.DomainEventHandlers.Articles
{
    public class ArticleCreatedDomainEventHandler
        : INotificationHandler<ArticleCreatedDomainEvent>
    {
        private readonly IArticleFunctionRepository _articleFunctionRepository;
        private readonly ArticleFunctionService _articleFunctionService;
        public ArticleCreatedDomainEventHandler(IArticleFunctionRepository articleFunctionRepository, ArticleFunctionService articleFunctionService)
        {
            _articleFunctionRepository = articleFunctionRepository;
            _articleFunctionService = articleFunctionService;
        }
        public Task Handle(ArticleCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (_articleFunctionService.BindArticle(notification.ArticleId))
            {
                var articleFunction = new ArticleFunction(notification.ArticleId);
                _articleFunctionRepository.Add(articleFunction);
            }
            return Task.CompletedTask;
        }
    }
}
