using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;
using System.Security.Policy;
using System.Drawing;

namespace HW4Project.Controllers
{
    public class ColorIntController : Controller
    {

        private readonly ILogger<ColorIntController> _logger;

        public ColorIntController(ILogger<ColorIntController> logger)
        {
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View();
        }
            
        [HttpPost]
        public IActionResult Create(Interpolatar c)
        {
           
            if(ModelState.IsValid)
            {
                Color color1 = ColorTranslator.FromHtml(c.FirstColor);
                Color color2 = ColorTranslator.FromHtml(c.SecondColor);
            

                ColorToHSV(color1, out double start_hue, out double start_saturation, out double start_value);
                ColorToHSV(color2, out double end_hue, out double end_saturation, out double end_value);

                var newHue = (end_hue - start_hue) / (c.NumColors - 1);
                var newSat = (end_saturation - start_saturation) / (c.NumColors - 1);
                var newVal = (end_value - start_value) / (c.NumColors - 1);

                string[] outputColors = new string[c.NumColors];

                for(int i = 0; i < c.NumColors; i++)
                {
                    var nextHue = start_hue + (newHue * i);
                    var nextSat = start_saturation + (newSat * i);
                    var nextVal = start_value + (newVal * i);

                    Color newColor = ColorFromHSV(nextHue, nextSat, nextVal);
                    string htmlColor = ColorTranslator.ToHtml(newColor);
                    outputColors[i] = htmlColor; 
                }

                c.outputColors = outputColors;

                return View("Create", c);
            }
            else
            {
                return View();
            }


        }
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

    }
}
