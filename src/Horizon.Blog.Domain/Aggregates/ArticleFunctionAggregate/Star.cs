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
        internal Star(string creatorId) : this()
        {
            GenerateId();
            SetCreationInfo(creatorId);
        }
        private void SetCreationInfo(string creatorId)
        {
            CreationInfo = new UserCreationInfo(creatorId, DateTime.Now);
        }
    }
}
