using Sibers.Data.Entities;
using Sibers.Data.Repositories.Base;

namespace Sibers.Data.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для связи проектов и работников
    /// </summary>
    public interface IProjectsEmployeeRepository : IBaseRepository<ProjectsEmployee>
    {
        void DeleteByEmployeeId(int employeeId);
       
        void DeleteByProjectId(int projectId);

    }
}
