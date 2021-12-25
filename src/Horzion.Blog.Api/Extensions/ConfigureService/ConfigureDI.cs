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

        }
        /// <summary>
        /// 配置仓储
        /// </summary>
        public void ConfigureRepository()
        {

        }
        /// <summary>
        /// 配置查询
        /// </summary>
        public void ConfigureQueries()
        {

        }
    }
}
