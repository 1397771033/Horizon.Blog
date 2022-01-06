using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;

namespace Horizon.Blog.Domain.Common
{
    public class UserCreationInfo : ValueObject
    {
        public string CreatorIp { get; private set; }
        public DateTime CreationTime { get; private set; }
        public UserCreationInfo(string creatorIp, DateTime creationTime)
        {
            CreatorIp = creatorIp;
            CreationTime = creationTime;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CreatorIp;
            yield return CreationTime;
        }
    }
}
