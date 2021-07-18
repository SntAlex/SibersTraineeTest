using System.ComponentModel.DataAnnotations;

namespace Sibers.WebApi.Models.Request.Employee
{
    /// <summary>
    /// Модель работника на запрос
    /// </summary>
    public class EmployeeRequest
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(40, ErrorMessage = "{0} должно быть между {2} и {1} символами.", MinimumLength = 1)]
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(40, ErrorMessage = "{0} должна быть между {2} и {1} символами.", MinimumLength = 1)]
        public string Lastname { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
