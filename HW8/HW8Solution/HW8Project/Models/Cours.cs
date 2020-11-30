using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class Cours
    {
        public Cours()
        {
            Assignments = new HashSet<Assignment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(10)]
        public string Name { get; set; }

        [InverseProperty(nameof(Assignment.Course))]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
