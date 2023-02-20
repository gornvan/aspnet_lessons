using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace lessson26_LocalizatoinInMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMemoryCache _memoryCache;

    public HomeController(ILogger<HomeController> logger, IMemoryCache memcache)
    {
        _logger = logger;
        _memoryCache = memcache;
    }

    private string FetchData()
    {
        var rand = new Random();
        var randChars = Enumerable.Range(0, 100).Select(
            i => (char)rand.Next(127)).ToArray();
        var randString = new string(randChars);
        return randString;
    }

    public IActionResult Index(string? id = null)
    {
        if(id == null)
        {
            return View("Index", "");
        }


        if (_memoryCache.TryGetValue(id, out var valueFromCache))
        {
            return View("Index", valueFromCache);
        }

        var value = FetchData();
        _memoryCache.Set(id, value);

        return View("Index", value);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
