using Horizon.Blog.Service.Enums;
using Horizon.Blog.Service.Exceptions;
using Horizon.Blog.Service.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Horizon.Blog.Api.Extensions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly ErrorResponse _errorResponse;

        public ExceptionHandlerMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger,
            ErrorResponse error)
        {
            _next = next;
            _logger = logger;
            _errorResponse = error;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                string controller = context.Request.RouteValues["controller"]?.ToString();
                string action = context.Request.RouteValues["action"]?.ToString();

                if (ex is BaseException || ex is ArgumentException || ex is ArgumentNullException)
                {
                    if (ex is BaseException baseExceptions)
                        _errorResponse.SetError(baseExceptions.ErrorCode, baseExceptions.Message);
                    else // 处理ArgumentException、ArgumentNullException的错误
                        _errorResponse.SetError(ErrorCodeEnum.param_invalid, ex.Message);

                    if (ex is BadRequest400Exception || ex is ArgumentException || ex is ArgumentNullException)
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    if (ex is Unauthrized401Exception)
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    if (ex is Forbidden403Exception)
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    if (ex is NotFound404Exception)
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    _errorResponse.SetError(ErrorCodeEnum.server_error);
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                if (!string.IsNullOrEmpty(controller))
                {
                    _logger.LogError(
                        eventId: new EventId(ex.HResult),
                        exception: ex,
                        message: $"Http: {context.Request.Method} {context.Request.Path} \nMethod: {controller}Controller.{action} 出现错误 \n————————————————————————————");
                }
                else
                {
                    _logger.LogError(ex, ex.Message);
                }
                string response = _errorResponse.ToJson();
                await context.Response.WriteAsync(response);
            }
        }
    }
}
