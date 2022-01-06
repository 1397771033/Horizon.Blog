using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horzion.Blog.ClientApi.Application.Services.Dto
{
    public class StarToRedisDto
    {
        public string ArticleId { get; set; }
        public string CreatorIp { get; set; }
        public DateTime CreationTime { get; set; }
        public StarToRedisDto(string articleId, string creatorIp)
        {
            ArticleId = articleId;
            CreatorIp = creatorIp;
            CreationTime =new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
        }
        public StarToRedisDto()
        {

        }
    }
}
