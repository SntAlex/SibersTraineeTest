using Sibers.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Sibers.Data.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(int id);

        ICollection<T> GetAll();

        ICollection<T> GetAll(Func<T, bool> predicateFunc);

        void Add(T entity);

        void Delete(int id);

        void Update(T entity);

        void AddRange(ICollection<T> entities);

        void DeleteRange(ICollection<T> entities);
    }
}
