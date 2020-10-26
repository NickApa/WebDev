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
    public class ColorInt : Controller
    {

        private readonly ILogger<ColorInt> _logger;

        public ColorInt(ILogger<ColorInt> logger)
        {
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View();
        }
            
        [HttpPost]
        public IActionResult MyPage(ColorInt c)
        {
            return View("Create", c);
        }

        //public string colorOutput(Color input)
        //{
        //    Color color = ColorTranslator.FromHtml(input);
        //    string htmlColor = ColorTranslator.ToHtml(color); 
        //    return htmlColor;
        //} 

    }
}
