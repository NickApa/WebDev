using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW8Project.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW8Project.Controllers
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
            sort.AssignmentSorter = db.Assignments.OrderByDescending(x => x.Due).Include(x => x.Course).ToList();
            sort.AssignmentSorter = sort.AssignmentSorter.Reverse();
            sort.Due = true;
            sort.Courses = db.Courses.ToList();
            return View("CurrentAssignments", sort);
        }

        [HttpPost]
          public IActionResult Priority() 
        {   
            var sort = new Sort();
            sort.AssignmentSorter = db.Assignments.OrderByDescending(x => x.Importance).Include(x => x.Course).ToList();
            sort.AssignmentSorter = sort.AssignmentSorter.Reverse();
            sort.Priority = true;
            sort.Courses = db.Courses.ToList();
            return View("CurrentAssignments", sort);
        }

        [HttpGet]
        public IActionResult GetCourses(int Id) 
        {
            var sort = new Sort();
            
            var Assignments = db.Assignments.Where(c => c.Courseid == Id).OrderByDescending(x => x.Due).Reverse().ToList();
            sort.AssignmentSorter = Assignments;
            sort.Courses = db.Courses.ToList();
            return View("CurrentAssignments", sort);
        }

        
        
        public IActionResult Delete(int id) 
        {
            db.Assignments.Remove(db.Assignments.Find(id));
            db.SaveChanges();
            return RedirectToAction("CurrentAssignments");
        }

        public HomeController(ILogger<HomeController> logger, AssignmentsDbContext context)
        {
            _logger = logger;
            db = context;
            unsorted.AssignmentSorter = db.Assignments.Include(x => x.Course).ToList();
            unsorted.Courses = db.Courses.ToList();

        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Courses"] = new SelectList(db.Courses, "Id", "Name");
            ViewData["TagNames"] = new SelectList(db.Tagnames, "Id", "TagName1");
            
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

        [HttpGet]
        public IActionResult AddCourse(string CourseName) {
            foreach(var c in CourseName.Split(",")) {
                 var course = new Cours();
                course.Name = c.Trim().ToUpper();
                db.Courses.Add(course);
                db.SaveChanges();
            }
           
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTag(string TagName) {
            foreach(var t in TagName.Split(",")) {
                 var tag = new Tagname();
                tag.Tagname1 = t.Trim().ToUpper();
                db.Tagnames.Add(tag);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

         [HttpGet]
        public IActionResult GetTag(int Id) 
        {
            var sort = new Sort();
            var tag  = db.AssignmentTags.Where(t => t.Tagnameid == Id).ToList();
            sort.AssignmentSorter = db.Assignments.ToList();
            sort.Tags = db.Tagnames.ToList();
            return View("CurrentAssignments", sort);
        }

        [HttpPost]
        public IActionResult currentAssignments(Assignment assignment) {
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
