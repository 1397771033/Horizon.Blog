using System.ComponentModel;

namespace Horizon.Blog.Service.Enums
{
    public enum ArticleStatusEnum
    {
        [Description("已发布")]
        Published = 1,
        [Description("未发布")]
        Unpublished = 2
    }
}
