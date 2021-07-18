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

        ICollection<ProjectListItem> GetProjects(int orderBy);

        void AddProject(ProjectToSave project);

        void DeleteProject(int id);

        void UpdateProject(int id, ProjectToSave project);
    }
}
