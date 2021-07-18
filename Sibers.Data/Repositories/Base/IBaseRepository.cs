using Sibers.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Sibers.Data.Repositories.Base
{
    /// <summary>
    /// Интерфейс базового репозитория
    /// </summary>
    /// <typeparam name="T">Сущность таблицы из бд, наследуемой от BaseEntity</typeparam>
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
