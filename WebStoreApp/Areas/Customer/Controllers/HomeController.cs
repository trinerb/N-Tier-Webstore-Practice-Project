using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebStore.Models;


namespace WebStoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)  //constructor for our class
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); //default view return. can override ex. "Privacy"
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