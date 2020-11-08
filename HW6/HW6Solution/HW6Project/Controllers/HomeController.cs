using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW6Project.Models;
using Microsoft.EntityFrameworkCore;

namespace HW6Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly ChinookDbContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ChinookDbContext dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        [HttpGet]
        public IActionResult Index(Search search)
        {
            if(ModelState.IsValid) {
                search.ArtistList = db.Artists.Where(s => s.Name.Contains(search.nameSearch)).ToList();
                return View("Index", search);
            }
            else {
                return View("Index", null);
            }
        }

        [HttpPost]
        public IActionResult output(Search search) 
        {
            search.ArtistName = db.Artists.Find(search.ArtistID).Name;

            search.Albums = new List<AlbumInfo>();

            var albums = db.Albums.Where(a => a.ArtistId == search.ArtistID).Include(t => t.Tracks).ToList();

            foreach(var alb in albums) {
                AlbumInfo temp = new AlbumInfo(); 
                temp.album = alb;
                var genreNames = db.Tracks.Where(g => g.AlbumId == temp.album.AlbumId)
                                 .GroupBy(g => g.Genre.Name)
                                 .OrderByDescending(g => g.Count())
                                 .Select(g => g.Key).Take(2).ToList();
                
                foreach(string gen in genreNames) {
                    temp.genre += gen + " ";
                }
                
                search.Albums.Add(temp);

                
            }

            return View("output", search);
        }

        public IActionResult Privacy()
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
