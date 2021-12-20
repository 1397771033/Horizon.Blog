using Horizon.Blog.Domain.Common;
using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Aggregates.StarAggregate
{
    public class Star : Entity, IAggregateRoot
    {
        public UserCreationInfo CreationInfo { get; private set; }
        public string ArticleId { get; private set; }
        private Star()
        {
            
        }
        public Star(string articleId,string creatorId):this()
        {
            GenerateId();
            BindArticleId(articleId);
            SetCreationInfo(creatorId);
        }
        public void BindArticleId(string articleId)
        {
            if (string.IsNullOrWhiteSpace(articleId))
                throw new ArgumentNullException(nameof(articleId));
            ArticleId = articleId;
        }
        private void SetCreationInfo(string creatorId)
        {
            CreationInfo = new UserCreationInfo(creatorId, DateTime.Now);
        }
    }
}
