using AutoMapper;
using Sibers.Services.Models.Employee;
using Sibers.Services.Models.Project;
using Sibers.WebApi.Models.Request.Employee;
using Sibers.WebApi.Models.Request.Project;
using Sibers.WebApi.Models.Response.Employee;
using Sibers.WebApi.Models.Response.Project;
using System.Collections.Generic;

namespace Sibers.WebApi.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            MapEmployeeControllerModels();
            MapProjectControlleerModels();
        }

        private void MapEmployeeControllerModels()
        {
            CreateMap<EmployeeDetailed, EmployeeResponse>();
            CreateMap<EmployeeListItem, EmployeeListItemResponse>();
            CreateMap<EmployeeRequest, EmployeeToSave>();
            CreateMap<ProjectDetailed, ProjectResponse>();
            CreateMap<ProjectRequest, ProjectToSave>();
        }

        private void MapProjectControlleerModels()
        {
            CreateMap<ProjectRequest, ProjectToSave>();
            CreateMap<ProjectListItem, ProjectListItemResponse>();
            CreateMap<ProjectDetailed, ProjectResponse>();
        }
    }
}
