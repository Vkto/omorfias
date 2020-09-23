using API.Omorfias.Domain.Base.Interfaces.Repositories;
using API.Omorfias.Domain.Interfaces.Services;
using API.Omorfias.Domain.Interfaces.Validations.Services;
using API.Omorfias.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace API.Omorfias.Domain.Base.Services
{
    public class Service<TEntity, TOrderBy> : IService<TEntity, TOrderBy>
         where TEntity : class
    {
        #region Constructor

        private readonly IRepository<TEntity, TOrderBy> _repository;
        private readonly ValidationResult _validationResult;

        public Service(IRepository<TEntity, TOrderBy> repository)
        {
            _repository = repository;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IRepository<TEntity, TOrderBy> Repository
        {
            get { return _repository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Read Methods

        public virtual TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos(bool _readonly = true)
        {
            return _repository.ObterTodos(_readonly);
        }

        public virtual TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate, bool _readonly = false, params Expression<Func<TEntity, object>>[] joins)
        {
            return _repository.ObterPorCondicao(predicate, _readonly, joins);
        }

        public virtual IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins)
        {
            return _repository.Listar(predicate, _readonly, joins);
        }

        public virtual DataResults<TEntity> Listar(QueryOptions<TEntity, TOrderBy> options, bool _readonly = true, params Expression<Func<TEntity, object>>[] joins)
        {
            return _repository.Listar(options, _readonly, joins);
        }

        #endregion

        #region CRUD Methods

        public virtual TEntity Adicionar(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return entity;

            var selfValidationEntity = entity as ISelfValidation;

            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return entity;

            _repository.Adicionar(entity);

            return entity;
        }

        public virtual void Modificar(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return;

            var selfValidationEntity = entity as ISelfValidation;

            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return;

            _repository.Modificar(entity);
        }

        public virtual void Remover(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return;

            _repository.Remover(entity);
        }

        public virtual string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        #endregion
    }
}
