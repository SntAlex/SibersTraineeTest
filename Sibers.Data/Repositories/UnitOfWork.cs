using Microsoft.EntityFrameworkCore.Storage;
using Sibers.Data.Entities;
using Sibers.Data.Repositories.Interfaces;
using System;

namespace Sibers.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly ProjectContext dbContext;
        
        public IEmployeeRepository EmployeeRepository { get; }
        
        public IProjectRepository ProjectRepository { get; }

        public IProjectsEmployeeRepository ProjectsEmployeeRepository { get; }

        #region constructor
        public UnitOfWork(ProjectContext dbContext, IEmployeeRepository employeeRepository, IProjectRepository projectRepository, IProjectsEmployeeRepository projectsEmployeeRepository)
        {
            this.dbContext = dbContext;
            this.EmployeeRepository = employeeRepository;
            this.ProjectRepository = projectRepository;
            this.ProjectsEmployeeRepository = projectsEmployeeRepository;
        }
        #endregion

        public IDbContextTransaction BeginTransaction()
        {
            return dbContext.Database.BeginTransaction();
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
