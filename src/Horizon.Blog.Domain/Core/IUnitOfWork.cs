using System;
using System.Threading;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
