namespace Sibers.Services.Models.Employee
{
    /// <summary>
    /// Работник для добавления и удаления
    /// </summary>
    public class EmployeeToSave
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }
}
