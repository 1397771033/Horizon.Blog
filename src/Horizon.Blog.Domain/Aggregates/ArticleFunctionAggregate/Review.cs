using Horizon.Blog.Domain.Common;
using Horizon.Blog.Domain.Core;
using System;

namespace Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate
{
    public class Review : Entity
    {
        public string Content { get; private set; }
        public UserCreationInfo CreationInfo { get; private set; }

        private Review()
        {

        }
        internal Review(string content, string creatorIp) : this()
        {
            GenerateId();
            SetContent(content);
            SetCreationInfo(creatorIp);
        }
        private void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));
            Content = content;
        }
        internal void ModifyContent(string content)
        {
            this.SetContent(content);
        }
        private void SetCreationInfo(string creatorIp)
        {
            CreationInfo = new UserCreationInfo(creatorIp, DateTime.Now);
        }
    }
}
