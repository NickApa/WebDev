using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace HW8Project.Models
{
    public class Sort 
    {
       public IEnumerable<Assignment> AssignmentSorter { get; set; }
       public bool Priority { get; set; }
       public bool Due { get; set; }

       public IEnumerable<Cours> Courses {get; set; }

       public ICollection<Tagname> Tags {get; set; }


    }
}