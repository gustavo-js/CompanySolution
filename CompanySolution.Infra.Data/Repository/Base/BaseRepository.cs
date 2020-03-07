using CompanySolution.Domain.Entites.Base;
using CompanySolution.Domain.Interfaces;
using CompanySolution.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanySolution.Infra.Data.Repository.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly CompanySolutionContext _dbContext;

        public BaseRepository(CompanySolutionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Create(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.Active = true;
            TEntity result = _dbContext.Set<TEntity>().Add(entity).Entity;
            _dbContext.SaveChanges();

            return result;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }


        public TEntity GetById(long id) 
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
    }
}
