using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevitRibbon.Database.Models
{
    public class RevitParam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int ScriptId { get; set; }

        public Script Script { get; set; }

        public ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();

        [Required]
        public ParamType ParamType { get; set; }
    }

    public enum ParamType
    {
        Normal = 0,
        Concanated,
        LanguageIndependent
    }
}