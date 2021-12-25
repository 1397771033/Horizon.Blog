using Horizon.Blog.Service.Enums;
using Horizon.Blog.Service.Helpers;
using System;

namespace Horizon.Blog.Service.Exceptions
{
    public abstract class BaseException : Exception
    {
        public ErrorCodeEnum ErrorCode { get; set; }
        public BaseException(string msg)
            : base(msg)
        {

        }

        public BaseException(ErrorCodeEnum errorCode)
            : base(EnumHelper.GetDescription(errorCode))
        {
            ErrorCode = errorCode;
        }

        public BaseException(ErrorCodeEnum errorCode, string msg)
            : base(msg)
        {
            ErrorCode = errorCode;
        }
    }
}
