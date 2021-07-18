using System.Collections.Generic;

namespace Sibers.Services.Models.Employee
{
    /// <summary>
    /// Работник
    /// </summary>
    public class EmployeeDetailed
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public ICollection<string> ProjectsNames { get; set; }
    }
}
