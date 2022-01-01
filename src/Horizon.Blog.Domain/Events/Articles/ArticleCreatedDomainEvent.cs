using MediatR;

namespace Horizon.Blog.Domain.Events.Articles
{
    public class ArticleCreatedDomainEvent : INotification
    {
        public string ArticleId { get; set; }
        public ArticleCreatedDomainEvent(string articleId)
        {
            ArticleId = articleId;
        }
    }
}
