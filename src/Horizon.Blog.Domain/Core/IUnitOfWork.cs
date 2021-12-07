using System;
using System.Threading;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> TransactionCommitAsync(CancellationToken cancellationToken = default);
    }
}
