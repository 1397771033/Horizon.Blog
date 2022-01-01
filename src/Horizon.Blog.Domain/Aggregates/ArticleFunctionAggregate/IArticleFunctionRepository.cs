using Horizon.Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate
{
    public interface IArticleFunctionRepository:IRepository<ArticleFunction>
    {
    }
}
