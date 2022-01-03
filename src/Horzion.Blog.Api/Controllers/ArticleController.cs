using Horizon.Blog.Infrastructure.Redis;
using Horzion.Blog.Api.Application.CommandHandlers.ArticleHandlers;
using Horzion.Blog.Api.Params.ArticleParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("article")]
        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleParam param)
        {
            var command = new AddArticleCommand(param.Title, param.Content, "admin");
            return Ok(await _mediator.Send(command));
        }
        [Route("article")]
        [HttpGet]
        public async Task<IActionResult> AddArticle([FromServices] IRedisContext redis)
        {
            string key = "article:test";
            bool isSuccess =redis.StringSet(key, "yigiaowoligiao");
            string result = redis.StringGet(key);
            return Ok(true);
        }
    }
}
