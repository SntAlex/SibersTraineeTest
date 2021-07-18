using Sibers.Data.Entities;
using Sibers.Data.Repositories.Base;
using Sibers.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.Data.Repositories
{
    public class ProjectsEmployeeRepository : BaseRepository<ProjectsEmployee>, IProjectsEmployeeRepository
    {
        #region constructor
        public ProjectsEmployeeRepository(ProjectContext dbContext) : base(dbContext)
        {

        }
        #endregion

        public void DeleteByEmployeeId(int employeeId)
        {
            var pe = dbContext.ProjectsEmployees.Where(pe => pe.EmployeeId == employeeId).ToList();
            dbContext.ProjectsEmployees.RemoveRange(pe);
        }

        public void DeleteByProjectId(int projectId)
        {
            var pe = dbContext.ProjectsEmployees.Where(pe => pe.ProjectId == projectId).ToList();
            dbContext.ProjectsEmployees.RemoveRange(pe);
        }
    }
}
