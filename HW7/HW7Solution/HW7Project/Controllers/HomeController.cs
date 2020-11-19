using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW7Project.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HW7Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private IConfiguration config; 

        public HomeController(ILogger<HomeController> logger, IConfiguration configer)
        {
            _logger = logger;
            config = configer;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GitUserInfo() {
            string secret = config["HW7:user-token"];
            GitAPI api = new GitAPI("https://api.github.com/user", "NickApa", secret);
            Account temp = api.userInfo();
            return Json(temp);
        }

        public IActionResult GitRepoInfo() {
            string secret = config["HW7:user-token"];
            GitAPI api = new GitAPI("https://api.github.com/user/repos", "NickApa", secret);
            IEnumerable<Repo> temp = api.repoInfo();
            return Json(temp);
        }

        
        public IActionResult gitCommitInfo(string repoName, string owner) {
            string secret = config["HW7:user-token"];
            GitAPI api = new GitAPI($"https://api.github.com/repos/{owner}/{repoName}/commits", "NickApa", secret);
            var temp = api.CommitInfo();

            return Json(temp);
        }
 
    }
}
