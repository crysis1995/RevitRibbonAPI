using RevitRibbon.Database.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevitRibbon.Database.Models
{
    /// <summary>
    /// Table of Revit elements group with type of element if needed
    /// </summary>
    public class Group : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Group of element for example Floor for WB_Category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of element for example P for Floors
        /// </summary>
#nullable enable
        public string? Type { get; set; }
#nullable disable

        /// <summary>
        /// If false WB_Classification will break on elements without this parameter
        /// </summary>
        [Required]
        public bool IsNullable { get; set; }

        public ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
    }
}