using AutoMapper;
using Sibers.Data.Entities;
using Sibers.Data.Enums;
using Sibers.Data.Repositories.Interfaces;
using Sibers.Services.Exceptions;
using Sibers.Services.Interfaces;
using Sibers.Services.Models.Employee;
using Sibers.Services.Models.Project;
using Sibers.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.Services.Services
{
    /// <summary>
    /// Реализация сервиса для проектов
    /// </summary>
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IUnitOfWork unitOfWork;

        #region constructor
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public ProjectDetailed GetProjectById(int id)
        {
            var project = unitOfWork.ProjectRepository.GetById(id);

            if (project == null)
            {
                throw new NotFoundException("Project not found");
            }
                
            var projectResult = mapper.Map<ProjectDetailed>(project);

            var leader = unitOfWork.EmployeeRepository
                .GetById(project.LeaderId == null ? default(int) : project.LeaderId.Value);

            var leaderResult = mapper.Map<EmployeeListItem>(leader);
            
            projectResult.Leader = leaderResult;
            
            var employeesIds = unitOfWork.ProjectsEmployeeRepository
                .GetAll(x => x.ProjectId == id)
                .Select(x=>x.EmployeeId)
                .ToList();
            
            var employees = unitOfWork.EmployeeRepository
                .GetAll(x => employeesIds.Contains(x.Id));
            
            var employeesResult = mapper.Map<ICollection<EmployeeListItem>>(employees);
            
            projectResult.Employees = employeesResult;
            
            return projectResult;
        }

        public ICollection<ProjectListItem> GetProjects(int orderBy)
        {
            
            var projects = unitOfWork.ProjectRepository.GetAll((ProjectSortingSettings)orderBy);
            
            var projectsResult = mapper.Map<ICollection<ProjectListItem>>(projects);
            
            return projectsResult;
        }

        public void AddProject(ProjectToSave project)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                var employeesInProjectIds = project.Employees;
            
                var employees = unitOfWork.EmployeeRepository
                    .GetAll(x => employeesInProjectIds.Contains(x.Id));

                var projectToAdd = mapper.Map<Project>(project);
   
                var leader = unitOfWork.EmployeeRepository.GetById(project.Leader);
                
                projectToAdd.Leader = leader;
                
                unitOfWork.ProjectRepository.Add(projectToAdd);
                
                unitOfWork.Save();
                
                var projectEmployeeList = getLinkedProjectEmployeeList(projectToAdd, employees);
                
                unitOfWork.ProjectsEmployeeRepository.AddRange(projectEmployeeList);
                
                unitOfWork.Save();
                
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                
                throw new BadRequestException("Error while adding project");
            }
        }

        public void DeleteProject(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                unitOfWork.ProjectsEmployeeRepository.DeleteByProjectId(id);
                
                unitOfWork.Save();
                
                unitOfWork.ProjectRepository.Delete(id);
                
                unitOfWork.Save();
                
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                
                throw new BadRequestException("Error while deleting project");
            }
        }

        public void UpdateProject(int id, ProjectToSave project)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                var projectToUpdate = unitOfWork.ProjectRepository.GetById(id);

                if (projectToUpdate == null)
                {
                    throw new NotFoundException("Project not found");
                }
                
                mapper.Map(project, projectToUpdate);
                
                var leader = unitOfWork.EmployeeRepository.GetById(project.Leader);
                
                projectToUpdate.Leader = leader;
                
                unitOfWork.ProjectRepository.Update(projectToUpdate);
                
                unitOfWork.Save();
                
                var projectEmployees = unitOfWork.ProjectsEmployeeRepository
                    .GetAll(x => x.ProjectId == id);
                
                var employeesInProjectIds = project.Employees;
               
                var projectEmployeesToAddIds = employeesInProjectIds
                    .Except(projectEmployees.Select(x => x.EmployeeId));
                
                var employeesToAdd = unitOfWork.EmployeeRepository
                    .GetAll(e => projectEmployeesToAddIds.Contains(e.Id));
                
                var projectEmployeeList = getLinkedProjectEmployeeList(projectToUpdate, employeesToAdd);
                
                unitOfWork.ProjectsEmployeeRepository.AddRange(projectEmployeeList);
                
                unitOfWork.Save();
                
                var employeesToDeleteFromProjectIds = projectEmployees
                    .Select(x => x.EmployeeId)
                    .Except(employeesInProjectIds);
                
                var projectEmployeesToDelete = unitOfWork.ProjectsEmployeeRepository
                    .GetAll(pe => pe.ProjectId == id && employeesToDeleteFromProjectIds.Contains(pe.EmployeeId));
                
                unitOfWork.ProjectsEmployeeRepository.DeleteRange(projectEmployeesToDelete);
                
                unitOfWork.Save();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new BadRequestException("Error, while changing project");
            }
        }

        private ICollection<ProjectsEmployee> getLinkedProjectEmployeeList(Project project, ICollection<Employee> employees)
        {
            var projectEmployeeList = new List<ProjectsEmployee>();
            foreach (var employee in employees)
            {
                var projectEmployee = new ProjectsEmployee()
                {
                    Employee = employee,
                    Project = project,
                };
                projectEmployeeList.Add(projectEmployee);
            }
            return projectEmployeeList;
        }
        
    }
}
