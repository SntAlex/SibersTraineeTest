namespace Sibers.WebApi.Models.Response.Employee
{
    /// <summary>
    /// Модель работника для вывода в список
    /// </summary>
    public class EmployeeListItemResponse
    {
        /// <summary>
        /// Id работника
        /// </summary>
        public int Id { get; set; }

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
