using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Sibers.Data.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс паттерна UnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository ProjectRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }

        IProjectsEmployeeRepository ProjectsEmployeeRepository { get; }

        IDbContextTransaction BeginTransaction();

        int Save();
    }
}
