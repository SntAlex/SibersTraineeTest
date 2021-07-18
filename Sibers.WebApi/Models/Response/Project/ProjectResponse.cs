using Sibers.WebApi.Models.Response.Employee;
using System;
using System.Collections.Generic;

namespace Sibers.WebApi.Models.Response.Project
{
    /// <summary>
    /// Модель проекта на ответ
    /// </summary>
    public class ProjectResponse
    {
        /// <summary>
        /// Имя проекта
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Имя заказчика
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Имя исполнителя
        /// </summary>
        public string ContractorName { get; set; }

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        public DateTime StartingDate { get; set; }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>
        public DateTime EndingDate { get; set; }

        /// <summary>
        /// Приоритет проекта
        /// </summary>
        public int ProjectPriority { get; set; }
        
        /// <summary>
        /// Лидер проекта
        /// </summary>
        public EmployeeListItemResponse Leader { get; set; }

        /// <summary>
        /// Работники проекта
        /// </summary>
        public ICollection<EmployeeListItemResponse> Employees { get; set; }
    }
}
