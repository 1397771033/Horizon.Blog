using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Horizon.Blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Horizon.Blog.Infrastructure.Repositories
{
    public class ArticleFunctionRepository : Repository<ArticleFunction>, IArticleFunctionRepository
    {
        public ArticleFunctionRepository(BlogDbContext context) : base(context)
        {
        }

        public override ArticleFunction Get(string id)
        {
            return _context.ArticleFunctions
                .Include(_ => _.Reviews)
                .Include(_ => _.Stars)
                .FirstOrDefault(_ => _.Id == id);
        }
    }
}
