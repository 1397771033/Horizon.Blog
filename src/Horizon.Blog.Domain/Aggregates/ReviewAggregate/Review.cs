using Horizon.Blog.Domain.Common;
using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Aggregates.ReviewAggregate
{
    public class Review:Entity,IAggregateRoot
    {
        public string Content { get;private set; }
        public UserCreationInfo CreationInfo { get;private set; }
        public string ArticleId { get;private set; }
        private Review()
        {

        }
        public Review(string content,string articleId,string creatorId):this()
        {
            GenerateId();
            SetContent(content);
            BindArticleId(articleId);
            SetCreationInfo(creatorId);
        }
        private void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));
            Content = content;
        }
        public void ModifyContent(string content)
        {
            this.SetContent(content);
        }
        public void BindArticleId(string articleId)
        {
            if (string.IsNullOrWhiteSpace(articleId))
                throw new ArgumentNullException(nameof(articleId));
            ArticleId = articleId;
        }
        private void SetCreationInfo(string creatorId)
        {
            CreationInfo = new UserCreationInfo(creatorId,DateTime.Now);
        }
    }
}
