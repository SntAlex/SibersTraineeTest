using Sibers.Services.Models.Employee;
using System.Collections.Generic;

namespace Sibers.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса работников
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Получить работника по Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Работник</returns>
        EmployeeDetailed GetEmployeeById(int id);

        /// <summary>
        /// Получить всех работников
        /// </summary>
        /// <returns>Список работников</returns>
        ICollection<EmployeeListItem> GetEmployees();

        /// <summary>
        /// Добавить работника
        /// </summary>
        /// <param name="employee">Работник</param>
        void AddEmployee(EmployeeToSave employee);

        /// <summary>
        /// Удалить работника по Id
        /// </summary>
        /// <param name="id">Id</param>
        void DeleteEmployee(int id);

        /// <summary>
        /// Обновить работника
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="employee">Работник</param>
        void UpdateEmployee(int id, EmployeeToSave employee);
    }
}
