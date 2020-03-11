using CompanySolution.Domain.Entites.Base;
using CompanySolution.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanySolution.Service.Services.Base
{
    public abstract class BaseService<T> : IService<T> where T : EntityBase
    {

        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public virtual T Post<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());

            return _repository.Create(entity);
        }

        public virtual T Put<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());

            _repository.Update(entity);
            return entity;
        }

        public void Delete(long id)
        {
            if (id == 0)
                throw new ArgumentException("Delete error - invalid id");

            _repository.Delete(_repository.GetById(id));
        }

        public IList<T> Get() => _repository.GetAll().ToList<T>();

        public T Get(long id)
        {
            if (id == 0)
                throw new ArgumentException("Get error - invalid id");

            return _repository.GetById(id);
        }

        private void Validate(T entity, AbstractValidator<T> validator)
        {
            if (entity == null)
                throw new Exception("Validating error - null entity");

            validator.ValidateAndThrow(entity);
        }
    }
}
