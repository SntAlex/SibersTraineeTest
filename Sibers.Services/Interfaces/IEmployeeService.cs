using Sibers.Services.Models.Employee;
using System.Collections.Generic;

namespace Sibers.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDetailed GetEmployeeById(int id);

        ICollection<EmployeeListItem> GetEmployees();

        void AddEmployee(EmployeeToSave employee);

        void DeleteEmployee(int id);

        void UpdateEmployee(int id, EmployeeToSave employee);
    }
}
