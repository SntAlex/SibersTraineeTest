using System;
using System.Collections.Generic;

namespace Sibers.WebApi.Models.Request.Project
{
    /// <summary>
    /// Модель проекта на запрос
    /// </summary>
    public class ProjectRequest
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
        /// Id лидера проекта
        /// </summary>
        public int Leader { get; set; }

        /// <summary>
        /// Id всех работников на проекте
        /// </summary>
        public ICollection<int> Employees { get; set; }
    }
}
