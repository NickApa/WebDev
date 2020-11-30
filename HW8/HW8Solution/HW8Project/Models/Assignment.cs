using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentTags = new HashSet<AssignmentTag>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("IMPORTANCE")]
        public int? Importance { get; set; }

        [Column("DUE", TypeName = "datetime")]
        public DateTime? Due { get; set; }

        [Column("TITLE")]
        [StringLength(50)]
        public string Title { get; set; }

        [Column("NOTES")]
        [StringLength(250)]
        public string Notes { get; set; }

        [Column("COURSEID")]
        public int? Courseid { get; set; }

        [ForeignKey(nameof(Courseid))]
        [InverseProperty(nameof(Cours.Assignments))]
        public virtual Cours Course { get; set; }

        [InverseProperty(nameof(AssignmentTag.Assignment))]
        public virtual ICollection<AssignmentTag> AssignmentTags { get; set; }
    }
}
