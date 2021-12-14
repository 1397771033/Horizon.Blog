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
        public string UserId { get; set; }

    }
}
