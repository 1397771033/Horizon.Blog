using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Horizon.Blog.Domain.Events.Articles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Application.DomainEventHandlers.Articles
{
    public class ArticleCreatedDomainEventHandler
        : INotificationHandler<ArticleCreatedDomainEvent>
    {
        private readonly IArticleFunctionRepository _articleFunctionRepository;
        public ArticleCreatedDomainEventHandler(IArticleFunctionRepository articleFunctionRepository)
        {
            _articleFunctionRepository = articleFunctionRepository;
        }
        public Task Handle(ArticleCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var articleFunction = new ArticleFunction(notification.ArticleId);
            _articleFunctionRepository.Add(articleFunction);
            return Task.CompletedTask;
        }
    }
}
