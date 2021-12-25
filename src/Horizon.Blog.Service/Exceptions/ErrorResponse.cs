using Horizon.Blog.Service.Enums;
using Horizon.Blog.Service.Helpers;

namespace Horizon.Blog.Service.Exceptions
{
    public class ErrorResponse
    {
        private const string _empty = "";
        public int Code { get; private set; }
        public string Message { get; private set; }

        public ErrorResponse() { }

        public void SetError(ErrorCodeEnum errorCode)
        {
            Code = (int)errorCode;
            Message = EnumHelper.GetDescription(errorCode);
        }

        public void SetError(ErrorCodeEnum errorCode, string message)
        {
            Code = (int)errorCode;
            Message = message ?? EnumHelper.GetDescription(errorCode);
        }
    }
}
