using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace HW4Project.Models
{
    public class RGBColors
    {
        [Required]

        [Range(0, 255)]

        public int Red { get; set; }

        [Range(0, 255)]

        public int Green { get; set; }

        [Range(0, 255)]

        public int Blue { get; set; }

        public string chosenColor()
        {
            Color colors = Color.FromArgb(Red, Green, Blue);
            return ColorTranslator.ToHtml(colors);
        }
    }
}
