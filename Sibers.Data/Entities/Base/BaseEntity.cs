using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sibers.Data.Entities.Base
{
    /// <summary>
    /// Базовая сущность для работы с бд
    /// </summary>
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
    }
}
