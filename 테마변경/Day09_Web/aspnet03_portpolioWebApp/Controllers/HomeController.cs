using aspnet01_webapp.Data;
using aspnet02_boardapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnet01_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // SELECT * FROM portfolios WHERE Division = 'PORTFOLIO';
            var result = _db.Portfolios.Where(q => q.Division == "PORTFOLIO").ToList();

            
            return View(result);
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