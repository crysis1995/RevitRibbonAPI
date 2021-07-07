﻿using RevitRibbon.Database.Common;
using System.ComponentModel.DataAnnotations;

namespace RevitRibbon.Database.Models
{
    public class Parameter : AuditableEntity
    {
        [Key]
        [MaxLength(5)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Pl { get; set; }

        [Required]
        [MaxLength(100)]
        public string En { get; set; }

        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        [Required]
        public int RevitParamId { get; set; }

        public RevitParam RevitParam { get; set; }
    }
}