using AutoMapper;
using Sibers.Data.Entities;
using Sibers.Data.Repositories.Interfaces;
using Sibers.Services.Exceptions;
using Sibers.Services.Interfaces;
using Sibers.Services.Models.Employee;
using Sibers.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.Services.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;

        #region constructor
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public EmployeeDetailed GetEmployeeById(int id)
        {
            var employee = unitOfWork.EmployeeRepository.GetById(id);
            
            if (employee == null)
            {
                throw new NotFoundException("Работник с таким Id не найден");
            }

            var employeeResult = mapper.Map<EmployeeDetailed>(employee);
            
            var projectsIds = unitOfWork.ProjectsEmployeeRepository
                .GetAll(x => x.EmployeeId == id)
                .Select(p => p.ProjectId)
                .ToList();
            
            var projects = unitOfWork.ProjectRepository.GetAll(x => projectsIds.Contains(x.Id));
            
            var projectsStringList = mapper.Map<ICollection<string>>(projects);
            
            employeeResult.ProjectsNames = projectsStringList;
            
            return employeeResult;
        }

        public ICollection<EmployeeListItem> GetEmployees()
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            
            var employeesResult = mapper.Map<ICollection<EmployeeListItem>>(employees);
            
            return employeesResult;
        }

        public void AddEmployee(EmployeeToSave employee)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                var employeeToAdd = mapper.Map<Employee>(employee);
            
                unitOfWork.EmployeeRepository.Add(employeeToAdd);
                
                unitOfWork.Save();
                
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
             
                throw new BadRequestException("Ошибка при добавлении пользователя!");
            }
        }

        public void DeleteEmployee(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                unitOfWork.ProjectsEmployeeRepository.DeleteByEmployeeId(id);
             
                unitOfWork.Save();
                
                unitOfWork.ProjectRepository.DeleteLinksWithLeader(id);
                
                unitOfWork.Save();
                
                unitOfWork.EmployeeRepository.Delete(id);
                
                unitOfWork.Save();
                
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                
                throw new BadRequestException("Ошибка при удалении работника!");
            }
        }

        public void UpdateEmployee(int id, EmployeeToSave employee)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                var employeeToUpdate = unitOfWork.EmployeeRepository.GetById(id);
                
                if (employeeToUpdate == null)
                {
                    throw new NotFoundException("Работник не найден!");
                }

                mapper.Map(employee, employeeToUpdate);

                unitOfWork.EmployeeRepository.Update(employeeToUpdate);

                unitOfWork.Save();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
  
                throw new BadRequestException("Ошибка при обновлении работника!");
            }
        }


    }
}
