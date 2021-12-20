using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Common
{
    /// <summary>
    /// 修改信息-后台管理员
    /// </summary>
    public class AdminModificationInfo : ValueObject
    {
        public string ModifierId { get; private set; }
        public DateTime ModificationTime { get; private set; }
        public AdminModificationInfo(string modifierId, DateTime modificationTime)
        {
            ModifierId = modifierId;
            ModificationTime = modificationTime;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ModifierId;
            yield return ModificationTime;
        }
    }
}
