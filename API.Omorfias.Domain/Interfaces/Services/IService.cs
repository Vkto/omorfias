using API.Omorfias.Domain.Base;
using API.Omorfias.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Omorfias.Domain.Interfaces.Services
{
    public interface IService<TEntity, TOrderBy>
      where TEntity : class
    {
        IEnumerable<TEntity> ObterTodos(bool _readonly = true);

        TEntity ObterPorId(int id);

        TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate, bool _readonly = false, params Expression<Func<TEntity, object>>[] joins);

        IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins);

        DataResults<TEntity> Listar(QueryOptions<TEntity, TOrderBy> options, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins);

        TEntity Adicionar(TEntity entity);

        void Modificar(TEntity entity);

        void Remover(TEntity entity);

        string GetDescription(Enum en);
    }
}
