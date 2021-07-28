using RevitRibbon.Database.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevitRibbon.Database.Models
{
    public class SharedParameterGroup : AuditableEntity, IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<SharedParameter> SharedParameters { get; set; } = new List<SharedParameter>();
    }
}