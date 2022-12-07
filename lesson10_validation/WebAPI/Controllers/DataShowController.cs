using lesson10_validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DataShowController : ControllerBase
{
    // in case the argument is not supplied the route, WebAPI returns 400. If default value is not set.
    [HttpGet("/{id}")]
    public IActionResult Get(int id = 6)
    {
        return Content("Editor...");
    }

    [HttpPost]
    public IActionResult Post(ShowDataViewModel model, int id = 6)
    {
        var validity = ModelState.IsValid;

        var errors = ModelState.SelectMany(kvp => kvp.Value.Errors).ToList();

        return Content("Okay");
    }
}
