using AutoMapper;
using Sibers.Data.Entities;
using Sibers.Services.Models.Employee;
using Sibers.Services.Models.Project;
using System.Collections.Generic;

namespace Sibers.Services.Mappings
{
    public class BllMappingProfile : Profile
    {
        public BllMappingProfile()
        {
            MapEmployeeServiceModels();
            MapProjectServiceModels();
        }

        private void MapEmployeeServiceModels() 
        {
            CreateMap<Project, string>().ConvertUsing(r => r.ProjectName);
            CreateMap<Employee, EmployeeDetailed>(MemberList.Destination).ForMember(dest=> dest.ProjectsNames, opt => opt.Ignore());
            CreateMap<Employee, EmployeeListItem>(MemberList.Destination);
            CreateMap<EmployeeToSave, Employee>(MemberList.Source);
        }

        private void MapProjectServiceModels()
        {
            CreateMap<ProjectToSave, Project>(MemberList.Source).ForMember(dest => dest.Leader, opt => opt.Ignore());
            CreateMap<Project, ProjectListItem>(MemberList.Destination);
            CreateMap<Project, ProjectDetailed>(MemberList.Destination).ForMember(dest => dest.Employees, opt => opt.Ignore());
        }

    }
}
