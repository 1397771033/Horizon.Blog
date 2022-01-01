using Horizon.Blog.Domain.Core;
using Horizon.Blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Horizon.Blog.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        protected readonly BlogDbContext _context;

        protected Repository(BlogDbContext context)
        {
            _context = context;
        }

        public abstract TEntity Get(string id);

        public virtual TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
