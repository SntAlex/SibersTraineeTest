using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sibers.Data.Entities.Base;

#nullable disable

namespace Sibers.Data.Entities
{
    /// <summary>
    /// Таблица работника
    /// </summary>
    [Index(nameof(Email), Name = "UQ__Employee__A9D1053482C57762", IsUnique = true)]
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            Projects = new HashSet<Project>();
            ProjectsEmployees = new HashSet<ProjectsEmployee>();
        }

        [Required]
        [StringLength(40)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(40)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [InverseProperty(nameof(Project.Leader))]
        public virtual ICollection<Project> Projects { get; set; }
        [InverseProperty(nameof(ProjectsEmployee.Employee))]
        public virtual ICollection<ProjectsEmployee> ProjectsEmployees { get; set; }
    }
}
