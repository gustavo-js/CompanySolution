using CompanySolution.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Create(TEntity item);
        void Delete(TEntity item);
        void Update(TEntity item);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
    }
}
