namespace Sibers.Services.Models.Employee
{
    /// <summary>
    /// Работник для вывода в список
    /// </summary>
    public class EmployeeListItem
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }
}
