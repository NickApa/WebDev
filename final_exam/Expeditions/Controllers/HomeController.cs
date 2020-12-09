using Expeditions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.Models;

namespace Expeditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpeditionsDbContext Db;

        public HomeController(ILogger<HomeController> logger, ExpeditionsDbContext context)
        {
            Db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var mtnlist = Db.Peaks.OrderByDescending(x => x.Height);
            mtnlist.Reverse();

            var mountain = new Mountain()
            {
                mtn = mtnlist.Take(15).ToList(),
                
            };

            return View(mountain);
        }

        public List<int> DataStats()
        {
            var list = new List<int>();
            int _currentlyTracking = Db.Expeditions.Count();
            int peaks = Db.Peaks.Count();
            int notClimbed = Db.Peaks.Where(x => x.Expeditions.Count() == 0).Count();
            list.Add(_currentlyTracking);
            list.Add(peaks);
            list.Add(notClimbed);
            return (list);
        }

        public IActionResult Climber() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
 