using Microsoft.EntityFrameworkCore;
using Sibers.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.Data.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ProjectContext dbContext;

        #region constructor
        protected BaseRepository(ProjectContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public T GetById(int id)
        {
            var dbObject = dbContext.Set<T>().Find(id);
            return dbObject;
        }

        public ICollection<T> GetAll()
        {
            return dbContext
                .Set<T>()
                .ToList();
        }

        public ICollection<T> GetAll(Func<T, bool> predicateFunc)
        {
            return dbContext
                .Set<T>()
                .Where(predicateFunc)
                .ToList();
        }

        public void Add(T entity)
        {
            dbContext.Add(entity);
        }

        public void Delete(int id)
        {
            var dbObject = dbContext.Set<T>().Find(id);
            dbContext.Remove(dbObject);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void AddRange(ICollection<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
        }

        public void DeleteRange(ICollection<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
        }
    }
}
