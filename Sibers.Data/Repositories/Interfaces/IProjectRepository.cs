using Sibers.Data.Entities;
using Sibers.Data.Enums;
using Sibers.Data.Repositories.Base;
using System.Collections.Generic;

namespace Sibers.Data.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория проектов
    /// </summary>
    public interface IProjectRepository : IBaseRepository<Project>
    {
        void DeleteLinksWithLeader(int leaderId);

        public ICollection<Project> GetAll(ProjectSortingSettings orderBy);
    }
}
