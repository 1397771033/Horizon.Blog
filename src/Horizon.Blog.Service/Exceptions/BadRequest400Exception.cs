using Horizon.Blog.Service.Enums;

namespace Horizon.Blog.Service.Exceptions
{
    public class BadRequest400Exception : BaseException
    {
        public BadRequest400Exception(ErrorCodeEnum errorCode, string msg)
            : base(errorCode, msg)
        {

        }

        public BadRequest400Exception(ErrorCodeEnum errorCode)
            : base(errorCode)
        {

        }
    }
}
