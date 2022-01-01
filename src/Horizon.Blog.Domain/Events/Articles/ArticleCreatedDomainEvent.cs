using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Events.Articles
{
    public class ArticleCreatedDomainEvent: INotification
    {
        public string ArticleId { get; set; }
        public ArticleCreatedDomainEvent(string articleId)
        {
            ArticleId = articleId;
        }
    }
}
