using Horizon.Blog.Domain.Common;
using Horizon.Blog.Domain.Core;
using System;

namespace Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate
{
    public class Star : Entity
    {
        public UserCreationInfo CreationInfo { get; private set; }
        private Star()
        {

        }
        internal Star(string creatorIp) : this()
        {
            GenerateId();
            SetCreationInfo(creatorIp);
        }
        private void SetCreationInfo(string creatorIp)
        {
            CreationInfo = new UserCreationInfo(creatorIp, DateTime.Now);
        }
    }
}
