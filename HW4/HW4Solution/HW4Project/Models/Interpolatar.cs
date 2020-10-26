using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace HW4Project.Models
{
    public class Interpolatar
    {
		[Required]
		public string FirstColor { get; set; }

		public string SecondColor { get; set; }

		[Range(0, 100)]
		public int NumColors { get; set; }

		public string[] outputColors { get; set; }
    }
}
