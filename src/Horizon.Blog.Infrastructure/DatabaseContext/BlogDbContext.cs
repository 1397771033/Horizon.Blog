using Horizon.Blog.Domain.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Horizon.Blog.Infrastructure.DatabaseContext
{
    public class BlogDbContext:DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public BlogDbContext(DbContextOptions<BlogDbContext> options,
            IMediator mediator
            )
            : base(options)
        {
            _mediator = mediator??throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
