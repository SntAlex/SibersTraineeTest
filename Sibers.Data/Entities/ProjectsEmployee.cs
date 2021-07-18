using Sibers.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sibers.Data.Entities
{
    public partial class ProjectsEmployee : BaseEntity
    {
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
