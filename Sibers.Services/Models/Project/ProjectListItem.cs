using System;

namespace Sibers.Services.Models.Project
{
    /// <summary>
    /// Проект для вывода в список
    /// </summary>
    public class ProjectListItem
    {
        public string Id { get; set; }

        public string ProjectName { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public int ProjectPriority { get; set; }
    }
}
