using Sibers.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sibers.Data.Entities
{
    /// <summary>
    /// Таблица для проекта
    /// </summary>
    public partial class Project : BaseEntity
    {
        public Project()
        {
            ProjectsEmployees = new HashSet<ProjectsEmployee>();
        }

        [Required]
        [StringLength(64)]
        public string ProjectName { get; set; }
        [Required]
        [StringLength(64)]
        public string ClientName { get; set; }
        [Required]
        [StringLength(64)]
        public string ContractorName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartingDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndingDate { get; set; }
        public int? ProjectPriority { get; set; }
        public int? LeaderId { get; set; }

        [ForeignKey(nameof(LeaderId))]
        [InverseProperty(nameof(Employee.Projects))]
        public virtual Employee Leader { get; set; }
        [InverseProperty(nameof(ProjectsEmployee.Project))]
        public virtual ICollection<ProjectsEmployee> ProjectsEmployees { get; set; }
    }
}
