using System;

namespace Sibers.Services.Models.Project
{
    public class ProjectListItem
    {
        public string Id { get; set; }

        public string ProjectName { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public int ProjectPriority { get; set; }
    }
}
