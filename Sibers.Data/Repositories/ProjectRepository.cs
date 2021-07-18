using Sibers.Data.Entities;
using Sibers.Data.Enums;
using Sibers.Data.Repositories.Base;
using Sibers.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.Data.Repositories
{
    /// <summary>
    /// Репозиторий проектов
    /// </summary>
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        #region constructor
        public ProjectRepository(ProjectContext dbContext) : base(dbContext)
        {

        }
        #endregion

        public void DeleteLinksWithLeader(int leaderId)
        {
            var projects = dbContext.Projects.Where(p => p.LeaderId == leaderId);
            foreach (var project in projects)
            {
                project.LeaderId = null;
            }

            dbContext.Projects.UpdateRange(projects);
        }

        public ICollection<Project> GetAll(ProjectSortingSettings orderBy) =>
            orderBy switch
            {
                ProjectSortingSettings.ProjectName => dbContext.Set<Project>().OrderBy(p => p.ProjectName).ToList(),
                ProjectSortingSettings.ClientName => dbContext.Set<Project>().OrderBy(p => p.ClientName).ToList(),
                ProjectSortingSettings.ContractorName => dbContext.Set<Project>().OrderBy(p => p.ContractorName).ToList(),
                ProjectSortingSettings.StartingDate => dbContext.Set<Project>().OrderBy(p => p.StartingDate).ToList(),
                ProjectSortingSettings.EndingDate => dbContext.Set<Project>().OrderBy(p => p.EndingDate).ToList(),
                ProjectSortingSettings.Priority => dbContext.Set<Project>().OrderBy(p => p.ProjectPriority).ToList(),
                _ => dbContext.Set<Project>().OrderBy(p => p.ProjectName).ToList()
            };
    }
}
