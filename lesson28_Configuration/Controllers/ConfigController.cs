using lesson28_Configuration.ConfigModels;
using Microsoft.AspNetCore.Mvc;

namespace lesson28_Configuration.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController : ControllerBase
{
    private readonly ILogger<ConfigController> _logger;
    private readonly EncryptionConfig _encryptionConfig;

    public ConfigController(ILogger<ConfigController> logger, IConfiguration configuration)
    {
        // bad way:
        //var key = configuration.GetChildren().First(cs => cs.Key == "EncryptionKey");
        // good way:
        _encryptionConfig = configuration.Get<EncryptionConfig>();
        _logger = logger;
    }

    [HttpGet("/Encription")]
    public EncryptionConfig Encription()
    {
        return _encryptionConfig;
    }
}
