using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class Tagname
    {
        public Tagname()
        {
            AssignmentTags = new HashSet<AssignmentTag>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TAGNAME")]
        [StringLength(20)]
        public string Tagname1 { get; set; }

        [InverseProperty(nameof(AssignmentTag.Tagname))]
        public virtual ICollection<AssignmentTag> AssignmentTags { get; set; }
    }
}
