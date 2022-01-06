using Horzion.Blog.ClientApi.Application.Services.Dto;
using System;

namespace Horzion.Blog.ClientApi.Application.Services
{
    public class ArticleAppService
    {
        public bool StarToRedis(string articleId,string creatorIp)
        {
            //if (RedisHelper.Exists(key)) return false;
            //return RedisHelper.Set(key, DateTime.Now);
            return true;
        }
    }
}
