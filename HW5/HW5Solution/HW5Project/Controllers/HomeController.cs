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
        private Sort unsorted = new Sort();

        private readonly ILogger<HomeController> _logger;

        public AssignmentsDbContext db;

        [HttpPost]
        public IActionResult Due() 
        {   
            var sort = new Sort();
            sort.AssignmentSorter = db.Assignments.OrderByDescending(x => x.Due).ToList();
            sort.AssignmentSorter = sort.AssignmentSorter.Reverse();
            sort.Due = true;

            return View("CurrentAssignments", sort);
        }

        [HttpPost]
          public IActionResult Priority() 
        {   
            var sort = new Sort();
            sort.AssignmentSorter = db.Assignments.OrderByDescending(x => x.Importance).ToList();
            sort.AssignmentSorter = sort.AssignmentSorter.Reverse();
            sort.Priority = true;
            return View("CurrentAssignments", sort);
        }

        public HomeController(ILogger<HomeController> logger, AssignmentsDbContext context)
        {
            _logger = logger;
            db = context;
            unsorted.AssignmentSorter = db.Assignments.ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult CurrentAssignments(Sort sort)
        {
            if(sort.Priority == true || sort.Due == true) 
            {
                return View("CurrentAssignments", sort);
            }
            else 
            {
                return View("CurrentAssignments", unsorted);
            }
        }

        [HttpPost]
        public IActionResult currentAssignments(Assignments assignment) {
            if(ModelState.IsValid) {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("CurrentAssignments");
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
