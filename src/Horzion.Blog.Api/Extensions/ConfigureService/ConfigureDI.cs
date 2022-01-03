using Horizon.Blog.Domain.Aggregates.ArticleAggregate;
using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Horizon.Blog.Domain.Service;
using Horizon.Blog.Infrastructure.Redis;
using Horizon.Blog.Infrastructure.Repositories;
using Horzion.Blog.Api.Application.CommandHandlers.ArticleHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Horizon.Blog.Api.Extensions.ConfigureServices
{
    public class ConfigureDI
    {
        private readonly IServiceCollection services;
        public ConfigureDI(IServiceCollection services)
        {
            this.services = services;
        }
        /// <summary>
        /// 配置命令处理器
        /// </summary>
        public void ConfigureCommandHandler()
        {
            services.AddScoped<IRequestHandler<AddArticleCommand, bool>, AddArticleCommandHandler>();
        }
        /// <summary>
        /// 配置领域事件
        /// </summary>
        public void ConfigureDomainEventHandler()
        {

        }
        /// <summary>
        /// 配置领域服务
        /// </summary>
        public void ConfigureDomainService()
        {
            services.AddScoped<ArticleService>();
            services.AddScoped<ArticleFunctionService>();
        }
        /// <summary>
        /// 配置仓储
        /// </summary>
        public void ConfigureRepository()
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleFunctionRepository, ArticleFunctionRepository>();
        }
        /// <summary>
        /// 配置查询
        /// </summary>
        public void ConfigureQueries()
        {

        }
        /// <summary>
        /// 配置redis
        /// </summary>
        public void ConfigureRedis()
        {
            services.AddScoped<IRedisContext, RedisContext>();
            services.AddScoped<AbstructRedisContext, RedisContext>();
        }
    }
}
