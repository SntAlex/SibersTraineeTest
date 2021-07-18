using Microsoft.Extensions.DependencyInjection;
using Sibers.Data.Entities;
using Sibers.Data.Repositories;
using Sibers.Data.Repositories.Interfaces;

namespace Sibers.Configuration
{
    public static class DalConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProjectContext>();
            serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddScoped<IProjectsEmployeeRepository, ProjectsEmployeeRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}
