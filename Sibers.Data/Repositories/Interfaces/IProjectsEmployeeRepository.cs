using Sibers.Data.Entities;
using Sibers.Data.Repositories.Base;

namespace Sibers.Data.Repositories.Interfaces
{
    public interface IProjectsEmployeeRepository : IBaseRepository<ProjectsEmployee>
    {
        void DeleteByEmployeeId(int employeeId);
       
        void DeleteByProjectId(int projectId);

    }
}
