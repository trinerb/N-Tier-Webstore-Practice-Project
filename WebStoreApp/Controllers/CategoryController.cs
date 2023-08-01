using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
