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

        [Required(ErrorMessage = "Please enter a priority")]
        [Column("IMPORTANCE")]
        [Range(1, 5)]
        public int Importance { get; set; }

        [Required(ErrorMessage = "Please enter a date with valid formatting")]
        [Column("DUE", TypeName = "datetime")]
        public DateTime Due { get; set; }


        [Required(ErrorMessage = "Please enter a course")]
        [Column("COURSE")]
        [StringLength(10)]
        public string Course { get; set; }


        [Required(ErrorMessage = "Please enter a title name")]
        [Column("TITLE")]
        [StringLength(50)]
        public string Title { get; set; }


        
        [Column("NOTES")]
        [StringLength(250)]
        public string Notes { get; set; }



    }
}
