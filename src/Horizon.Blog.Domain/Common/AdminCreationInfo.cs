using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Common
{
    public class AdminCreationInfo:ValueObject
    {
        public string CreatorId { get;private set; }
        public DateTime CreationTime { get;private set; }
        public AdminCreationInfo(string creatorId,DateTime creationTime)
        {
            CreatorId = creatorId;
            CreationTime = creationTime;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CreatorId;
            yield return CreationTime;
        }
    }
}
