using API.Omorfias.Data.Base;
using API.Omorfias.Domain.Base;
using API.Omorfias.Domain.Base.Interfaces.Repositories;
using API.Omorfias.Domain.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace API.Omorfias.Data.Repositories.Core
{
    public class Repository<TEntity, TOrderBy> : IRepository<TEntity, TOrderBy>, IDisposable
           where TEntity : class
    {
        private readonly OmorfiasContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(OmorfiasContext dbContext)
        {
            _dbContext = dbContext;

            _dbSet = _dbContext.Set<TEntity>();
        }

        protected OmorfiasContext DbContext
        {
            get { return _dbContext; }
        }

        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Remover(TEntity entity)
        {
            DbSet.Remove(entity);

            _dbContext.SetState(entity, EntityState.Deleted);
        }

        public virtual void Modificar(TEntity entity)
        {
            DbSet.Attach(entity);

            _dbContext.SetState(entity, EntityState.Modified);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate, bool _readonly = false, params Expression<Func<TEntity, object>>[] joins)
        {
            if (_readonly)
                return DbSet.IncludeMultiple(joins).AsNoTracking().FirstOrDefault(predicate);

            return DbSet.IncludeMultiple(joins).FirstOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> ObterTodos(bool _readonly = false)
        {
            if (_readonly)
                return DbSet.AsNoTracking().ToList();

            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins)
        {
            if (_readonly)
                return DbSet.IncludeMultiple(joins).AsNoTracking().Where(predicate);

            return DbSet.IncludeMultiple(joins).Where(predicate);
        }

        public virtual DataResults<TEntity> Listar(QueryOptions<TEntity, TOrderBy> options, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins)
        {
            var rowsCount = default(int);

            if (_readonly)
            {
                rowsCount = options.Predicate != null ?
                    DbSet.IncludeMultiple(joins).Where(options.Predicate).OrderBy(options.OrderBy).AsNoTracking().Count() :
                    DbSet.OrderBy(options.OrderBy).AsNoTracking().Count();
            }
            else
            {
                rowsCount = options.Predicate != null ?
                    DbSet.IncludeMultiple(joins).Where(options.Predicate).OrderBy(options.OrderBy).Count() :
                    DbSet.OrderBy(options.OrderBy).Count();
            }

            if (rowsCount <= options.Take || options.Skip <= 0) options.Skip = 1;

            var skip = (options.Skip - 1) * options.Take;

            var data = default(IEnumerable<TEntity>);

            if (_readonly)
            {
                data = options.Predicate != null ?
                    DbSet.IncludeMultiple(joins).Where(options.Predicate).OrderBy(options.OrderBy).Skip(skip).Take(options.Take).AsNoTracking().ToList() :
                    DbSet.OrderBy(options.OrderBy).Skip(skip).Take(options.Take).AsNoTracking().ToList();
            }
            else
            {
                data = options.Predicate != null ?
                    DbSet.IncludeMultiple(joins).Where(options.Predicate).OrderBy(options.OrderBy).Skip(skip).Take(options.Take).ToList() :
                    DbSet.OrderBy(options.OrderBy).Skip(skip).Take(options.Take).ToList();
            }

            var dataResults = new DataResults<TEntity>();

            dataResults.Count = rowsCount;

            dataResults.Data = data;

            return dataResults;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_dbContext == null) return;

            _dbContext.Dispose();
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        #endregion Dispose
    }
}
