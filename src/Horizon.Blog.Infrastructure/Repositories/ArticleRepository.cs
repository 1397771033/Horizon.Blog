using Horizon.Blog.Domain.Aggregates.ArticleAggreate;
using Horizon.Blog.Domain.Aggregates.ArticleAggregate;
using Horizon.Blog.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogDbContext context) : base(context)
        {

        }
        public override Article Get(string id)
        {
            return _context.Articles.FirstOrDefault(_ => _.Id == id);
        }

        public Article GetBySortNum(bool asc = false)
        {
            if (_context.Articles.Any())
            {
                return asc 
                    ?_context.Articles.OrderBy(_ => _.SortNum).FirstOrDefault()
                    : _context.Articles.OrderByDescending(_ => _.SortNum).FirstOrDefault();
            }
            return null;
        }
    }
}
