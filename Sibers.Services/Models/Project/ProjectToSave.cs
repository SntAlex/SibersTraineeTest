using System;
using System.Collections.Generic;

namespace Sibers.Services.Models.Project
{
    /// <summary>
    /// Проект для сохранения и обновления
    /// </summary>
    public class ProjectToSave
    {
        public string ProjectName { get; set; }

        public string ClientName { get; set; }

        public string ContractorName { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public int ProjectPriority { get; set; }

        public int Leader { get; set; }

        public ICollection<int> Employees { get; set; }
    }
}
