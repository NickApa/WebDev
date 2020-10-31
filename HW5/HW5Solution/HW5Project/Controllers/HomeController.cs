using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW5Project.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HW5Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AssignmentsDbContext db;

        public HomeController(ILogger<HomeController> logger, AssignmentsDbContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            foreach(var val in db.Assignments) 
            {
                _logger.LogInformation($"{val.Importance}, {val.Due}, {val.Course}, {val.Title}, {val.Notes}");
            }
            return View();
        }

        
        [HttpGet]
        public IActionResult CurrentAssignments()
        {
            return View();
        }

        [HttpPost]
        public IActionResult currentAssignments(Assignments assignment) {
            if(ModelState.IsValid) {
                db.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("CurrentAssignments", assignment);
            }
            return View("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
