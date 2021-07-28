using Autodesk.Revit.DB;
using RevitRibbon.Database.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevitRibbon.Database.Models
{
    public class SharedParameter : AuditableEntity, IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int ScriptId { get; set; }

        [Required]
        public int SharedParameterGroupId { get; set; }

        [Required]
        public TextInputType TextInputType { get; set; }

        [Required]
        public ParameterType ParameterType { get; set; }

        [Required]
        public BuiltInParameterGroup BuiltInParameterGroup { get; set; }

        [Required]
        public BuiltInCategory[] BuiltInCategories { get; set; }

        public Script Script { get; set; }

        public SharedParameterGroup SharedParameterGroup { get; set; }

        public ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
    }
}