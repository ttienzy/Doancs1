using Microsoft.AspNetCore.Mvc;

namespace MVCdemo.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Homepage()
        {
            return View();
        }
    }
}
