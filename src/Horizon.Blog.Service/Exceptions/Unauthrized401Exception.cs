using Horizon.Blog.Service.Enums;

namespace Horizon.Blog.Service.Exceptions
{
    public class Unauthrized401Exception : BaseException
    {
        public Unauthrized401Exception(ErrorCodeEnum errorCode, string msg)
            : base(errorCode, msg)
        {

        }

        public Unauthrized401Exception(ErrorCodeEnum errorCode)
            : base(errorCode)
        {

        }

        public Unauthrized401Exception(string errorMsg)
            : base(errorMsg)
        {

        }
    }
}
