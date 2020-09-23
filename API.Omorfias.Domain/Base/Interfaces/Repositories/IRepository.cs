using API.Omorfias.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Omorfias.Domain.Base.Interfaces.Repositories
{
    public interface IRepository<TEntity, TOrderBy>
        where TEntity : class
    {
        void Adicionar(TEntity entity);

        void Modificar(TEntity entity);

        void Remover(TEntity entity);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> ObterTodos(bool _readonly = false);

        TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate, bool _readonly = false, params Expression<Func<TEntity, object>>[] joins);

        IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate, bool _readonly = false, params Expression<Func<TEntity, object>>[] joins);

        DataResults<TEntity> Listar(QueryOptions<TEntity, TOrderBy> options, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins);

    }
}
