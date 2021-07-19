using Sibers.Services.Enums;
using Sibers.Services.Models.Project;
using System.Collections.Generic;

namespace Sibers.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса проектов
    /// </summary>
    public interface IProjectService
    {
        ProjectDetailed GetProjectById(int id);

        ICollection<ProjectListItem> GetProjects(ProjectSortingSettings projectSortingSettings);

        void AddProject(ProjectToSave project);

        void DeleteProject(int id);

        void UpdateProject(int id, ProjectToSave project);
    }
}
