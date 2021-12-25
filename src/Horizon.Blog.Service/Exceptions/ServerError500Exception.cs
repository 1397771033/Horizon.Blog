using Horizon.Blog.Service.Enums;

namespace Horizon.Blog.Service.Exceptions
{
    public class ServerError500Exception : BaseException
    {
        public ServerError500Exception(string msg)
            : base(ErrorCodeEnum.server_error, msg)
        {

        }

        public ServerError500Exception()
            : base(ErrorCodeEnum.server_error)
        {

        }
    }
}
