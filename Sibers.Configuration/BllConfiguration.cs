using Microsoft.Extensions.DependencyInjection;
using Sibers.Services.Interfaces;
using Sibers.Services.Services;

namespace Sibers.Configuration
{
    public static class BllConfiguration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
            serviceCollection.AddScoped<IProjectService, ProjectService>();
            return serviceCollection;
        }
    }
}
