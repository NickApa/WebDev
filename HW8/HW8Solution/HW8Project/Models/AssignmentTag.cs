using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    [Table("AssignmentTag")]
    public partial class AssignmentTag
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ASSIGNMENTID")]
        public int? Assignmentid { get; set; }
        [Column("TAGNAMEID")]
        public int? Tagnameid { get; set; }
        [ForeignKey(nameof(Assignmentid))]
        [InverseProperty("AssignmentTags")]
        public virtual Assignment Assignment { get; set; }

        [ForeignKey(nameof(Tagnameid))]
        [InverseProperty("AssignmentTags")]
        public virtual Tagname Tagname { get; set; }
    }
}
