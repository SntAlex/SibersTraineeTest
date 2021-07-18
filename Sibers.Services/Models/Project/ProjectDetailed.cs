using Sibers.Services.Models.Employee;
using System;
using System.Collections.Generic;

namespace Sibers.Services.Models.Project
{
    /// <summary>
    /// Проект
    /// </summary>
    public class ProjectDetailed
    {
        public string ProjectName { get; set; }

        public string ClientName { get; set; }

        public string ContractorName { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public int ProjectPriority { get; set; }

        public EmployeeListItem Leader { get; set; }

        public ICollection<EmployeeListItem> Employees { get; set; }
    }
}
