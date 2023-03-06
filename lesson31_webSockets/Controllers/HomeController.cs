using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson31_webSockets.Models;

namespace lesson31_webSockets.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Echo()
    {
        return View();
    }

    public IActionResult Hub()
    {
        return View();
    }
}
