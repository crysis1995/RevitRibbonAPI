using RevitRibbon.Database.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevitRibbon.Database.Models
{
    /// <summary>
    /// Table of scripts in RevitRibbon
    /// </summary>
    public class Script : AuditableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Tooltip { get; set; }

        public ICollection<RevitParam> RevitParams { get; set; } = new List<RevitParam>();
    }
}