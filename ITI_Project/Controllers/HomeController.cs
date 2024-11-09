using System.Diagnostics;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using ITI_Project.CostomActionFilter;

namespace ITI_Project.Controllers
{
    [ExeptionFilter] //to handle the exception for the whole controller
    [LogFilter] //to log the action 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ExeptionFilter]
        public IActionResult Index()
        {
            //int x = int.Parse("a");
            return View();
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
