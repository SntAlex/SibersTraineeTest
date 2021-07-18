using Sibers.Data.Entities;
using Sibers.Data.Repositories.Base;

namespace Sibers.Data.Repositories.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        void DeleteLinksWithLeader(int leaderId);
    }
}
