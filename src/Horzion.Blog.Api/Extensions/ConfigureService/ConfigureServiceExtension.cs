using Horizon.Blog.Api.Extensions.ConfigureServices;
using Horzion.Blog.Api.Extensions.ConfigureService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Extensions
{
    public static class ConfigureServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var configureBaseService = new ConfigureBaseService(services, configuration);
            var configureDI = new ConfigureDI(services);

            configureBaseService.ConfigureBase();
            configureBaseService.ConfigureCors();
            configureBaseService.ConfigureAuthentication();
            configureBaseService.ConfigureSwagger();
            configureBaseService.ConfigExceptionResult();
            configureBaseService.ConfigureMediatR();
            configureBaseService.ConfigureDataAccess();



            configureDI.ConfigureCommandHandler();
            configureDI.ConfigureRepository();
            configureDI.ConfigureDomainEventHandler();
            configureDI.ConfigureQueries();
            configureDI.ConfigureDomainService();
        }
    }
}
