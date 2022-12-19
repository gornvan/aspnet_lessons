using Microsoft.AspNetCore.Mvc;

namespace lesson13_Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post (List<IFormFile> files)
        {
            var file = files.First();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileData = reader.ReadToEnd();
            }

            return Ok();
        }

    }
}
