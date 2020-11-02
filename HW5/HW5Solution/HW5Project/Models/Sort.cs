using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace HW5Project.Models
{
    public class Sort 
    {
       public IEnumerable<Assignments> AssignmentSorter { get; set; }
       public bool Priority { get; set; }

       public bool Due { get; set; }
    }
}