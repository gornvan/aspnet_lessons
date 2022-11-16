using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Diagnostics;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(AuthenticationViewModel auth)
        {


            auth.Password = "Secured";
            var greetingModel = new GreetingViewModel
            {
                Username = auth.Username,
            };
            return View(greetingModel);
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