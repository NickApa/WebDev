using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;

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
            _logger.LogInformation("This worked");

            
                return View();
            }
    }
}
