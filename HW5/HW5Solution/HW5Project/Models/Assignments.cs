using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW5Project.Models
{
    public partial class Assignments
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        
        [Column("IMPORTANCE")]
        public int Importance { get; set; }
        [Column("DUE", TypeName = "datetime")]
        public DateTime Due { get; set; }
        [Required]
        [Column("COURSE")]
        [StringLength(10)]
        public string Course { get; set; }
        [Required]
        [Column("TITLE")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Column("NOTES")]
        [StringLength(250)]
        public string Notes { get; set; }
    }
}
