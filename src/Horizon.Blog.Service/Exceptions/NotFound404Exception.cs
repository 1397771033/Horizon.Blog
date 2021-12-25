using Horizon.Blog.Service.Enums;

namespace Horizon.Blog.Service.Exceptions
{
    public class NotFound404Exception : BaseException
    {
        public NotFound404Exception(ErrorCodeEnum errorCode, string msg)
            : base(errorCode, msg)
        {

        }

        public NotFound404Exception(ErrorCodeEnum errorCode)
            : base(errorCode)
        {

        }
    }
}
