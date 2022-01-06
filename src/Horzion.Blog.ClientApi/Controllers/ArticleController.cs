using Horzion.Blog.ClientApi.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horzion.Blog.ClientApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ArticleAppService _articleAppService;
        public ArticleController(IMediator mediator, ArticleAppService articleAppService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _articleAppService = articleAppService ?? throw new ArgumentNullException(nameof(articleAppService));
        }
        /// <summary>
        /// 星
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [HttpPut("article/{articleId}/star")]
        public IActionResult Star(string articleId)
        {
            string userIp = HttpContext.Connection.RemoteIpAddress.ToString();
            
            return Ok(_articleAppService.StarToRedis(articleId, userIp));
        }
    }
}
