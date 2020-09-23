using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace API.Omorfias.Data.Repositories.Core
{
    public static class IncludeExtension
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<TEntity> Include<TEntity>(this DbSet<TEntity> dbSet, params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            IQueryable<TEntity> query = null;

            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query == null ? dbSet : query;
        }
    }
}
