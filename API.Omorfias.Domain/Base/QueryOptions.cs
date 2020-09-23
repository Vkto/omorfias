using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Omorfias.Domain.Base
{
    public class QueryOptions<TEntity, TOrderBy>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Expression<Func<TEntity, bool>> Predicate { get; set; }
        public Expression<Func<TEntity, TOrderBy>> OrderBy { get; set; }
    }
}
