using Microsoft.EntityFrameworkCore;
using Sibers.Data.Entities;
using Sibers.Data.Repositories.Base;
using Sibers.Data.Repositories.Interfaces;

namespace Sibers.Data.Repositories
{
    /// <summary>
    /// Репозиторий работников
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region constructor
        public EmployeeRepository(ProjectContext dbContext) : base(dbContext)
        {

        }
        #endregion
    }
}
