using Sibers.Data.Entities;
using Sibers.Data.Repositories.Base;
using Sibers.Data.Repositories.Interfaces;
using System.Linq;

namespace Sibers.Data.Repositories
{
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
    }
}
