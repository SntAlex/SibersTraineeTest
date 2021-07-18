using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [StringLength(64, ErrorMessage = "{0} должно быть между {2} и {1} символами.", MinimumLength = 1)]
        public string ProjectName { get; set; }

        /// <summary>
        /// Имя заказчика
        /// </summary>
        [Required]
        [StringLength(64, ErrorMessage = "{0} должно быть между {2} и {1} символами.", MinimumLength = 1)]
        public string ClientName { get; set; }

        /// <summary>
        /// Имя исполнителя
        /// </summary>
        [Required]
        [StringLength(64, ErrorMessage = "{0} должно быть между {2} и {1} символами.", MinimumLength = 1)]
        public string ContractorName { get; set; }

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }

        /// <summary>
        /// Приоритет проекта
        /// </summary>
        [Range(0, int.MaxValue)]
        public int ProjectPriority { get; set; }

        /// <summary>
        /// Id лидера проекта
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Leader { get; set; }

        /// <summary>
        /// Id всех работников на проекте
        /// </summary>
        public ICollection<int> Employees { get; set; }
    }
}
