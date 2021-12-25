using System.ComponentModel;

namespace Horizon.Blog.Service.Enums
{
    public enum ErrorCodeEnum
    {
        #region 用户、帐号错误

        [Description("用户授权信息失效")]
        authorization_disabled = 4100,

        #endregion

        #region 参数/请求错误

        [Description("请求参数错误")]
        param_invalid = 4000,

        [Description("数据不存在")]
        data_not_found = 4001,

        [Description("数据已存在")]
        data_exsists = 4002, // 用于不能重复的数据校验

        #endregion

        #region 服务内部错误

        [Description("服务错误")]
        server_error = 5000,

        #endregion
    }
}
