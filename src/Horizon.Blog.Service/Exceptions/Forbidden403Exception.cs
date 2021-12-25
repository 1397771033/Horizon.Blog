using Horizon.Blog.Service.Enums;

namespace Horizon.Blog.Service.Exceptions
{
    public class Forbidden403Exception : BaseException
    {
        public Forbidden403Exception(ErrorCodeEnum errorCode, string msg)
            : base(errorCode, msg)
        {

        }

        public Forbidden403Exception(ErrorCodeEnum errorCode)
            : base(errorCode)
        {

        }
    }
}
