using Horizon.Blog.Domain.Aggregates.ArticleAggreate;
using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Horizon.Blog.Domain.Core;
using Horizon.Blog.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Horizon.Blog.Infrastructure.DatabaseContext
{
    public class BlogDbContext:DbContext
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
            if (!ChangeTracker.HasChanges()) return true;
            var result = await SaveChangesAsync();
            return result > 0;
        }


        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<ArticleFunction> ArticleFunctions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new StarConfig());
            modelBuilder.ApplyConfiguration(new ArticleFunctionConfig());
        }
    }
}
