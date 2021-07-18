using System;
using System.ComponentModel.DataAnnotations;

namespace Sibers.WebApi.Models.Response.Project
{
    /// <summary>
    /// Модель проекта для вывода в список
    /// </summary>
    public class ProjectListItemResponse
    {
        /// <summary>
        /// Id проекта
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя проекта
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Дата начала проета
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
    }
}
