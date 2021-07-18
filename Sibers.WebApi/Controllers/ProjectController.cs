using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.Services.Interfaces;
using Sibers.Services.Models.Project;
using Sibers.WebApi.Controllers.Base;
using Sibers.WebApi.Models.Request.Project;
using Sibers.WebApi.Models.Response.Project;
using System.Collections.Generic;

namespace Sibers.WebApi.Controllers
{
    /// <summary>
    /// Контроллер проектов
    /// </summary>
    public class ProjectsController : BaseController
    {
        private readonly IProjectService projectService;

        #region constructor
        public ProjectsController(IProjectService projectService, IMapper mapper) : base(mapper)
        {
            this.projectService = projectService;
        }
        #endregion

        /// <summary>
        /// Получить проект по Id
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <returns>Проект</returns>
        [HttpGet("{id}")]
        public ActionResult<ProjectResponse> GetProject(int id)
        {
            var project = projectService.GetProjectById(id);
            var projectResponse = mapper.Map<ProjectResponse>(project);
            return Ok(projectResponse);
        }

        /// <summary>
        /// Получить список проектов
        /// </summary>
        /// <returns>Список проектов</returns>
        [HttpGet]
        public ActionResult<ICollection<ProjectListItemResponse>> GetProjects()
        {
            var projects = projectService.GetProjects();
            var projectsResponse = mapper.Map<ICollection<ProjectListItemResponse>>(projects);
            return Ok(projectsResponse);
        }

        /// <summary>
        /// Добавить проект
        /// </summary>
        /// <param name="projectRequest">Модель проекта</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProject(
            [FromBody] ProjectRequest projectRequest)
        {
            var project = mapper.Map<ProjectToSave>(projectRequest);
            projectService.AddProject(project);
            return Ok();
        }

        /// <summary>
        /// Изменить проект
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <param name="projectRequest">Модель проекта</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateProject(
            [FromHeader] int id,
            [FromBody] ProjectRequest projectRequest)
        {
            var project = mapper.Map<ProjectToSave>(projectRequest);
            projectService.UpdateProject(id, project);
            return Ok();
        }

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <returns></returns>
        [HttpDelete(("id"))]
        public ActionResult DeleteProject(int id)
        {
            projectService.DeleteProject(id);
            return Ok();
        }
    }
}
