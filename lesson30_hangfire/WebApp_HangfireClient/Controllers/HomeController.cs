using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson30_hangfire.Models;
using Hangfire;
using lesson30_hangfire.BackgroundJobs;

namespace lesson30_hangfire.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult CreateJob()
    {
        var jobId = BackgroundJob.Schedule(
            () => FileWriteJobs.WriteHello(),
            TimeSpan.FromSeconds(3));

        return Redirect(nameof(Index));
    }

    [HttpPost]
    public IActionResult CreateRecurringJob()
    {
        RecurringJob.AddOrUpdate(
            "Console writer",
            () => Console.WriteLine("RECURRING!"),
            Cron.Minutely()
            );


        return Redirect(nameof(Index));
    }
}
