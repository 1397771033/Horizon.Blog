using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Application.Services
{
    public class ArticleAppService
    {
        public void StarToRedis(string articleId)
        {
            string redisKey = $"article:{articleId}:user:";
        }
    }
}
