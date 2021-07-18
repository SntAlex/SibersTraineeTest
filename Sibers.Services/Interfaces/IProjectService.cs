using Sibers.Services.Models.Project;
using System.Collections.Generic;

namespace Sibers.Services.Interfaces
{
    public interface IProjectService
    {
        ProjectDetailed GetProjectById(int id);

        ICollection<ProjectListItem> GetProjects();

        void AddProject(ProjectToSave project);

        void DeleteProject(int id);

        void UpdateProject(int id, ProjectToSave project);
    }
}
