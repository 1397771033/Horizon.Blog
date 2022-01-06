using CSRedis;
using Horizon.Blog.Infrastructure.DatabaseContext;
using Horizon.Blog.Service.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.IO;

namespace Horzion.Blog.ClientApi.Extensions.ConfigureService
{
    public class ConfigureBaseService
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;
        public ConfigureBaseService(IServiceCollection services, IConfiguration configuration)
        {
            this.services = services;
            this.configuration = configuration;
        }
        public void ConfigureBase()
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.UseCamelCasing(true);
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }
        /// <summary>
        /// 异常处理Response
        /// </summary>
        public void ConfigExceptionResult()
        {
            services.AddSingleton<ErrorResponse>();
        }
        /// <summary>
        /// 跨域设置
        /// </summary>
        public void ConfigureCors()
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("default", policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod();
                });
            });
        }
        /// <summary>
        /// 数据库查询
        /// </summary>
        public void ConfigureDataAccess()
        {
            //var pgsqlConnection = configuration.GetValue<string>(ApolloConfigKeys.POSTGRE_URL);
            string connStr = configuration.GetValue<string>("ConnectionStrings:PostgreSql");
            services.AddDbContext<BlogDbContext>(opt =>
            {
                opt.UseNpgsql(connStr);
            });
        }
        /// <summary>
        /// swagger
        /// </summary>
        public void ConfigureSwagger()
        {
            services.AddSwaggerGen(c =>
            {
                #region Swagger使用鉴权组件
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                #endregion
                #region Swagger加上Api文档注释
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Horizon.Blog"
                });
                // 获取dll
                var path = typeof(Program).Assembly.Location;
                var basePath = Path.GetDirectoryName(path);
                // 为Swagger接口配置注释路径
                var xmlPath = Path.Combine(basePath, "Horzion.Blog.ClientApi.xml");
                c.IncludeXmlComments(xmlPath);
                #endregion

            });
        }
        /// <summary>
        /// 认证
        /// </summary>
        public void ConfigureAuthentication()
        {

        }
        /// <summary>
        /// 配置mediatr
        /// </summary>
        public void ConfigureMediatR()
        {
            services.AddMediatR(typeof(Startup));
        }
        public void ConfigureRedis()
        {
            var redisConnection = configuration["ConnectionStrings:Redis"];
            var csredis = new CSRedisClient(redisConnection);
            RedisHelper.Initialization(csredis);
        }
    }
}
