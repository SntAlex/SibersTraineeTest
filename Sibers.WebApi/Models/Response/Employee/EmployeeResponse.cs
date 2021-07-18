using System.Collections.Generic;

namespace Sibers.WebApi.Models.Response.Employee
{
    /// <summary>
    /// Модель работника на ответ
    /// </summary>
    public class EmployeeResponse
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Имена всех проектов работника
        /// </summary>
        public ICollection<string> ProjectsNames { get; set; }
    }
}
