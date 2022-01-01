using Horizon.Blog.Domain.Core;
using Horizon.Blog.Infrastructure.DatabaseContext;
using Horizon.Blog.Service.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Horzion.Blog.Api.Application.CommandHandlers
{
    public class CommandHandler : IUnitOfWork
    {
        private readonly BlogDbContext _context;
        protected CommandHandler(BlogDbContext dbContext)
        {
            _context = dbContext ?? throw new ServerError500Exception($"数据库上下文{nameof(dbContext)}获取失败");
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveEntitiesAsync();
        }
    }
}
