using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson11_serilog.Models;
using lesson11_serilog.ErrorHandling.HttpExceptions;

namespace lesson11_serilog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy(int year)
    {
        if(year < 1) {
            throw new BadRequestException("year must be more than 1", nameof(year));
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
