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
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
