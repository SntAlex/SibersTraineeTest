using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sibers.Data.Entities
{
    public partial class ProjectsEmployee
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("ProjectsEmployees")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("ProjectsEmployees")]
        public virtual Project Project { get; set; }
    }
}
